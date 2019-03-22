namespace TheBlueAlliance.SpecificModels
{
	public class Match2019
	{
		public int             actual_time      { get; set; }
		public Alliances       alliances        { get; set; }
		public string          comp_level       { get; set; }
		public string          event_key        { get; set; }
		public string          key              { get; set; }
		public int             match_number     { get; set; }
		public int             post_result_time { get; set; }
		public int             predicted_time   { get; set; }
		public Score_Breakdown score_breakdown  { get; set; }
		public int             set_number       { get; set; }
		public int             time             { get; set; }
		public Video[]         videos           { get; set; }
		public string          winning_alliance { get; set; }
	}

	public class Alliances
	{
		public Alliance blue { get; set; }
		public Alliance red  { get; set; }
	}

	public class Alliance
	{
		public object[] dq_team_keys        { get; set; }
		public int      score               { get; set; }
		public object[] surrogate_team_keys { get; set; }
		public string[] team_keys           { get; set; }
	}

	public class Score_Breakdown
	{
		public Score blue { get; set; }
		public Score red  { get; set; }
	}

	public class Score
	{
		public int    adjustPoints               { get; set; }
		public int    autoPoints                 { get; set; }
		public string bay1                       { get; set; }
		public string bay2                       { get; set; }
		public string bay3                       { get; set; }
		public string bay4                       { get; set; }
		public string bay5                       { get; set; }
		public string bay6                       { get; set; }
		public string bay7                       { get; set; }
		public string bay8                       { get; set; }
		public int    cargoPoints                { get; set; }
		public bool   completeRocketRankingPoint { get; set; }
		public bool   completedRocketFar         { get; set; }
		public bool   completedRocketNear        { get; set; }
		public string endgameRobot1              { get; set; }
		public string endgameRobot2              { get; set; }
		public string endgameRobot3              { get; set; }
		public int    foulCount                  { get; set; }
		public int    foulPoints                 { get; set; }
		public int    habClimbPoints             { get; set; }
		public bool   habDockingRankingPoint     { get; set; }
		public string habLineRobot1              { get; set; }
		public string habLineRobot2              { get; set; }
		public string habLineRobot3              { get; set; }
		public int    hatchPanelPoints           { get; set; }
		public string lowLeftRocketFar           { get; set; }
		public string lowLeftRocketNear          { get; set; }
		public string lowRightRocketFar          { get; set; }
		public string lowRightRocketNear         { get; set; }
		public string midLeftRocketFar           { get; set; }
		public string midLeftRocketNear          { get; set; }
		public string midRightRocketFar          { get; set; }
		public string midRightRocketNear         { get; set; }
		public string preMatchBay1               { get; set; }
		public string preMatchBay2               { get; set; }
		public string preMatchBay3               { get; set; }
		public string preMatchBay6               { get; set; }
		public string preMatchBay7               { get; set; }
		public string preMatchBay8               { get; set; }
		public string preMatchLevelRobot1        { get; set; }
		public string preMatchLevelRobot2        { get; set; }
		public string preMatchLevelRobot3        { get; set; }
		public int    rp                         { get; set; }
		public int    sandStormBonusPoints       { get; set; }
		public int    techFoulCount              { get; set; }
		public int    teleopPoints               { get; set; }
		public string topLeftRocketFar           { get; set; }
		public string topLeftRocketNear          { get; set; }
		public string topRightRocketFar          { get; set; }
		public string topRightRocketNear         { get; set; }
		public int    totalPoints                { get; set; }
	}

	public class Video
	{
		public string key  { get; set; }
		public string type { get; set; }
	}
}