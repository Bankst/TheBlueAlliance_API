﻿using TheBlueAlliance.Models.MainModels;

namespace TheBlueAlliance.Models
{
	public class TeamEvents
	{
		public class Alliance
		{
			public object[] declines { get; set; }
			public string[] picks { get; set; }
		}

		public class Event : MainModels.Event
		{
			public string address { get; set; }
			public string city { get; set; }
			public string country { get; set; }
			public District district { get; set; }
			public string end_date { get; set; }
			public string event_code { get; set; }
			public int event_type { get; set; }
			public string event_type_string { get; set; }
			public string key { get; set; }
			public string location_name { get; set; }
			public string name { get; set; }
			public string short_name { get; set; }
			public string start_date { get; set; }
			public string start_prov { get; set; }
			public string timezone { get; set; }
			public string website { get; set; }
			public int week { get; set; }
			public int year { get; set; }
			public Webcast[] webcasts { get; set; }
		}
	}
}