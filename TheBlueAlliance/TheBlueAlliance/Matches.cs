using TheBlueAlliance.SpecificModels;

namespace TheBlueAlliance
{
	public class Matches
    {
	    private static ApiRequest _matchRequest;
	    public static Match2019 GetMatch2019(string matchKey)
	    {
		    if (_matchRequest == null)
		    {
				_matchRequest = new ApiRequest($"/match/{matchKey}");
		    }

		    var response = _matchRequest.GetData<Match2019>();
		    return response;
	    }
    }
}