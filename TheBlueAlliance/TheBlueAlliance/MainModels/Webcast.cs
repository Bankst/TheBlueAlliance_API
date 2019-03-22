namespace TheBlueAlliance.MainModels
{
	/// <summary>
	///     Information regarding the location and type of a webcast for an event
	/// </summary>
	public class Webcast
	{
		public string type    { get; set; }
		public string channel { get; set; }
		public string file    { get; set; }
	}
}
