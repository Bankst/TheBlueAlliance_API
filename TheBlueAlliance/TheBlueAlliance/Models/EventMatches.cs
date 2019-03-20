namespace TheBlueAlliance.Models
{
    public class EventMatches
    {
        public class Alliances
        {
            public Alliance blue { get; set; }
            public Alliance red { get; set; }
        }

        public class Score
        {
            public int teleopPoints { get; set; }
            public int autoPoints { get; set; }
            public int foulPoints { get; set; }
            public int totalPoints { get; set; }
            public int autoRotorPoints { get; set; }
            public int adjustPoints { get; set; }
            public int teleopRotorPoints { get; set; }
            public int autoFuelHigh { get; set; }
            public int teleopFuelHigh { get; set; }
            public int teleopTakeoffPoints { get; set; }
            public bool kPaRankingPointAchieved { get; set; }
            public int autoFuelLow { get; set; }
            public int teleopFuelLow { get; set; }
            public int rotorBonusPoints { get; set; }
            public int autoMobilityPoints { get; set; }
            public int autoFuelPoints { get; set; }
            public int teleopFuelPoints { get; set; }
            public bool rotorRankingPointAchieved { get; set; }
            public int kpaBonusPoints { get; set; }
        }

        public class Alliance
        {
			public string[] dq_team_keys { get; set; }
            public int score { get; set; }
			public string[] surrogate_team_keys { get; set; }
            public string[] team_keys { get; set; }
        }

        public class Match
        {
            public string comp_level { get; set; }
            public int match_number { get; set; }
            public object[] videos { get; set; }
            public object time_string { get; set; }
            public int set_number { get; set; }
            public string key { get; set; }
            public int time { get; set; }
            public Score_Breakdown score_breakdown { get; set; }
            public Alliances alliances { get; set; }
            public string event_key { get; set; }
        }

        public class Score_Breakdown
        {
            public Score blue { get; set; }
            public Score red { get; set; }
        }
    }
}