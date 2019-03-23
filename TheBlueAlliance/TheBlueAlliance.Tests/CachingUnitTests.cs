using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TheBlueAlliance.Tests
{
	[TestClass]
	public class CachingUnitTests
	{
		private const string TeamKey = "frc832";
		private const int Year = 2019;
		
		// Test that the headers are working. This is full caching, with Last-Modified check.
		[TestMethod]
		public void GetTeamEvents_ThenCacheAndGet_TestMethod()
		{
			// Clear cached requests.
			ApiRequest.ClearEntireCache();

			// output irrelevant, just want it to create the cache.
			Teams.GetTeamEvents(TeamKey, Year, false);

			Assert.IsTrue(Teams.TeamEventsRequest.CacheExists(), "Failed to cache response.");
			Assert.IsTrue(Teams.TeamEventsRequest.LastModified != null, "Failed to get \"Last-Modified\" Header.");


			// should now hit the previously created cache
			Teams.GetTeamEvents(TeamKey, Year);

			Assert.IsTrue(Teams.TeamEventsRequest.HasHitCache, "Failed to hit cached response.");
			Assert.IsTrue(Teams.TeamEventsRequest.ClearCache(), "Failed to clear cache.");
			Assert.IsFalse(Teams.TeamEventsRequest.CacheExists(), "Cached response still exists.");
		}

	}
}
