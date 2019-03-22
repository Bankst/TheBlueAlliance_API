using Newtonsoft.Json;

using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;

namespace TheBlueAlliance
{
	public class ApiRequest
	{
		public const string ApiUrl = "http://www.thebluealliance.com/api/v3";
		public const string ApiKey = "plzzrHeQRVUlc7CQF0rpeP8T9gXx4Y8UnPF6wGgq3Ma5dsa65nc3nJK2oOjQSSLs";

		private static readonly string CacheRoot = $@"{AppDomain.CurrentDomain.BaseDirectory}\Cache\TBA";

		private readonly string _path;
		private readonly string _cacheFolder;
		private readonly string _cacheFullPath;

		public string LastModified { get; private set; }

		public bool ShouldCheckCache { get; set; } = true;
		public bool HasCached { get; private set; }
		public bool HasHitCache { get; private set; }

		public ApiRequest(string path)
		{
			_path = path;

			var split = _path.Split('/');
			var fileFolder = string.Join(@"/", split.Take(split.Length - 1));

			var cacheFilename = $"{split.Last()}.json";
			_cacheFolder = $"{CacheRoot}{fileFolder.Replace(@"/", @"\")}";
			_cacheFullPath = Path.Combine(_cacheFolder, cacheFilename);
		}

		private static readonly JsonSerializerSettings DeserializerSettings = new JsonSerializerSettings()
		{
			ContractResolver = new CamelCasePropertyNamesContractResolver()
		};

		public T GetData<T>() => GetDataAsync<T>().Result;

		public async Task<T> GetDataAsync<T>()
		{
			T obj = default;
			try
			{
				if (CacheExists() && ShouldCheckCache)
				{
					HasHitCache = true;
					return GetCachedData<T>();
				}

				using (var wc = new HttpClient())
				using (var req = new HttpRequestMessage(HttpMethod.Get, $"{ApiUrl}{_path}"))
				{
					req.Headers.Add("X-TBA-Auth-Key", ApiKey);
					if (LastModified != null)
					{
						req.Headers.Add("If-Since-Modified", LastModified);
					}
					
					using (var resp = await wc.SendAsync(req))
					{

						if (resp.Content.Headers.TryGetValues("Last-Modified", out var lastModified))
						{
							LastModified = lastModified.First();
						}

						switch ((int)resp.StatusCode)
						{
							case 200:
								var stringData = await GetResponseData(resp);
								obj = GetObject<T>(stringData);
								HasCached = CacheData(stringData);
								break;
							case 304:
								obj = GetCachedData<T>();
								break;
							case 401:
								// hecc
								break;
						}
					}
				}
			}
			catch (WebException exW)
			{
				if (exW.Response is HttpWebResponse httpResp && httpResp.StatusCode == HttpStatusCode.Forbidden)
				{
					Console.WriteLine("Bad API Key!");
				}
			}
			return obj;
		}

		private T GetCachedData<T>()
		{
			HasHitCache = true;
			return GetObject<T>(GetCachedJson());
		}

		private string GetCachedJson() => File.Exists(_cacheFullPath) ? File.ReadAllText(_cacheFullPath) : null;

		public bool CacheExists() => File.Exists(_cacheFullPath);

		private bool CacheData(string rawData)
		{
			try
			{
				if (File.Exists(_cacheFullPath))
				{
					File.Delete(_cacheFullPath);
				}

				Directory.CreateDirectory(_cacheFolder);

				File.WriteAllText(_cacheFullPath, rawData);
				return true;
			}
			catch(Exception ex)
			{
				Console.WriteLine($"Failed to cache response:\n {ex.Message}");
				return false;
			}
			
		}

		private static T GetObject<T>(string data) => JsonConvert.DeserializeObject<T>(data, DeserializerSettings);

		private static async Task<string> GetResponseData(HttpResponseMessage msg)
		{
			var buffer = await msg.Content.ReadAsByteArrayAsync();
			var byteArray = buffer.ToArray();
			var stringData = Encoding.UTF8.GetString(buffer.ToArray(), 0, byteArray.Length);
			return stringData;
		}

		public bool ClearCache()
		{
			try
			{
				if (!File.Exists(_cacheFullPath)) return true;
				File.Delete(_cacheFullPath);
				return true;
			}
			catch
			{
				return false;
			}
		}

		public static bool ClearEntireCache()
		{
			try
			{
				if (!Directory.Exists(CacheRoot)) return true;
				Directory.Delete(CacheRoot, true);
				return true;
			}
			catch
			{
				return false;
			}
		}
	}
}
