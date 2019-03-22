using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TheBlueAlliance
{
	public class ApiRequest
	{
		public const string ApiUrl = "http://www.thebluealliance.com/api/v3";
		public const string ApiKey = "plzzrHeQRVUlc7CQF0rpeP8T9gXx4Y8UnPF6wGgq3Ma5dsa65nc3nJK2oOjQSSLs";

		private static readonly string CacheRoot = $@"{AppDomain.CurrentDomain.BaseDirectory}\Cache\TBA";

		private readonly string _path;
		private readonly string _cacheFolder;
		private readonly string _cacheFilename;

		private string LastModified;

		public ApiRequest(string path)
		{
			_path = path;

			var split = _path.Split('/');
			var fileFolder = string.Join(@"/", split.Take(split.Length - 1));

			_cacheFolder = $"{CacheRoot}{fileFolder.Replace(@"/", @"\")}";
			_cacheFilename = $"{split.Last()}.json";
		}

		public T GetData<T>()
		{
			return GetDataAsync<T>().Result;
		}

		public async Task<T> GetDataAsync<T>()
		{
			T obj = default;
			try
			{
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
						if (resp.Headers.TryGetValues("Last-Modified", out var lastModified))
						{
							LastModified = lastModified.First();
						}

						switch ((int)resp.StatusCode)
						{
							case 200:
								var stringData = await GetResponseData(resp);
								obj = GetObject<T>(stringData);
								CacheData(stringData);
								break;
							case 304:
								obj = GetCachedData<T>();
								break;
							case 401:
								// shit
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

		private T GetCachedData<T>() => GetObject<T>(GetCachedJson());

		private string GetCachedJson()
		{
			var path = Path.Combine(CacheRoot, _path, ".json");
			return File.Exists(path) ? File.ReadAllText(path) : null;
		}

		private void CacheData(string rawData)
		{
			var fullPath = Path.Combine(_cacheFolder, _cacheFilename);

			if (File.Exists(fullPath))
			{
				File.Delete(fullPath);
			}

			Directory.CreateDirectory(_cacheFolder);

			File.WriteAllText(fullPath, rawData);
		}

		private static T GetObject<T>(string data)
		{
			return JsonConvert.DeserializeObject<T>(data);
		}

		private static async Task<string> GetResponseData(HttpResponseMessage msg)
		{
			var buffer = await msg.Content.ReadAsByteArrayAsync();
			var byteArray = buffer.ToArray();
			var stringData = Encoding.UTF8.GetString(buffer.ToArray(), 0, byteArray.Length);
			return stringData;
		}
	}
}
