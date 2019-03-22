using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TheBlueAlliance.Tests
{
	[TestClass]
	public class CachingUnitTests
	{
		private const string teamKey = "frc832";
		private const int year = 2019;

		[TestMethod]
		public void CacheTeamEvents_TestMethod()
		{
			// Clear cached requests.
			ApiRequest.ClearEntireCache();

			// output irrelevant, just want it to create the cache.
			Teams.GetTeamEvents(teamKey, year, false);

			Assert.IsTrue(Teams.TeamEventsRequest.HasCached, "Failed to cache response.");
			Assert.IsTrue(Teams.TeamEventsRequest.LastModified != null, "Failed to get \"Last-Modified\" Header.");
		}

		// Test that basic caching works. Basic caching doesn't check Last-Modified!!!
		[TestMethod]
		public void GetCachedTeamEvents_TestMethod()
		{
			Teams.GetTeamEvents(teamKey, year);

			Assert.IsTrue(Teams.TeamEventsRequest.HasHitCache, "Failed to hit cached response.");
			Assert.IsTrue(Teams.TeamEventsRequest.ClearCache(), "Failed to clear cache.");
			Assert.IsFalse(Teams.TeamEventsRequest.CacheExists(), "Cached response still exists.");
		}

		// Test that the headers are working. This is full caching, with Last-Modified check.
		[TestMethod]
		public void GetCachedTeamEvents_Web_TestMethod()
		{

			Teams.GetTeamEvents(teamKey, year);

			Assert.IsTrue(Teams.TeamEventsRequest.LastModified != null);
		}

	}
}
