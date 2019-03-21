using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using TheBlueAlliance.Models;
using TheBlueAlliance.Models.MainModels;
using TheBlueAlliance.Properties;

namespace TheBlueAlliance
{
	public class Events
	{
		#region Event Information
		/// <summary>
		///     Provides information for an event
		/// </summary>
		/// <param name="eventKey"></param>
		/// <returns></returns>
		public static Event GetEventInformation(string eventKey)
		{
			return GetEventInformationJson(eventKey) != null ? JsonConvert.DeserializeObject<Event>(GetEventInformationJson(eventKey)) : null;
		}

		private static string GetEventInformationJson(string eventKey)
		{
			var url = Constants.GetRequestUrl($"/event/{eventKey}");

			try
			{
				using (var wc = new WebClient())
				{
					wc.Headers.Add("X-TBA-Auth-Key", ApiRequest.ApiKey);
					var downloadedData = wc.DownloadString(url);

					if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\Cache\\TBA\\Events\\EventInformation\\" +
									eventKey + ".json"))
					{
						File.Delete(AppDomain.CurrentDomain.BaseDirectory + "\\Cache\\TBA\\Events\\EventInformation\\" +
									eventKey + ".json");
					}

					Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory +
											  "\\Cache\\TBA\\Events\\EventInformation\\");
					File.WriteAllText(
						AppDomain.CurrentDomain.BaseDirectory + "\\Cache\\TBA\\Events\\EventInformation\\" + eventKey +
						".json", downloadedData);
					return downloadedData;
				}
			}
			catch (Exception webError)
			{
				Console.WriteLine("Error Message: " + webError.Message);
				return GetEventInformationCachedJson(eventKey);
			}
		}

		private static string GetEventInformationCachedJson(string eventKey)
		{
			return File.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\Cache\\TBA\\Events\\EventInformation\\" + eventKey + ".json") ? File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "\\Cache\\TBA\\Events\\EventInformation\\" + eventKey + ".json") : null;
		}
		#endregion

		#region Event Awards
		public static EventAwards.Award[] GetEventAwards(string eventKey)
		{
			return GetEventAwardsJson(eventKey) != null ? JsonConvert.DeserializeObject<List<EventAwards.Award>>(GetEventAwardsJson(eventKey)).ToArray() : null;
		}

		private static string GetEventAwardsJson(string eventKey)
		{
			var path = $"/event/{eventKey}/awards";
			var url = $"{ApiRequest.ApiUrl}{path}";

			try
			{

			}
			catch
			{

			}

			try
			{
				using (var wc = new WebClient())
				{
					wc.Headers.Add("X-TBA-Auth-Key", ApiRequest.ApiKey);
					var downloadedData = wc.DownloadString(url);
					if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\Cache\\TBA\\Events\\EventAwards\\" + eventKey + ".json"))
					{
						File.Delete(AppDomain.CurrentDomain.BaseDirectory + "\\Cache\\TBA\\Events\\EventAwards\\" + eventKey + ".json");
					}
					Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "\\Cache\\TBA\\Events\\EventAwards\\");
					File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "\\Cache\\TBA\\Events\\EventAwards\\" + eventKey + ".json", downloadedData);
					return downloadedData;
				}
			}
			catch (Exception webError)
			{
				Console.WriteLine("Error Message: " + webError.Message);
				return GetEventAwardsCachedJson(eventKey);
			}
		}

		private static string GetEventAwardsCachedJson(string eventKey)
		{
			return File.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\Cache\\TBA\\Events\\EventAwards\\" + eventKey + ".json") ? File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "\\Cache\\TBA\\Events\\EventAwards\\" + eventKey + ".json") : null;
		}
		#endregion

		public static EventMatches.Match[] GetEventMatches(string eventKey)
		{
			var dataList = new List<EventMatches.Match>();
			var eventMatchesToReturn = dataList.ToArray();
			var url = Constants.GetRequestUrl($"/event/{eventKey}/matches");

			try
			{
				var req = new ApiRequest($"/event/{eventKey}/matches");
				eventMatchesToReturn = req.GetData<List<EventMatches.Match>>().Result.ToArray();
				using (var wc = new WebClient())
				{
					wc.Headers.Add("X-TBA-Auth-Key", ApiRequest.ApiKey);
					dataList = JsonConvert.DeserializeObject<List<EventMatches.Match>>(wc.DownloadString(url));
					eventMatchesToReturn = dataList.ToArray();
				}
			}
			catch (Exception webError)
			{
				Console.WriteLine("Error Message: " + webError.Message);
			}

			return eventMatchesToReturn;
		}

		public static EventRankings.Team[] GetEventRankings(string eventKey)
		{
			var teamList = new List<EventRankings.Team>();
			var dataList = new List<List<object>>();
			var url = Constants.GetRequestUrl($"/event/{eventKey}/rankings");

			try
			{
				using (var wc = new WebClient())
				{
					wc.Headers.Add("X-TBA-Auth-Key", ApiRequest.ApiKey);
					dataList = JsonConvert.DeserializeObject<List<List<object>>>(wc.DownloadString(url));
				}
			}
			catch (Exception webError)
			{
				Console.WriteLine("Error Message: " + webError.Message);
			}
			finally
			{
				for (var i = 1; i < dataList.Count; i++)
				{
					var teamToAdd = new EventRankings.Team
					{
						Rank = Convert.ToInt32(dataList.ToArray()[i][0]),
						Team_Number = Convert.ToInt32(dataList.ToArray()[i][1]),
						Qual_Average = Convert.ToDouble(dataList.ToArray()[i][2]),
						Auto = Convert.ToInt32(dataList.ToArray()[i][3]),
						Container = Convert.ToInt32(dataList.ToArray()[i][4]),
						Coopertition = Convert.ToInt32(dataList.ToArray()[i][5]),
						Litter = Convert.ToInt32(dataList.ToArray()[i][6]),
						Tote = Convert.ToInt32(dataList.ToArray()[i][7]),
						Played = Convert.ToInt32(dataList.ToArray()[i][8])
					};
					teamList.Add(teamToAdd);
				}
			}
			return teamList.ToArray();
		}

		public static Event[] GetEvents(int year)
		{
			var dataList = new List<Event>();
			var url = Constants.GetRequestUrl($"/events/{year}");

			try
			{
				using (var wc = new WebClient())
				{
					wc.Headers.Add("X-TBA-Auth-Key", ApiRequest.ApiKey);
					dataList = JsonConvert.DeserializeObject<List<Event>>(wc.DownloadString(url));
				}
			}
			catch (Exception webError)
			{
				Console.WriteLine("Error Message: " + webError.Message);
			}

			return dataList.ToArray();
		}

		public static EventTeams.Team[] GetEventTeamsList(string eventKey)
		{
			var teamList = new List<EventTeams.Team>();

			var path = $"/event/{eventKey}/teams";
			var url = Constants.GetRequestUrl($"/event/{eventKey}/teams");

			try
			{
				using (var wc = new WebClient())
				{
					wc.Headers.Add("X-TBA-Auth-Key", ApiRequest.ApiKey);
					teamList = JsonConvert.DeserializeObject<List<EventTeams.Team>>(wc.DownloadString(url));
				}
			}
			catch (Exception webError)
			{
				Console.WriteLine("Error Message: " + webError.Message);
			}

			return teamList.ToArray();
		}
	}
}