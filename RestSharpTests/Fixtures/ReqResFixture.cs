using RestSharpTests.Clients;

namespace RestSharpTests.Fixtures;

public class ReqResFixture
{
    public ReqResClient ReqResClient { get; }
    
    public ReqResFixture()
    {
        ReqResClient = new ReqResClient();
    }
}