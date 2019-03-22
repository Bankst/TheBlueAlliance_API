using System;
using System.IO;
using TheBlueAlliance;

namespace MatchDataDownloader
{
	class Program
	{
		static void Main(string[] args)
		{
			var streamWriter = new StreamWriter(Path.Combine(Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]), "matches.csv"));
			streamWriter.WriteLine("key,alliance,team1,team2,team3,totalPoints,autoPoints,teleopPoints,foulPoints,autoMobilityPoints,autoRotorPoints,autoFuelPoints,autoFuelLow,autoFuelHigh,teleopRotorPoints,teleopFuelPoints,teleopTakeoffPoints,teleopFuelLow,teleopFuelHigh,rotorRankingPointAchieved,kPaRankingPointAchieved,rotorBonusPoints,kPaBonusPoints,adjustPoints");

			var events = Events.GetEvents(2017);
			foreach (var frcEvent in events)
			{
				var eventMatches = Events.GetEventMatches2019(frcEvent.key);
				foreach (var match in eventMatches)
				{
					// if (match.score_breakdown == null) continue;
					// streamWriter.WriteLine(
					// 	string.Format(
					// 		"{0},Red,{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21},{22}",
					// 		match.key, match.alliances.red.team_keys[0].Substring(3),
					// 		match.alliances.red.team_keys[1].Substring(3),
					// 		match.alliances.red.team_keys[2].Substring(3), match.score_breakdown.red.totalPoints,
					// 		match.score_breakdown.red.autoPoints, match.score_breakdown.red.teleopPoints,
					// 		match.score_breakdown.red.foulPoints, match.score_breakdown.red.autoMobilityPoints,
					// 		match.score_breakdown.red.autoRotorPoints, match.score_breakdown.red.autoFuelPoints,
					// 		match.score_breakdown.red.autoFuelLow, match.score_breakdown.red.autoFuelHigh,
					// 		match.score_breakdown.red.teleopRotorPoints, match.score_breakdown.red.teleopFuelPoints,
					// 		match.score_breakdown.red.teleopTakeoffPoints, match.score_breakdown.red.teleopFuelLow,
					// 		match.score_breakdown.red.teleopFuelHigh,
					// 		match.score_breakdown.red.rotorRankingPointAchieved,
					// 		match.score_breakdown.red.kPaRankingPointAchieved,
					// 		match.score_breakdown.red.rotorBonusPoints, match.score_breakdown.red.kpaBonusPoints,
					// 		match.score_breakdown.red.adjustPoints));
					// streamWriter.WriteLine(
					// 	string.Format(
					// 		"{0},Blue,{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21},{22}",
					// 		match.key, match.alliances.blue.team_keys[0].Substring(3),
					// 		match.alliances.blue.team_keys[1].Substring(3),
					// 		match.alliances.blue.team_keys[2].Substring(3), match.score_breakdown.blue.totalPoints,
					// 		match.score_breakdown.blue.autoPoints, match.score_breakdown.blue.teleopPoints,
					// 		match.score_breakdown.blue.foulPoints, match.score_breakdown.blue.autoMobilityPoints,
					// 		match.score_breakdown.blue.autoRotorPoints, match.score_breakdown.blue.autoFuelPoints,
					// 		match.score_breakdown.blue.autoFuelLow, match.score_breakdown.blue.autoFuelHigh,
					// 		match.score_breakdown.blue.teleopRotorPoints, match.score_breakdown.blue.teleopFuelPoints,
					// 		match.score_breakdown.blue.teleopTakeoffPoints, match.score_breakdown.blue.teleopFuelLow,
					// 		match.score_breakdown.blue.teleopFuelHigh,
					// 		match.score_breakdown.blue.rotorRankingPointAchieved,
					// 		match.score_breakdown.blue.kPaRankingPointAchieved,
					// 		match.score_breakdown.blue.rotorBonusPoints, match.score_breakdown.blue.kpaBonusPoints,
					// 		match.score_breakdown.blue.adjustPoints));
				}
			}

			Console.ReadKey();
		}
	}
}
