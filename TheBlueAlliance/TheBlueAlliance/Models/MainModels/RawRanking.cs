using System;

namespace TheBlueAlliance.Models.MainModels
{
	public class RawRanking
	{
		public Extra_Stats_Info[] extra_stats_info { get; set; }
		public Ranking[] rankings { get; set; }
		public Sort_Order_Info[] sort_order_info { get; set; }

		public class Ranking
		{
			public int    dq             { get; set; }
			public int[]  extra_stats    { get; set; }
			public int    matches_played { get; set; }
			public double? qual_average   { get; set; }
			public int    rank           { get; set; }
			public Record record         { get; set; }
			public double[]  sort_orders    { get; set; }
			public string team_key       { get; set; }
		}

		public class Sort_Order_Info
		{
			public string name { get; set; }
			public int precision { get; set; }
		}
	}

	public class Extra_Stats_Info
	{
		public string name      { get; set; }
		public int    precision { get; set; }
	}

	public class Record
	{
		public int losses { get; set; }
		public int ties { get; set; }
		public int wins { get; set; }
	}
}
