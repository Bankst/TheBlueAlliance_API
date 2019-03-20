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
            const string expectedAlliances = "frc832";
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

            const int expectedRank = 1;
            const int expectedTeam = 2056;
            const double expectedQualAverage = 124.5;
            const int expectedAuto = 146;
            const int expectedContainer = 488;
            const int expectedCoopertition = 160;
            const int expectedLitter = 131;
            const int expectedTote = 338;
            const int expectedPlayed = 10;

            Assert.AreEqual(expectedRank, actualEventRankings[0].Rank, "Ranks are not as expected");
            Assert.AreEqual(expectedTeam, actualEventRankings[0].Team_Number, "Team Numbers are not as expected");
            Assert.AreEqual(expectedQualAverage, actualEventRankings[0].Qual_Average, "Qualification Averages are not as expected");
            Assert.AreEqual(expectedAuto, actualEventRankings[0].Auto, "Auto Points are not as expected");
            Assert.AreEqual(expectedContainer, actualEventRankings[0].Container, "Container Points are not as expected");
            Assert.AreEqual(expectedCoopertition, actualEventRankings[0].Coopertition, "Coopertition Points are not as expected");
            Assert.AreEqual(expectedLitter, actualEventRankings[0].Litter, "Litter Points are not as expected");
            Assert.AreEqual(expectedTote, actualEventRankings[0].Tote, "Tote Points are not as expected");
            Assert.AreEqual(expectedPlayed, actualEventRankings[0].Played, "Matches Played are not as expected");
        }

        [TestMethod]
        public void GetEvents_TestMethod()
        {
            var actualEvents = Events.GetEvents(2015);

            const string expectedKey = "2015abca";
            const string expectedWebsite = "http://frcwest.com/";
            const bool expectedOfficial = true;
            const string expectedEndDate = "2015-04-04";
            const string expectedName = "Western Canada Regional";
            const string expectedShortName = "Western Canada";
            const object expectedFaceBookEid = null;
            const object expectedEventDistrictString = null;
            const string expectedVenueAddress = "Ernest Manning High School\n20 Springborough Blvd SW\nCalgary, AB T3H 0N7\nCanada";
            const int expectedEventDistrict = 0;
            const string expectedLocation = "Calgary, AB, Canada";
            const string expectedEventCode = "abca";
            const int expectedYear = 2015;
            const string expectedAlliances0Pick1 = "frc4719";
            const string expectedEventTypeString = "Regional";
            const string expectedStartDate = "2015-04-01";
            const int expectedEventType = 0;

            Assert.AreEqual(expectedKey, actualEvents[0].key, "Event Keys are not as expected");
            Assert.AreEqual(expectedWebsite, actualEvents[0].website, "Websites are not as expected");
            Assert.AreEqual(expectedEndDate, actualEvents[0].end_date, "End Dates are not as expected");
            Assert.AreEqual(expectedName, actualEvents[0].name, "Names are not as expected");
            Assert.AreEqual(expectedShortName, actualEvents[0].short_name, "Short Name are not as expected");
            Assert.AreEqual(expectedEventDistrictString, actualEvents[0].district.display_name, "District Strings are not as expected");
            Assert.AreEqual(expectedVenueAddress, actualEvents[0].address, "Venue Addresses are not as expected");
            Assert.AreEqual(expectedLocation, actualEvents[0].location_name, "Locations are not as expected");
            Assert.AreEqual(expectedEventCode, actualEvents[0].event_code, "Event Codes are not as expected");
            Assert.AreEqual(expectedYear, actualEvents[0].year, "Years are not as expected");
            // Assert.AreEqual(expectedAlliances0Pick1, actualEvents[0].alliances[0].picks[0], "Alliance Picks are not as expected");
            Assert.AreEqual(expectedEventTypeString, actualEvents[0].event_type_string, "Event Type Strings are not as expected");
            Assert.AreEqual(expectedStartDate, actualEvents[0].start_date, "Start Dates are not as expected");
            Assert.AreEqual(expectedEventType, actualEvents[0].event_type, "Event Types are not as expected");
        }

        [TestMethod]
        public void GetEventTeamsList_TestMethod()
        {
            var actualTeamList = Events.GetEventTeamsList("2015onto");
            var expectedWebsite = "http://www.cyberfalcons.com";
            var expectedTeamName = "Novelis  / Limestone Learning Foundation  / Queen's University / Transformix Engineering / Haakon Industries & Frontenac Secondary School";
            var expectedLocality = "Kingston";
            var expectedRookieYear = 2011;
            var expectedRegion = "Ontario";
            var expectedTeamNumber = 3710;
            var expectedLocation = "Kingston, Ontario, Canada";
            var expectedKey = "frc3710";
            var expectedCountryName = "Canada";
            var expectedNickName = "FSS Cyber Falcons";
            Assert.AreEqual(expectedWebsite, actualTeamList[20].website, "Team websites are not as expected!");
            Assert.AreEqual(expectedTeamName, actualTeamList[20].name, "Team names are not as expected!");
            Assert.AreEqual(expectedLocality, actualTeamList[20].locality, "Localities are not as expected!");
            Assert.AreEqual(expectedRookieYear, actualTeamList[20].rookie_year, "Rookie years are not as expected!");
            Assert.AreEqual(expectedRegion, actualTeamList[20].region, "Regions are not as expected!");
            Assert.AreEqual(expectedTeamNumber, actualTeamList[20].team_number, "Team numbers are not as expected!");
            Assert.AreEqual(expectedLocation, actualTeamList[20].location, "Locations are not as expected!");
            Assert.AreEqual(expectedKey, actualTeamList[20].key, "Keys are not as expected!");
            Assert.AreEqual(expectedCountryName, actualTeamList[20].country_name, "Country names are not as expected!");
            Assert.AreEqual(expectedNickName, actualTeamList[20].nickname, "Nicknames are not as expected!");
        }
    }
}