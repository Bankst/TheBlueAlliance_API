using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBlueAlliance.Models.MainModels
{
	public class Ranking
	{
		public int dq { get; set; }
		public int rank { get; set; }
		public string team_key { get; set; }
		public int matches_played { get; set; }
		public Record record { get; set; }
	}
}
