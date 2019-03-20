using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TheBlueAlliance.Tests
{
    [TestClass]
    public class TeamsUnitTests
    {
        [TestMethod]
        public void GetTeamEventAwardsTest()
        {
            var actualInformation = Teams.GetTeamEventAwards("frc832", "2019gaalb");

            const string expectedEventKey = "2019gaalb";
            const int expectedAwardType = 1;
            const string expectedName = "District Event Winner";
            const string expectedRecipientNumber0 = "frc832";
            const string expectedRecipientNumber1 = "frc6829";
            const string expectedRecipientNumber2 = "frc7499";
            const int expectedYear = 2019;

            Assert.AreEqual(expectedEventKey, actualInformation[0].event_key);
            Assert.AreEqual(expectedAwardType, actualInformation[0].award_type);
            Assert.AreEqual(expectedName, actualInformation[0].name);
            Assert.AreEqual(expectedRecipientNumber0, actualInformation[0].recipient_list[0].team_key);
            Assert.AreEqual(expectedRecipientNumber1, actualInformation[0].recipient_list[1].team_key);
            Assert.AreEqual(expectedRecipientNumber2, actualInformation[0].recipient_list[2].team_key);
            Assert.AreEqual(expectedYear, actualInformation[0].year);
        }

        [TestMethod]
        public void GetTeamEventsTest()
        {
            var actualInformation = Teams.GetTeamEvents("frc832", 2019);

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
            const string expectedWebcastType = "twitch";
            const string expectedWebcastChannel = "gafirst1";
            const string expectedEventTypeString = "District";
            const string expectedStartDate = "2019-03-14";
            const int expectedEventType = 1;

            Assert.AreEqual(expectedKey, actualInformation[0].key, "Key fail");
            Assert.AreEqual(expectedWebsite, actualInformation[0].website, "Website fail");
            // Assert.AreEqual(expectedOfficial, actualInformation[0].official, "official fail");
            Assert.AreEqual(expectedEndDate, actualInformation[0].end_date, "End date fail");
            Assert.AreEqual(expectedName, actualInformation[0].name);
            Assert.AreEqual(expectedShortName, actualInformation[0].short_name);
            Assert.AreEqual(expectedEventDistrictString, actualInformation[0].district.display_name);
            Assert.AreEqual(expectedVenueAddress, actualInformation[0].address);
            Assert.AreEqual(expectedLocation, actualInformation[0].location_name);
            Assert.AreEqual(expectedEventCode, actualInformation[0].event_code);
            Assert.AreEqual(expectedYear, actualInformation[0].year);
            Assert.AreEqual(expectedWebcastType, actualInformation[0].webcasts[0].type);
            Assert.AreEqual(expectedWebcastChannel, actualInformation[0].webcasts[0].channel);
            Assert.AreEqual(expectedEventTypeString, actualInformation[0].event_type_string);
            Assert.AreEqual(expectedStartDate, actualInformation[0].start_date);
            Assert.AreEqual(expectedEventType, actualInformation[0].event_type);
        }

        [TestMethod]
        public void GetTeamHistoricalAwardsTest()
        {
            var actualInformation = Teams.GetTeamHistoricalAwards("frc832");

            var expectedEventKey = "2002cmp";
            var expectedAwardType = 10;
            var expectedAwardName = "Rookie All-Star";
			const string expectedRecipientNumber0 = "frc818";
			const string expectedRecipientNumber1 = "frc832";
			var expectedYear = 2002;

            Assert.AreEqual(expectedEventKey, actualInformation[0].event_key);
            Assert.AreEqual(expectedAwardType, actualInformation[0].award_type);
            Assert.AreEqual(expectedAwardName, actualInformation[0].name);
			Assert.AreEqual(expectedRecipientNumber0, actualInformation[0].recipient_list[0].team_key);
			Assert.AreEqual(expectedRecipientNumber1, actualInformation[0].recipient_list[1].team_key);
			Assert.AreEqual(expectedYear, actualInformation[0].year);
        }

        [TestMethod]
        public void GetTeamHistoryEventsTest()
        {
            var actualEventInformation = Teams.GetTeamHistoryEvents("frc832");

            const string expectedKey = "2017gagai";
            const string expectedWebsite = "http://www.gafirst.org";
            const string expectedEndDate = "2011-04-02";
            const string expectedName = "Greater Toronto West Regional";
            const string expectedShortName = "Greater Toronto West";
            const string expectedEventDistrictString = "Peachtree";
            const string expectedVenueAddress = "";
            const string expectedLocation = "Riverside Military Academy";
            const string expectedEventCode = "on2";
            const int expectedYear = 2017;
            const string expectedEventTypeString = "District";
            const string expectedStartDate = "2017-03-01";
            const int expectedEventType = 0;

            Assert.AreEqual(expectedKey, actualEventInformation[0].key, "Event Keys are not as expected");
            Assert.AreEqual(expectedWebsite, actualEventInformation[0].website, "Websites are not as expected");
            Assert.AreEqual(expectedEndDate, actualEventInformation[0].end_date, " are not as expected");
            Assert.AreEqual(expectedName, actualEventInformation[0].name, "Event Names are not as expected");
            Assert.AreEqual(expectedShortName, actualEventInformation[0].short_name, "Short Names are not as expected");
            Assert.AreEqual(expectedEventDistrictString, actualEventInformation[0].district.display_name, "Event District Strings are not as expected");
            Assert.AreEqual(expectedVenueAddress, actualEventInformation[0].address, "Venue Addresses are not as expected");
            Assert.AreEqual(expectedLocation, actualEventInformation[0].location_name, "Locations are not as expected");
            Assert.AreEqual(expectedEventCode, actualEventInformation[0].event_code, "Event Codes are not as expected");
            Assert.AreEqual(expectedYear, actualEventInformation[0].year, "Years are not as expected");
            Assert.AreEqual(expectedEventTypeString, actualEventInformation[0].event_type_string, "Event Type Strings are not as expected");
            Assert.AreEqual(expectedStartDate, actualEventInformation[0].start_date, "Start Dates are not as expected");
            Assert.AreEqual(expectedEventType, actualEventInformation[0].event_type, "Event Types are not as expected");
        }

        [TestMethod]
        public void GetTeamInformationTest()
        {
            var actualInformation = Teams.GetTeamInformation("frc3710");

            var expectedWebsite = "http://www.cyberfalcons.com";
            var expectedName = "Novelis  / Limestone Learning Foundation  / Queen's University / Transformix Engineering / Haakon Industries & Frontenac Secondary School";
            var expectedLocality = "Kingston";
            var expectedRookieYear = 2011;
            var expectedRegion = "Ontario";
            var expectedTeamNumber = 3710;
            var expectedLocation = "Kingston, Ontario, Canada";
            var expectedKey = "frc3710";
            var expectedCountryName = "Canada";
            var expectedNickname = "FSS Cyber Falcons";

            Assert.AreEqual(expectedWebsite, actualInformation.website);
            Assert.AreEqual(expectedName, actualInformation.name);
            Assert.AreEqual(expectedLocality, actualInformation.locality);
            Assert.AreEqual(expectedRookieYear, actualInformation.rookie_year);
            Assert.AreEqual(expectedRegion, actualInformation.region);
            Assert.AreEqual(expectedTeamNumber, actualInformation.team_number);
            Assert.AreEqual(expectedLocation, actualInformation.location);
            Assert.AreEqual(expectedKey, actualInformation.key);
            Assert.AreEqual(expectedCountryName, actualInformation.country_name);
            Assert.AreEqual(expectedNickname, actualInformation.nickname);
        }

        [TestMethod]
        public void GetTeamMediaLocationsTest()
        {
            var actualInformation = Teams.GetTeamMediaLocations("frc254", 2014);

            var expectedType = "cdphotothread";
            var expectedDetails = "fe3/fe38d320428adf4f51ac969efb3db32c_l.jpg";
            var expectedForeignKey = "39894";

            Assert.AreEqual(expectedType, actualInformation[0].type);
            Assert.AreEqual(expectedDetails, actualInformation[0].details.image_partial);
            Assert.AreEqual(expectedForeignKey, actualInformation[0].foreign_key);
        }
    }
}