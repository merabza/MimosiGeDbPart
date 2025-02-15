//Created by TestModelClassCreator at 2/15/2025 11:07:44 AM

namespace MimosiGeDb.Models;

//ეს არის სატესტო მოდელი, რომელიც არის უბრალოდ ნიმუშისათვის და შესაძლებელია წაიშალოს საჭირების შემთხვევაში

public sealed class TestModel
{
    public int TestId { get; set; }
    public string TestName { get; set; }
    
    // ReSharper disable once ConvertToPrimaryConstructor
    public TestModel(string testName)
    {
        TestName = testName;
    }
}
