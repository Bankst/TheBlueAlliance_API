using TheBlueAlliance.Models.MainModels;

namespace TheBlueAlliance.Models.SpecificModels
{
	public class Ranking2019 : Ranking
	{
		public double ranking_score   { get; set; }
		public int cargo           { get; set; }
		public int hatch_panel     { get; set; }
		public int hab_climb       { get; set; }
		public int sandstorm_bonus { get; set; }

		public class Game_Specific
		{
			public string name      { get; set; }
			public int    precision { get; set; }
			public double value     { get; set; }
		}
	}
}
