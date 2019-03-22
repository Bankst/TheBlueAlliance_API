using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TheBlueAlliance.Tests
{
	[TestClass]
	public class MatchesUnitTests
	{
		[TestMethod]
		public void GetMatchInformation2019_TestMethod()
		{
			var actualMatchInformation = Matches.GetMatch2019("2019gaalb_f1m1");

			const string expectedCompLevel = "f";
			const int expectedMatchNumber = 1;
			const int expectedSetNumber = 1;
			const string expectedKey = "2019gaalb_f1m1";
			const int expectedTime = 1552763203;
			
			const int expectedAlliancesBlueScore = 59;
			const string expectedAlliancesBlue0 = "frc1683";
			const string expectedAlliancesBlue1 = "frc3635";
			const string expectedAlliancesBlue2 = "frc6177";

			const int expectedAlliancesRedScore = 62;
			const string expectedAlliancesRed0 = "frc6829";
			const string expectedAlliancesRed1 = "frc832";
			const string expectedAlliancesRed2 = "frc7499";

			const string expectedEventKey = "2019gaalb";

			Assert.AreEqual(expectedCompLevel, actualMatchInformation.comp_level, "Comp Levels are not as expected!");
			Assert.AreEqual(expectedMatchNumber, actualMatchInformation.match_number, "Match Numbers are not as expected!");
			Assert.AreEqual(expectedSetNumber, actualMatchInformation.set_number, "Set numbers are not as expected!");
			Assert.AreEqual(expectedKey, actualMatchInformation.key, "Keys are not as expected!");
			Assert.AreEqual(expectedTime, actualMatchInformation.actual_time, "Times are not as expected!");

			Assert.AreEqual(expectedAlliancesBlueScore, actualMatchInformation.score_breakdown.blue.totalPoints);

			Assert.AreEqual(expectedAlliancesRedScore, actualMatchInformation.score_breakdown.red.totalPoints);

			Assert.AreEqual(expectedAlliancesBlueScore, actualMatchInformation.alliances.blue.score, "Blue total Score is not as expected!");
			Assert.AreEqual(expectedAlliancesBlue0, actualMatchInformation.alliances.blue.team_keys[0], "Blue team Alliances are not as expected!");
			Assert.AreEqual(expectedAlliancesBlue1, actualMatchInformation.alliances.blue.team_keys[1], "Blue team Alliances are not as expected!");
			Assert.AreEqual(expectedAlliancesBlue2, actualMatchInformation.alliances.blue.team_keys[2], "Blue team Alliances are not as expected!");
			Assert.AreEqual(expectedAlliancesRedScore, actualMatchInformation.alliances.red.score, "Red total Score is not as expected!");
			Assert.AreEqual(expectedAlliancesRed0, actualMatchInformation.alliances.red.team_keys[0], "Red team Alliances are not as expected!");
			Assert.AreEqual(expectedAlliancesRed1, actualMatchInformation.alliances.red.team_keys[1], "Red team Alliances are not as expected!");
			Assert.AreEqual(expectedAlliancesRed2, actualMatchInformation.alliances.red.team_keys[2], "Red team Alliances are not as expected!");

			Assert.AreEqual(expectedEventKey, actualMatchInformation.event_key, "Event keys are not as expected!");
		}
	}
}