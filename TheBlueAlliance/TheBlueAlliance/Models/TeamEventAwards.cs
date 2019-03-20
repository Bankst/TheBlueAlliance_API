namespace TheBlueAlliance.Models
{
    public class TeamEventAwards
    {
        public class Award
        {
            public int award_type { get; set; }
            public string event_key { get; set; }
			public string name { get; set; }
            public Recipient_List[] recipient_list { get; set; }
            public int year { get; set; }
        }

        public class Recipient_List
        {
            public object awardee { get; set; }
			public string team_key { get; set; }

		}
	}
}