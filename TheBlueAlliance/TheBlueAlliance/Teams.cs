using System.Collections.Generic;
using System.Linq;
using TheBlueAlliance.MainModels;
using TheBlueAlliance.SpecificModels;

namespace TheBlueAlliance
{
	public class Teams
	{
		public static ApiRequest TeamEventAwardsRequest { get; private set; }
		public static Award[] GetTeamEventAwards(string teamKey, string eventKey, bool checkCache = true)
		{
			if (TeamEventAwardsRequest == null)
			{
				TeamEventAwardsRequest = new ApiRequest($"/team/{teamKey}/event/{eventKey}/awards");
			}

			TeamEventAwardsRequest.ShouldCheckCache = checkCache;

			var response = TeamEventAwardsRequest.GetData<Award[]>();
			return response.ToArray();
		}

		public static ApiRequest TeamEventMatches2019Request { get; private set; }
		public static Match2019[] GetTeamEventMatches2019(string teamKey, string eventKey, bool checkCache = true)
		{
			if (eventKey.Substring(0, 4) != "2019")
			{
				return null;
			}

			if (TeamEventMatches2019Request == null)
			{
				TeamEventMatches2019Request = new ApiRequest($"/team/{teamKey}/event/{eventKey}/matches");
			}

			TeamEventMatches2019Request.ShouldCheckCache = checkCache;

			var response = TeamEventMatches2019Request.GetData<Match2019[]>();
			return response.ToArray();
		}

		public static ApiRequest TeamEventsRequest { get; private set; }
		public static Event[] GetTeamEvents(string teamKey, int year, bool checkCache = true)
		{
			if (TeamEventsRequest == null)
			{
				TeamEventsRequest = new ApiRequest($"/team/{teamKey}/events/{year}");
			}

			TeamEventsRequest.ShouldCheckCache = checkCache;

			var response = TeamEventsRequest.GetData<Event[]>();
			return response.ToArray();
		}


		public static ApiRequest TeamHistoricalAwardsRequest { get; private set; }
		public static Award[] GetTeamHistoricalAwards(string teamKey, bool checkCache = true)
		{
			if (TeamHistoricalAwardsRequest == null)
			{
				TeamHistoricalAwardsRequest = new ApiRequest($"/team/{teamKey}/awards");
			}

			TeamHistoricalAwardsRequest.ShouldCheckCache = checkCache;

			var response = TeamHistoricalAwardsRequest.GetData<Award[]>();
			return response.ToArray();
		}

		public static ApiRequest TeamHistoryRequest { get; private set; }
		public static Event[] GetTeamHistoryEvents(string teamKey, bool checkCache = true)
		{
			if (TeamHistoryRequest == null)
			{
				TeamHistoryRequest = new ApiRequest($"/team/{teamKey}/events");
			}

			TeamHistoryRequest.ShouldCheckCache = checkCache;

			var response = TeamHistoryRequest.GetData<List<Event>>();
			return response.ToArray();
		}


		public static ApiRequest TeamInformationRequest { get; private set; }
		public static Team GetTeamInformation(string teamKey, bool checkCache = true)
		{
			if (TeamInformationRequest == null)
			{
				TeamInformationRequest = new ApiRequest($"/team/{teamKey}");
			}

			TeamInformationRequest.ShouldCheckCache = checkCache;

			var response = TeamInformationRequest.GetData<Team>();
			return response;
		}

		public static ApiRequest TeamMediaRequest { get; private set; }
		public static Media[] GetTeamMedia(string teamKey, int year, bool checkCache = true)
		{
			if (TeamMediaRequest == null)
			{
				TeamMediaRequest = new ApiRequest($"/team/{teamKey}/media/{year}");
			}

			TeamMediaRequest.ShouldCheckCache = checkCache;

			var response = TeamMediaRequest.GetData<List<Media>>();
			return response.ToArray();
		}
	}
}