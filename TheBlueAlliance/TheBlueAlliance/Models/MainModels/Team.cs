using System.Collections.Generic;

namespace TheBlueAlliance.Models.MainModels
{
	public class Team
	{
		public string address { get; set; }
		public string city { get; set; }
		public string country { get; set; }
		public string gmaps_place_id { get; set; }
		public string gmaps_url { get; set; }
		public Home_Championship home_championship { get; set; }
		public string key { get; set; }
		public string location_name { get; set; }
		public string motto { get; set; }
		public string name { get; set; }
		public string nickname { get; set; }
		public string postal_code { get; set; }
		public int rookie_year { get; set; }
		public string state_prov { get; set; }
		public int team_number { get; set; }
		public string website { get; set; }

	}

	public class Home_Championship : Dictionary<string, string>
	{
		public string year { get; set; }
		public string city { get; set; }
	}
}
