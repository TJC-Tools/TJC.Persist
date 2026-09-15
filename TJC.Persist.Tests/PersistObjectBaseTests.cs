using TJC.Persist.Tests.Mocks;

namespace TJC.Persist.Tests;


public class PersistObjectBaseTests : TestBase
{
    private const string ExamplePersistObjectSerialized =
        "{\"Type\":\"ExamplePersistObject\",\"Payload\":{\"Name\":\"Test\",\"Value\":5}}";

    [Fact]
    public void SerializeExamplePersistObject()
    {
        var example = new ExamplePersistObject { Name = "Test", Value = 5 };

        var result = PersistManager.Serialize(example);

        Assert.Equal(ExamplePersistObjectSerialized, result);
    }

    [Fact]
    public void DeserializeExamplePersistObject()
    {
        var result = PersistManager.Deserialize(ExamplePersistObjectSerialized);

        Assert.IsType(typeof(ExamplePersistObject), result);

        var example = (ExamplePersistObject)result;

        Assert.Equal("Test", example.Name);
        Assert.Equal(5, example.Value);
    }
}
