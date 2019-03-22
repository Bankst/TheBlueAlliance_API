using System.Linq;
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
            var actualEvents = Teams.GetTeamHistoryEvents("frc832");

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
			const string expectedWebcastType = "twitch";
			const string expectedWebcastChannel = "gafirst1";
			const string expectedEventTypeString = "District";
			const string expectedStartDate = "2019-03-14";
			const int expectedEventType = 1;

			Assert.AreEqual(expectedKey, actualEvent.key, "Event Keys are not as expected");
			Assert.AreEqual(expectedWebsite, actualEvent.website, "Websites are not as expected");
			Assert.AreEqual(expectedEndDate, actualEvent.end_date, " are not as expected");
			Assert.AreEqual(expectedName, actualEvent.name, "Event Names are not as expected");
			Assert.AreEqual(expectedShortName, actualEvent.short_name, "Short Names are not as expected");
			Assert.AreEqual(expectedEventDistrictString, actualEvent.district.display_name, "Event District Strings are not as expected");
			Assert.AreEqual(expectedVenueAddress, actualEvent.address, "Venue Addresses are not as expected");
			Assert.AreEqual(expectedLocation, actualEvent.location_name, "Locations are not as expected");
			Assert.AreEqual(expectedEventCode, actualEvent.event_code, "Event Codes are not as expected");
			Assert.AreEqual(expectedYear, actualEvent.year, "Years are not as expected");
			Assert.AreEqual(expectedWebcastType, actualEvent.webcasts[0].type, "Webcast type are not as expected");
			Assert.AreEqual(expectedWebcastChannel, actualEvent.webcasts[0].channel, "Webcast channel are not as expected");
			Assert.AreEqual(expectedEventTypeString, actualEvent.event_type_string, "Event Type Strings are not as expected");
			Assert.AreEqual(expectedStartDate, actualEvent.start_date, "Start Dates are not as expected");
			Assert.AreEqual(expectedEventType, actualEvent.event_type, "Event Types are not as expected");
		}

        [TestMethod]
        public void GetTeamInformationTest()
        {
            var actualInformation = Teams.GetTeamInformation("frc832");

            const string expectedCity = "Roswell";
            const string expectedCountry = "USA";
            const string expectedKey = "frc832";
            const string expectedMotto = "Outstanding Students Creating Awesome Robots";
            const string expectedName = @"GE Volunteers/Siemens/Rockwell Automation/Dow Chemical/Arconic Foundation/Kennesaw State University/Novelis/Fulton County Schools&Roswell High School";
            const string expectedNickName = "Oscar";
            const string expectedPostalCode = "30075";
			const string expectedWebsite = "http://www.roswellrobotics.com";
			const int expectedRookieYear = 2002;
            const string expectedState = "Georgia";
            const int expectedTeamNumber = 832;

			Assert.AreEqual(expectedWebsite, actualInformation.website);
            Assert.AreEqual(expectedName, actualInformation.name);
            Assert.AreEqual(expectedCity, actualInformation.city);
            Assert.AreEqual(expectedState, actualInformation.state_prov);
			Assert.AreEqual(expectedCountry, actualInformation.country);
            Assert.AreEqual(expectedMotto, actualInformation.motto);
            Assert.AreEqual(expectedNickName, actualInformation.nickname);
            Assert.AreEqual(expectedPostalCode, actualInformation.postal_code);
			Assert.AreEqual(expectedRookieYear, actualInformation.rookie_year);
            Assert.AreEqual(expectedTeamNumber, actualInformation.team_number);
            Assert.AreEqual(expectedKey, actualInformation.key);
		}

        [TestMethod]
        public void GetTeamMediaLocationsTest()
        {
            var actualInformation = Teams.GetTeamMedia("frc832", 2019);

            const string expectedType = "imgur";
			const string expectedDirectUrl = "https://i.imgur.com/4HPnWn6h.jpg";
			const string expectedForeignKey = "4HPnWn6";
			const bool expectedPreferred = true;

            Assert.AreEqual(expectedType, actualInformation[1].type);
            Assert.AreEqual(expectedDirectUrl, actualInformation[1].direct_url);
            Assert.AreEqual(expectedForeignKey, actualInformation[1].foreign_key);
			Assert.AreEqual(expectedPreferred, actualInformation[1].preferred);
        }
    }
}