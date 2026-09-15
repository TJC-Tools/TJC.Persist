using System.Reflection;
using TJC.Persist.Helpers;
using TJC.Persist.Tests.Mocks;

namespace TJC.Persist.Tests;

[TestClass]
public class PersistManagerValidationTests : TestBase
{
    [TestMethod]
    public void RegistrationHelpers_RegisterAndRetrievePersistType()
    {
        PersistManager.RegisterAllFromAssembly(Assembly.GetExecutingAssembly());

        Assert.AreEqual(
            typeof(ExamplePersistObject),
            PersistTypeRegistry.GetTypeByName("ExamplePersistObject")
        );
        Assert.AreEqual(
            "ExamplePersistObject",
            PersistTypeRegistry.GetName(typeof(ExamplePersistObject))
        );
    }

    [TestMethod]
    public void RegisterType_InvalidType_ThrowsInvalidOperationException()
    {
        Assert.ThrowsException<InvalidOperationException>(() =>
            PersistManager.RegisterType(typeof(string))
        );
    }

    [TestMethod]
    public void Registry_UnknownEntries_ThrowInvalidOperationException()
    {
        Assert.ThrowsException<InvalidOperationException>(() =>
            PersistTypeRegistry.GetTypeByName("MissingPersistType")
        );
        Assert.ThrowsException<InvalidOperationException>(() =>
            PersistTypeRegistry.GetName(typeof(PersistManagerValidationTests))
        );
    }

    [TestMethod]
    public void Deserialize_InvalidWrapper_ThrowsInvalidOperationException()
    {
        Assert.ThrowsException<InvalidOperationException>(() =>
            PersistManager.Deserialize("{\"Type\":\"\",\"Payload\":{}}")
        );
        Assert.ThrowsException<InvalidOperationException>(() =>
            PersistManager.Deserialize("{\"Type\":\"Unknown\",\"Payload\":{}}")
        );
    }
}
