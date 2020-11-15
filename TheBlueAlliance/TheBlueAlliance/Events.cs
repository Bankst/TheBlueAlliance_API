using System.Collections.Generic;
using System.Linq;
using TheBlueAlliance.MainModels;
using TheBlueAlliance.SpecificModels;

namespace TheBlueAlliance
{
	public class Events
	{
		public static ApiRequest EventInformationRequest { get; private set; }
		public static Event GetEventInformation(string eventKey, bool checkCache = true)
		{
			if (EventInformationRequest == null)
			{
				EventInformationRequest = new ApiRequest($"/event/{eventKey}");
			}
			EventInformationRequest.ShouldCheckCache = checkCache;

			var response = EventInformationRequest.GetData<Event>();
			return response;
		}

		public static ApiRequest EventAwardsRequest { get; private set; }
		public static Award[] GetEventAwards(string eventKey, bool checkCache = true)
		{
			if (EventAwardsRequest == null)
			{
				EventAwardsRequest = new ApiRequest($"/event/{eventKey}/awards");
			}
			EventAwardsRequest.ShouldCheckCache = checkCache;

			var response = EventAwardsRequest.GetData<Award[]>();
			return response.ToArray();
		}

		public static ApiRequest EventMatchesRequest { get; private set; }
		public static Match2019[] GetEventMatches2019(string eventKey, bool checkCache = true)
		{
			if (EventMatchesRequest == null)
			{
				EventMatchesRequest = new ApiRequest($"/event/{eventKey}/matches");
			}
			EventMatchesRequest.ShouldCheckCache = checkCache;

			var response = EventMatchesRequest.GetData<Match2019[]>();
			return response.ToArray();
		}

		public static ApiRequest EventRankingsRequest { get; private set; }
		public static Ranking2019[] GetEventRankings2019(string eventKey, bool checkCache = true)
		{
			var teamList = new List<Ranking2019>();

			if (EventRankingsRequest == null)
			{
				EventRankingsRequest = new ApiRequest($"/event/{eventKey}/rankings");
			}
			EventRankingsRequest.ShouldCheckCache = checkCache;

			var response = EventRankingsRequest.GetData<RawRanking>();

			var sortOrderInfo = response.sort_order_info.ToArray();

			foreach (var ranking in response.rankings)
			{
				var gameSpecifics = new List<Ranking2019.Game_Specific>();
				gameSpecifics.AddRange(sortOrderInfo.Select((t, i2) => new Ranking2019.Game_Specific { name = t.name, precision = t.precision, value = ranking.sort_orders[i2] }));

				var teamToAdd = new Ranking2019
				{
					rank = ranking.rank,
					team_key = ranking.team_key,
					dq = ranking.dq,
					record = ranking.record,
					matches_played = ranking.matches_played,
					ranking_score = GetGameSpecificValue(gameSpecifics, "Ranking Score"),
					cargo = (int)GetGameSpecificValue(gameSpecifics, "Cargo"),
					hatch_panel = (int)GetGameSpecificValue(gameSpecifics, "Hatch Panel"),
					hab_climb = (int)GetGameSpecificValue(gameSpecifics, "HAB Climb"),
					sandstorm_bonus = (int)GetGameSpecificValue(gameSpecifics, "Sandstorm Bonus")
				};
				teamList.Add(teamToAdd);
			}

			return teamList.ToArray();
		}

		private static double GetGameSpecificValue(IEnumerable<Ranking2019.Game_Specific> specifics, string name)
		{
			return specifics.First(x => x.name.Equals(name)).value;
		}

		public static ApiRequest EventsRequest { get; private set; }
		public static Event[] GetEvents(int year, bool checkCache = true)
		{
			if (EventsRequest == null)
			{
				EventsRequest = new ApiRequest($"/events/{year}");
			}
			EventsRequest.ShouldCheckCache = checkCache;

			var response = EventsRequest.GetData<List<Event>>();
			return response.ToArray();
		}

		public static ApiRequest EventTeamsRequest { get; private set; }
		public static Team[] GetEventTeamsList(string eventKey, bool checkCache = true)
		{
			if (EventTeamsRequest == null)
			{
				EventTeamsRequest = new ApiRequest($"/event/{eventKey}/teams");
			}
			EventTeamsRequest.ShouldCheckCache = checkCache;

			var response = EventTeamsRequest.GetData<List<Team>>();
			return response.ToArray();
		}
	}
}