namespace TheBlueAlliance.Models.MainModels
{
	public class Match
	{
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
