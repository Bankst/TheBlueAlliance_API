using System.Collections.Generic;
using System.Linq;
using TheBlueAlliance.MainModels;
using TheBlueAlliance.SpecificModels;

namespace TheBlueAlliance
{
	public class Teams
	{

		private static ApiRequest _teamEventAwardsRequest;
		public static Award[] GetTeamEventAwards(string teamKey, string eventKey)
		{
			if (_teamEventAwardsRequest == null)
			{
				_teamEventAwardsRequest = new ApiRequest($"/team/{teamKey}/event/{eventKey}/awards");
			}
			var response = _teamEventAwardsRequest.GetData<Award[]>();
			return response.ToArray();
		}

		private static ApiRequest _teamEventMatches2019Request;
		public static Match2019[] GetTeamEventMatches2019(string teamKey, string eventKey)
		{
			if (eventKey.Substring(0, 4) != "2019")
			{
				return null;
			}

			if (_teamEventMatches2019Request == null)
			{
				_teamEventMatches2019Request = new ApiRequest($"/team/{teamKey}/event/{eventKey}/matches");
			}

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

		private static ApiRequest _teamHistoryRequest;
		public static Event[] GetTeamHistoryEvents(string teamKey)
		{
			if (_teamHistoryRequest == null)
			{
				_teamHistoryRequest = new ApiRequest($"/team/{teamKey}/events");
			}

			var response = _teamHistoryRequest.GetData<List<Event>>();
			return response.ToArray();
		}


		private static ApiRequest _teamInformationRequest;
		/// <summary>
		///     Provides general information for any FRC team
		///     teamKey Format Example : "frc3710"
		/// </summary>
		/// <param name="teamKey"></param>
		/// <returns></returns>
		public static Team GetTeamInformation(string teamKey)
		{
			if (_teamInformationRequest == null)
			{
				_teamInformationRequest = new ApiRequest($"/team/{teamKey}");
			}

			var response = _teamInformationRequest.GetData<Team>();
			return response;
		}

		private static ApiRequest _teamMediaRequest;
		public static Media[] GetTeamMedia(string teamKey, int year)
		{
			if (_teamMediaRequest == null)
			{
				_teamMediaRequest = new ApiRequest($"/team/{teamKey}/media/{year}");
			}

			var response = _teamMediaRequest.GetData<List<Media>>();
			return response.ToArray();
		}
	}
}