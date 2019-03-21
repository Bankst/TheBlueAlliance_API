using System;
using System.IO;
using System.Net;
using System.Reflection;
using Newtonsoft.Json;
using TheBlueAlliance.Models;
using TheBlueAlliance.Properties;

namespace TheBlueAlliance
{
    public class Matches
    {
//        private static string GetMatchInformationJsonData(string matchKey)
//        {
//	        var url = Constants.GetRequestUrl($"/match/{matchKey}");
//
//	        using (var wc = new WebClient())
//	        {
//				wc.Headers.Add("X-TBA-Auth-Key", ApiRequest.ApiKey);
//				var downloadedData = wc.DownloadString(url);
//
//				if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\Cache\\TBA\\Matches\\" + matchKey + ".json"))
//				{
//					File.Delete(AppDomain.CurrentDomain.BaseDirectory + "\\Cache\\TBA\\Matches\\" + matchKey + ".json");
//				}
//				Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "\\Cache\\TBA\\Matches\\");
//				File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "\\Cache\\TBA\\Matches\\" + matchKey + ".json", downloadedData);
//				return downloadedData;
//
//			}
//
//
//			try
//				{
//					var path = $"/match/{matchKey}";
//					var url = $"{Constants.ApiUrl}{path}";
//
//					if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\Cache\\TBA\\Matches\\" + matchKey + ".json"))
//					{
//						File.Delete(AppDomain.CurrentDomain.BaseDirectory + "\\Cache\\TBA\\Matches\\" + matchKey + ".json");
//					}
//					Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "\\Cache\\TBA\\Matches\\");
//					File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "\\Cache\\TBA\\Matches\\" + matchKey + ".json", downloadedData);
//					return downloadedData;
//				}
//				catch (Exception webError)
//				{
//					Console.WriteLine("Error Message: " + webError.Message);
//					return GetCachedMatchInformationJson(matchKey);
//				}
//        }
//
//        private static string GetCachedMatchInformationJson(string matchKey)
//		{
//			return File.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\Cache\\TBA\\Matches\\" + matchKey + ".json") ? File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "\\Cache\\TBA\\Matches\\" + matchKey + ".json") : null;
//		}
    }
}