using TheBlueAlliance.SpecificModels;

namespace TheBlueAlliance
{
	public class Matches
    {
	    public static ApiRequest MatchRequest { get; set; }
	    public static Match2019 GetMatch2019(string matchKey, bool checkCache = true)
	    {
		    if (MatchRequest == null)
		    {
				MatchRequest = new ApiRequest($"/match/{matchKey}");
		    }

		    MatchRequest.ShouldCheckCache = checkCache;
			
		    var response = MatchRequest.GetData<Match2019>();
			return response;
	    }
    }
}