using System.Collections.Generic;
using System.Linq;
using TheBlueAlliance.MainModels;
using TheBlueAlliance.SpecificModels;

namespace TheBlueAlliance
{
	public class Events
	{
		private static ApiRequest _eventInformationRequest;
		public static Event GetEventInformation(string eventKey)
		{
			if (_eventInformationRequest == null)
			{
				_eventInformationRequest = new ApiRequest($"/event/{eventKey}");
			}

			var response = _eventInformationRequest.GetData<Event>();
			return response;
		}

		private static ApiRequest _eventAwardsRequest;
		public static Award[] GetEventAwards(string eventKey)
		{
			if (_eventAwardsRequest == null)
			{
				_eventAwardsRequest = new ApiRequest($"/event/{eventKey}/awards");
			}

			var response = _eventAwardsRequest.GetData<Award[]>();
			return response.ToArray();
		}

		private static ApiRequest _eventMatchesRequest;
		public static Match[] GetEventMatches(string eventKey)
		{
			if (_eventMatchesRequest == null)
			{
				_eventMatchesRequest = new ApiRequest($"/event/{eventKey}/matches");
			}

			var response = _eventMatchesRequest.GetData<Match[]>();
			return response.ToArray();
		}

		private static ApiRequest _eventRankingsRequest;
		public static Ranking2019[] GetEventRankings(string eventKey)
		{
			var teamList = new List<Ranking2019>();

			if (_eventRankingsRequest == null)
			{
				_eventRankingsRequest = new ApiRequest($"/event/{eventKey}/rankings");
			}

			var response = _eventRankingsRequest.GetData<RawRanking>();

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

		private static ApiRequest _eventsRequest;
		public static Event[] GetEvents(int year)
		{
			if (_eventsRequest == null)
			{
				_eventsRequest = new ApiRequest($"/events/{year}");
			}

			var response = _eventsRequest.GetData<List<Event>>();
			return response.ToArray();
		}

		private static ApiRequest _eventTeamsRequest;
		public static Team[] GetEventTeamsList(string eventKey)
		{
			if (_eventTeamsRequest == null)
			{
				_eventTeamsRequest = new ApiRequest($"/event/{eventKey}/teams");
			}

			var response = _eventTeamsRequest.GetData<List<Team>>();
			return response.ToArray();
		}
	}
}