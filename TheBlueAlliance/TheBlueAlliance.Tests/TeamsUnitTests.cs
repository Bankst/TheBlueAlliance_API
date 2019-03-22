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

            var expectedType = "avatar";
            var expectedDetails = @"iVBORw0KGgoAAAANSUhEUgAAACgAAAAoCAYAAACM/rhtAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAWGSURBVFhHzVZJbxxFGE0ik8x4jxPZCbbHnrFnxtOzehmvwRkvs3kWB9tJOCBFSFyBCxJiufAvuHPjxBEJYSVWfOTAAfEn4AdEOXzUq66vp6pds4UI5UnPVf36fUtVV0/7mgD9nwRsegdaRSv7Td6vvw3dyVtK1hd7rGkVJXtM4LFfv42WHMZFT7QkucJePD3SKr5V6tA13dOBpuCHTfPDn8NPIHs4K0fAf4+h6xrdCRuAqeQ4RXZaCYHmcZ2Wm3OUiI7S9kyAnNAIpZshdbd9UUa+GqbU0Yy6MjHtTMpRz6HRFIC1szgdLg5SfuWOvN44SdJRbJzKToAqiRFqLg7RUXxIerbXzYUwIs5tSpUWZc7w9n16GAnQXnWaJmNjtBMO0Gb4FmWKYQpl7tHW7rKM8feiaApAtVmgQnrMbWAuQEUxoqF2LESD5NQjMhaIzQ5QWez07mcZWlm6RYcRe3wlfpOq8VGaGn1PRVqbbF0w8o8XaF/smC2pn6WlYbGzw7Q1P6iiRfzcLakVnRHRQMtbjZqx5aUglTBfGqHdB+5jZmh9mc198HCWDmJBI1EvLIpdWj6NUS7Rfcf9rMVEfGyQyqEBytTmZR/WBtNHYSokhqmUEIGxYS9BVRSsi3N39t06nX29TpX1CbF6swgIj1+riFjw46/WqPHtDjWfLclYaJ5HNFeJByiaGKD6cUX2wjAaXH0Sp1jSV0Q0Wvtimf7463fpYeSPI/Tn+c/yERt+pnich2KxNqSKIapt3rPGFkTjqY8WKHukdlL+Vdg4jcizU+PdWxyhp59k1V07Uo1J2goHqbYQlDtRFkUxNhaGqPn9inLZUV6duNIgnh7id75M0f5+wW0w9ShMD8TjORBF9IOMIvOZuzIZY2BggM+GUlw0vsnLR1eKD9LJpw79+NMPUmfv9evX5bWOOylzB1H7WLzV5ewQxZwhmhAvmayychqiubEbdKAKcMCz6tUd4IJMRqYQpz2x4uOTCk2l9Z+NG5r/hlJbqG/OiVrmS1mMBCmZvi3vywpp8Qu/K34mqmJrdWNk95406dCb0wtGU62vyn61oGam37aLd8UPdlEcqwpeTnE8iuKprdW0z6Iaaa2QpK2TRdrYCFHJmaLM8gytijP58vm5crhwd4TZ2sHoTmsx4zHbD6/pB15e/Er3N0dp7cMoZZ9GxM6LD8Oe+1UBVKwZ5EemMU2Xl5fqyo6Li1/IOZxWV+LIHEW7xgDxvHm+dajm3AZt1JHLJ9XsKtBIrha6EhNZmezY5OWLC0pmF+TcX9vH1oXNDKSzKao3KmKnzun1q7/p1at/aGr+JjUeH4jfq2nP50e2PkPPX/ymrlyg6dTyIiVWY0rpo0GwE9KbDs2uj9L7uTHKPXC6+oHMhkNrT6KUexwS/yVNi1j37WwHvQ81v9ogVodmRnaCHlefhGjscFDqgO4f3ghID+7BxzHQAd2bezTj5WMf5ryj7NVoCgCC0AxGvdHNUl6OgO5Hcn9BeDEC7AN4MUzkt+XVaAoAF6PXrw16uoDut4GLA714/YvhGEFTABDADXq6mPsTtSPg5RCweZgAcvoXo9EUAJhlgLZ73CAXBdhvA+L9DbYDfB0WbgoAAmxnsNtLwjuBkeOBTl7O6/dqNAUA5v3P414ijEjWrkF8bbiY7sUc0L24x7lBbhQ5APZqNAWAgzs9Yt1vAy8MsOZuA/Z69IsAEqAAmvJ0MYcmdQE9xk+AdwbopnehKQDeKrXdA/XV634b0ITNq+ewQfequSswAawSZwgjJwRZA3S//iVhL58zwJ+bf5hBrtHXlwRmTtAtEaC/JPDxXD/4DP7qcD6b10dT6BX9+N/Uq+au8A7TnWgd98R+/f+BVtFjv4108re7105XtIrvCK/Rv9LUM6RvgyBDAAAAAElFTkSuQmCC";
            var expectedForeignKey = "avatar_2019_frc832";

            Assert.AreEqual(expectedType, actualInformation[0].type);
            Assert.AreEqual(expectedDetails, actualInformation[0].details.base64Image);
            Assert.AreEqual(expectedForeignKey, actualInformation[0].foreign_key);
        }
    }
}