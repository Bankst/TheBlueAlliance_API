namespace TheBlueAlliance.MainModels
{
    public class Media
    {
	    public class Details
	    {
		    public string base64Image { get; set; }
	    }

		public string key { get; set; }
		public string type { get; set; }
		public string foreign_key { get; set; }
		public Details details { get; set; }
		public bool preferred { get; set; }
		public string direct_url { get; set; }
		public string view_url { get; set; }
    }
}