using TJC.Persist.Tests.Mocks;

namespace TJC.Persist.Tests;

[TestClass]
public class PersistObjectBaseTests : TestBase
{
    private const string ExamplePersistObjectSerialized =
        "{\"Type\":\"ExamplePersistObject\",\"Payload\":{\"Name\":\"Test\",\"Value\":5}}";

    [TestMethod]
    public void SerializeExamplePersistObject()
    {
        var example = new ExamplePersistObject { Name = "Test", Value = 5 };

        var result = PersistManager.Serialize(example);

        Assert.AreEqual(ExamplePersistObjectSerialized, result);
    }

    [TestMethod]
    public void DeserializeExamplePersistObject()
    {
        var result = PersistManager.Deserialize(ExamplePersistObjectSerialized);

        Assert.IsInstanceOfType(result, typeof(ExamplePersistObject));

        var example = (ExamplePersistObject)result;

        Assert.AreEqual("Test", example.Name);
        Assert.AreEqual(5, example.Value);
    }
}
