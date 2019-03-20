using System;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;
using TheBlueAlliance.Models;
using TheBlueAlliance.Models.MainModels;
using TheBlueAlliance.Models.SpecificModels;
using TheBlueAlliance.Properties;

namespace TheBlueAlliance
{
    public class Teams
	{

		public static Award[] GetTeamEventAwards(string teamKey, string eventKey)
        {
			var teamEventAwardsToReturn = new List<Award>();
			var url = Constants.GetRequestUrl($"/team/{teamKey}/event/{eventKey}/awards");

			try
			{
				using (var wc = new WebClient())
				{
					wc.Headers.Add("X-TBA-Auth-Key", Settings.Default.AuthKey);
					teamEventAwardsToReturn = JsonConvert.DeserializeObject<List<Award>>(wc.DownloadString(url));
				}
			}
            catch (Exception webError)
            {
                Console.WriteLine("Error Message: " + webError.Message);
            }
            return teamEventAwardsToReturn.ToArray();
		}

        public static Match_2019[] GetTeamEventMatches2019(string teamKey, string eventKey)
        {
            if (eventKey.Substring(0, 4) != "2019")
            {
                return null;
            }

            var teamEventMatchesToReturn = new List<Match_2019>();
			var url = Constants.GetRequestUrl($"/team/{teamKey}/event/{eventKey}/matches");
			
			try
            {
				using (var wc = new WebClient())
				{
					wc.Headers.Add("X-TBA-Auth-Key", Settings.Default.AuthKey);
					teamEventMatchesToReturn = JsonConvert.DeserializeObject<List<Match_2019>>(wc.DownloadString(url));
				}
			}
            catch (Exception webError)
            {
                Console.WriteLine("Error Message: " + webError.Message);
            }
            return teamEventMatchesToReturn.ToArray();
        }

        public static TeamEvents.Event[] GetTeamEvents(string teamKey, int year)
        {
            var teamEventsToReturn = new List<TeamEvents.Event>();

			var url = Constants.GetRequestUrl($"/team/{teamKey}/events/{year}");

			try
			{
				using (var wc = new WebClient())
				{
					wc.Headers.Add("X-TBA-Auth-Key", Settings.Default.AuthKey);
					teamEventsToReturn = JsonConvert.DeserializeObject<List<TeamEvents.Event>>(wc.DownloadString(url));
				}
			}
            catch (Exception webError)
            {
                Console.WriteLine("Error Message: " + webError.Message);
            }
            return teamEventsToReturn.ToArray();
        }

        public static Award[] GetTeamHistoricalAwards(string teamKey)
        {
            var teamHistoricalAwardsToReturn = new List<Award>();

			var url = Constants.GetRequestUrl($"/team/{teamKey}/awards");
			
			try
            {
				using (var wc = new WebClient())
				{
					wc.Headers.Add("X-TBA-Auth-Key", Settings.Default.AuthKey);
					teamHistoricalAwardsToReturn = JsonConvert.DeserializeObject<List<Award>>(wc.DownloadString(url));
				}
			}
            catch (Exception webError)
            {
                Console.WriteLine("Error Message: " + webError.Message);
            }
            return teamHistoricalAwardsToReturn.ToArray();
        }

        public static Event[] GetTeamHistoryEvents(string teamKey)
        {
            var teamHistoricalEventsToReturn = new List<Event>();

			var path = $"/team/{teamKey}/events";
			var url = Constants.GetRequestUrl(path);
			
			try
            {
				using (var wc = new WebClient())
				{
					wc.Headers.Add("X-TBA-Auth-Key", Settings.Default.AuthKey);
					teamHistoricalEventsToReturn = JsonConvert.DeserializeObject<List<Event>>(wc.DownloadString(url));
				}
			}
            catch (Exception webError)
            {
                Console.WriteLine("Error Message: " + webError.Message);
            }
            return teamHistoricalEventsToReturn.ToArray();
        }

        /// <summary>
        ///     Provides general information for any FRC team
        ///     teamKey Format Example : "frc3710"
        /// </summary>
        /// <param name="teamKey"></param>
        /// <returns></returns>
        public static TeamInformation GetTeamInformation(string teamKey)
        {
            var teamInformationToReturn = new TeamInformation();

			var url = Constants.GetRequestUrl($"/team/{teamKey}");
			
			try
            {
				using (var wc = new WebClient())
				{
					wc.Headers.Add("X-TBA-Auth-Key", Settings.Default.AuthKey);
					teamInformationToReturn = JsonConvert.DeserializeObject<TeamInformation>(wc.DownloadString(url));

				}
			}
            catch (Exception webError)
            {
                Console.WriteLine("Error Message: " + webError.Message);
            }
            return teamInformationToReturn;
        }

        public static TeamMedia.MediaLocation[] GetTeamMediaLocations(string teamKey, int year)
        {
            var teamMediaLocationsToReturn = new List<TeamMedia.MediaLocation>();

			var url = Constants.GetRequestUrl($"/team/{teamKey}/{year}/media");
			
			try
            {
				using (var wc = new WebClient())
				{
					wc.Headers.Add("X-TBA-Auth-Key", Settings.Default.AuthKey);
					teamMediaLocationsToReturn = JsonConvert.DeserializeObject<List<TeamMedia.MediaLocation>>(wc.DownloadString(url));
				}
			}
            catch (Exception webError)
            {
                Console.WriteLine("Error Message: " + webError.Message);
            }
            return teamMediaLocationsToReturn.ToArray();
        }
    }
}