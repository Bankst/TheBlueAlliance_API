using TheBlueAlliance.Models.MainModels;

namespace TheBlueAlliance.Models.SpecificModels
{
	public class Match2019 : Match
	{
		public new sealed class Score : Match.Score
		{
			public int sandstormPoints   { get; set; }
			public int autoHatchPanels   { get; set; }
			public int autoCargo         { get; set; }
			public int autoHabPoints     { get; set; }
			public int teleopHatchPanels { get; set; }
			public int teleopCargo       { get; set; }
			public int endgameHabPoints  { get; set; }
		}
	}
}
