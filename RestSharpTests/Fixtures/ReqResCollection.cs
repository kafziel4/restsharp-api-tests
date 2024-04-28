using Xunit;

namespace RestSharpTests.Fixtures;

[CollectionDefinition(Constants.ReqResCollection)]
public class ReqResCollection : ICollectionFixture<ReqResFixture>
{
    
}