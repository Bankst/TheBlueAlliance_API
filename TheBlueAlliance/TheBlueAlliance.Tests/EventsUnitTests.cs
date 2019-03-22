using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TheBlueAlliance.Tests
{
    [TestClass]
    public class EventsUnitTests
    {
        [TestMethod]
        public void GetEventInformation_TestMethod()
        {
            var actualEventInformation = Events.GetEventInformation("2019gaalb");

            const string expectedAddress = "100 W Oglethorpe Blvd, Albany, GA 31701, USA";
			const string expectedCity = "Albany";
			const string expectedCountry = "USA";
            const string expectedEventDistrictString = "Peachtree";
			const string expectedKey = "2019gaalb";
            const string expectedEndDate = "2019-03-16";
            const string expectedName = "PCH District Albany Event presented by Procter & Gamble";
            const string expectedShortName = "Albany presented by Procter & Gamble";
            const string expectedLocation = "Albany Civic Center";
            const string expectedEventCode = "gaalb";
            const int expectedEventType = 1;
			const string expectedEventTypeString = "District";
            const string expectedStartDate = "2019-03-14";
            const string expectedWebcasts = "twitch";
			const string expectedWebsite = "http://www.gafirst.org";
			const int expectedWeek = 2;
			const int expectedYear = 2019;


			Assert.AreEqual(expectedKey, actualEventInformation.key, "Event Keys are not as expected");
            Assert.AreEqual(expectedWebsite, actualEventInformation.website, "Websites are not as expected");
            Assert.AreEqual(expectedEndDate, actualEventInformation.end_date, " are not as expected");
            Assert.AreEqual(expectedName, actualEventInformation.name, "Event Names are not as expected");
            Assert.AreEqual(expectedShortName, actualEventInformation.short_name, "Short Names are not as expected");
            Assert.AreEqual(expectedEventDistrictString, actualEventInformation.district.display_name, "Event District Strings are not as expected");
            Assert.AreEqual(expectedAddress, actualEventInformation.address, "Venue Addresses are not as expected");
            Assert.AreEqual(expectedLocation, actualEventInformation.location_name, "Locations are not as expected");
            Assert.AreEqual(expectedEventCode, actualEventInformation.event_code, "Event Codes are not as expected");
            Assert.AreEqual(expectedYear, actualEventInformation.year, "Years are not as expected");
            Assert.AreEqual(expectedWebcasts, actualEventInformation.webcasts[0].type, "Webcasts are not as expected");
            Assert.AreEqual(expectedEventTypeString, actualEventInformation.event_type_string, "Event Type Strings are not as expected");
            Assert.AreEqual(expectedStartDate, actualEventInformation.start_date, "Start Dates are not as expected");
            Assert.AreEqual(expectedEventType, actualEventInformation.event_type, "Event Types are not as expected");
            Assert.AreEqual(expectedWeek, actualEventInformation.week, "Week are not as expected");
            Assert.AreEqual(expectedCity, actualEventInformation.city, "City are not as expected");
            Assert.AreEqual(expectedCountry, actualEventInformation.country, "Country are not as expected");
		}

        [TestMethod]
        public void GetEventAwards_TestMethod()
        {
            var actualAwardsInformation = Events.GetEventAwards("2019gaalb");

            var actualEventKey = actualAwardsInformation[0].event_key;
            var actualAwardType = actualAwardsInformation[0].award_type;
            var actualAwardName = actualAwardsInformation[0].name;
            var actualAwardRecipientListTeamNumber = actualAwardsInformation[0].recipient_list[0].team_key;
            object actualAwardRecipientListAwardee = actualAwardsInformation[0].recipient_list[0].awardee;
            var actualYear = actualAwardsInformation[0].year;

            const string expectedEventKey = "2019gaalb";
            const int expectedAwardType = 0;
            const string expectedAwardName = "District Chairman's Award";
            const string expectedAwardRecipientListTeamNumber = "frc1002";
            const object expectedAwardRecipientListAwardee = null;
            const int expectedYear = 2019;

            Assert.AreEqual(expectedEventKey, actualEventKey, "Event Keys are not as expected");
            Assert.AreEqual(expectedAwardType, actualAwardType, "Award Types are not as expected");
            Assert.AreEqual(expectedAwardName, actualAwardName, "Event Awards are not as expected");
            Assert.AreEqual(expectedAwardRecipientListTeamNumber, actualAwardRecipientListTeamNumber, "Award Team Numbers are not as expected");
            Assert.AreEqual(expectedAwardRecipientListAwardee, actualAwardRecipientListAwardee, "Recipient List Awardee are not as expected");
            Assert.AreEqual(expectedYear, actualYear, "Years are not as expected");
        }

        [TestMethod]
        public void GetEventMatches_TestMethod()
        {
            var actualEventMatches = Events.GetEventMatches("2019gaalb");

            const string expectedCompLevel = "f";
            const int expectedMatchNumber = 1;
            const string expectedTimeString = null;
            const int expectedSetNumber = 1;
            const string expectedKey = "2019gaalb_f1m1";
            const int expectedTime = 1552763160;
            const int expectedAlliancesRedScore = 62;
            const string expectedAllianceRedTeam2 = "frc832";

            Assert.AreEqual(expectedCompLevel, actualEventMatches[0].comp_level, "Comp Levels are not as expected");
            Assert.AreEqual(expectedMatchNumber, actualEventMatches[0].match_number, "Match Numbers are not as expected");
            Assert.AreEqual(expectedTimeString, actualEventMatches[0].time_string, "Time Strings are not as expected");
            Assert.AreEqual(expectedSetNumber, actualEventMatches[0].set_number, "Set Numbers are not as expected");
            Assert.AreEqual(expectedKey, actualEventMatches[0].key, "Keys are not as expected");
            Assert.AreEqual(expectedTime, actualEventMatches[0].time, "Times are not as expected");
            Assert.AreEqual(expectedAlliancesRedScore, actualEventMatches[0].alliances.red.score, "Scores are not as expected");
            Assert.AreEqual(expectedAllianceRedTeam2, actualEventMatches[0].alliances.red.team_keys[1], "Alliance Teams are not as expected");
        }

        [TestMethod]
        public void GetEventRankings_TestMethod()
        {
            var actualEventRankings = Events.GetEventRankings("2019gaalb");

			var teamRankings = actualEventRankings.First(x => x.team_key.Equals("frc832"));

            const int expectedRank = 1;
			const double expectedRankingScore = 2.58;
            const string expectedTeam = "frc832";
			const int expectedCargo = 228;
			const int expectedHatchPanel = 54;
			const int expectedHabClimb = 189;
            const int expectedSandstorm = 114;
            const int expectedPlayed = 12;
			const int expectedDq = 0;

			Assert.AreEqual(expectedRank, teamRankings.rank, "Rank are not as expected");
			Assert.AreEqual(expectedRankingScore, teamRankings.ranking_score, "Ranking Score are not as expected");
            Assert.AreEqual(expectedTeam, teamRankings.team_key, "Team Numbers are not as expected");
            Assert.AreEqual(expectedCargo, teamRankings.cargo, "Cargo are not as expected");
			Assert.AreEqual(expectedHatchPanel, teamRankings.hatch_panel, "Hatch Panel are not as expected");
			Assert.AreEqual(expectedHabClimb, teamRankings.hab_climb, "HAB Climb are not as expected");
			Assert.AreEqual(expectedSandstorm, teamRankings.sandstorm_bonus, "Sandstorm Bonus are not as expected");
			Assert.AreEqual(expectedPlayed, teamRankings.matches_played, "Matches Played are not as expected");
			Assert.AreEqual(expectedDq, teamRankings.dq, "DQ are not as expected");
		}

        [TestMethod]
        public void GetEvents_TestMethod()
        {
            var actualEvents = Events.GetEvents(2019);

            var actualEvent = actualEvents.First(x => x.key.Equals("2019gaalb"));

            const string expectedKey = "2019gaalb";
            const string expectedWebsite = "http://www.gafirst.org";
            const string expectedEndDate = "2019-03-16";
            const string expectedName = "PCH District Albany Event presented by Procter & Gamble";
            const string expectedShortName = "Albany presented by Procter & Gamble";
            const string expectedEventDistrictString = "Peachtree";
            const string expectedVenueAddress = "100 W Oglethorpe Blvd, Albany, GA 31701, USA";
            const string expectedLocation = "Albany Civic Center";
            const string expectedEventCode = "gaalb";
            const int expectedYear = 2019;
            const string expectedEventTypeString = "District";
            const string expectedStartDate = "2019-03-14";
            const int expectedEventType = 1;

            Assert.AreEqual(expectedKey, actualEvent.key, "Event Keys are not as expected");
            Assert.AreEqual(expectedWebsite, actualEvent.website, "Websites are not as expected");
            Assert.AreEqual(expectedEndDate, actualEvent.end_date, "End Dates are not as expected");
            Assert.AreEqual(expectedName, actualEvent.name, "Names are not as expected");
            Assert.AreEqual(expectedShortName, actualEvent.short_name, "Short Name are not as expected");
            Assert.AreEqual(expectedEventDistrictString, actualEvent.district.display_name, "District Strings are not as expected");
            Assert.AreEqual(expectedVenueAddress, actualEvent.address, "Venue Addresses are not as expected");
            Assert.AreEqual(expectedLocation, actualEvent.location_name, "Locations are not as expected");
            Assert.AreEqual(expectedEventCode, actualEvent.event_code, "Event Codes are not as expected");
            Assert.AreEqual(expectedYear, actualEvent.year, "Years are not as expected");
            Assert.AreEqual(expectedEventTypeString, actualEvent.event_type_string, "Event Type Strings are not as expected");
            Assert.AreEqual(expectedStartDate, actualEvent.start_date, "Start Dates are not as expected");
            Assert.AreEqual(expectedEventType, actualEvent.event_type, "Event Types are not as expected");
        }

        [TestMethod]
        public void GetEventTeamsList_TestMethod()
        {
            var actualTeamList = Events.GetEventTeamsList("2019gaalb");

			var team = actualTeamList.First(x => x.key.Equals("frc832"));

            const string expectedWebsite = "http://www.roswellrobotics.com";
            const string expectedTeamName = @"GE Volunteers/Siemens/Rockwell Automation/Dow Chemical/Arconic Foundation/Kennesaw State University/Novelis/Fulton County Schools&Roswell High School";
			const string expectedMotto = "Outstanding Students Creating Awesome Robots";
			const int expectedRookieYear = 2002;
			const string expectedCity = "Roswell";
			const string expectedState = "Georgia";
            const int expectedTeamNumber = 832;
            const string expectedCountry = "USA";
            const string expectedNickName = "Oscar";
            Assert.AreEqual(expectedWebsite, team.website, "Team websites are not as expected!");
            Assert.AreEqual(expectedTeamName, team.name, "Team names are not as expected!");
            Assert.AreEqual(expectedRookieYear, team.rookie_year, "Rookie years are not as expected!");
			Assert.AreEqual(expectedMotto, team.motto, "Motto are not as expected!");
			Assert.AreEqual(expectedCity, team.city, "City are not as expected!");
			Assert.AreEqual(expectedState, team.state_prov, @"State/Province are not as expected!");
            Assert.AreEqual(expectedTeamNumber, team.team_number, "Team numbers are not as expected!");
            Assert.AreEqual(expectedCountry, team.country, "Country names are not as expected!");
            Assert.AreEqual(expectedNickName, team.nickname, "Nicknames are not as expected!");
        }
    }
}