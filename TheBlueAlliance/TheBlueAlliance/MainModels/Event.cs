namespace TheBlueAlliance.MainModels
{
	public class Event
	{
		public string key { get; set; }
		public string name { get; set; }
		public string event_code { get; set; }
		public int event_type { get; set; }
		public string start_date { get; set; }
		public string end_date { get; set; }
		public int year { get; set; }
		public string event_type_string { get; set; }

		public string address { get; set; }
		public string city { get; set; }
		public string country { get; set; }
		public District district { get; set; }
		public string location_name { get; set; }
		public string short_name { get; set; }
		public string start_prov { get; set; }
		public string timezone { get; set; }
		public string website { get; set; }
		public int? week { get; set; }
		public Webcast[] webcasts { get; set; }
	}
}
