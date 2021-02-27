using Xunit;

namespace Sat.Recruitment.FunctionalTest.Fixtures
{
    [CollectionDefinition(TestConstants.SatRecruitmentCollection)]
    public class SatRecruitmentCollection
        : ICollectionFixture<HostFixture>
    {
    }
}