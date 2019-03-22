namespace TheBlueAlliance.MainModels
{
	public class Match
	{
		public string          comp_level      { get; set; }
		public int             match_number    { get; set; }
		public Video[]         videos          { get; set; }
		public object          time_string     { get; set; }
		public int             set_number      { get; set; }
		public string          key             { get; set; }
		public int             time            { get; set; }
		public Score_Breakdown score_breakdown { get; set; }
		public Alliances       alliances       { get; set; }
		public string          event_key       { get; set; }

		public class Alliance
		{
			public int      score { get; set; }
			public string[] team_keys { get; set; }
		}

		public class Alliances
		{
			public Alliance red { get; set; }
			public Alliance blue { get; set; }
		}

		public class Score
		{
			public int teleopPoints { get; set; }
			public int autoPoints { get; set; }
			public int foulPoints { get; set; }
			public int totalPoints { get; set; }
		}

		public class Score_Breakdown
		{
			public Score red { get; set; }
			public Score blue { get; set; }
		}

		public class Video
		{
			public string type { get; set; }
			public string key { get; set; }
		}

	}
}
