namespace TheBlueAlliance
{
	public static class Constants
	{
		private const string ApiUrl = "http://www.thebluealliance.com/api/v3";

		public static string GetRequestUrl(string path)
		{
			return $"{ApiUrl}{path}";
		}
	}
}
