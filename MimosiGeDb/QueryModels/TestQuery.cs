//Created by TestQueryClassCreator at 2/15/2025 11:07:44 AM

namespace AppMimosiGeDb.QueryModels;

public sealed class TestQuery
{
    public int TestId { get; set; }
    public string TestName { get; set; }
    public TestQuery(string testName)
    {
        TestName = testName;
    }
}
