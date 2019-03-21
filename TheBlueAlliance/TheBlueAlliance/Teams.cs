using System;
using System.Collections.Generic;
using System.Linq;
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
			var request = new ApiRequest($"/team/{teamKey}/event/{eventKey}/awards");
			var response = request.GetData<Award[]>().ToArray();
			return response;
        }

		private static ApiRequest _teamEventMatches2019Request;
        public static Match2019[] GetTeamEventMatches2019(string teamKey, string eventKey)
        {
            if (eventKey.Substring(0, 4) != "2019")
            {
                return null;
            }
			
            _teamEventMatches2019Request = new ApiRequest($"/team/{teamKey}/event/{eventKey}/matches");
            var response = _teamEventMatches2019Request.GetData<Match2019[]>();
            return response.ToArray();
        }

        private static ApiRequest _teamEventsRequest;
        public static Event[] GetTeamEvents(string teamKey, int year)
        {
			if (_teamEventsRequest == null)
			{ 
				_teamEventsRequest = new ApiRequest($"/team/{teamKey}/events/{year}");
			}
			var response = _teamEventsRequest.GetData<Event[]>();
			return response.ToArray();
        }


		private static ApiRequest _teamHistoricalAwardsRequest;
        public static Award[] GetTeamHistoricalAwards(string teamKey)
        {
	        if (_teamHistoricalAwardsRequest == null)
	        {
		        _teamHistoricalAwardsRequest = new ApiRequest($"/team/{teamKey}/awards");
	        }
	        var response = _teamHistoricalAwardsRequest.GetData<Award[]>();
	        return response.ToArray();
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
					wc.Headers.Add("X-TBA-Auth-Key", ApiRequest.ApiKey);
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
					wc.Headers.Add("X-TBA-Auth-Key", ApiRequest.ApiKey);
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
					wc.Headers.Add("X-TBA-Auth-Key", ApiRequest.ApiKey);
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