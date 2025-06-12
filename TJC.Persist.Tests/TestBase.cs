using System.Reflection;
using TJC.Persist.Helpers;
using TJC.Singleton.Factories;

namespace TJC.Persist.Tests;

public class TestBase
{
    private static bool _initialized;

    [TestInitialize]
    public void Initialize()
    {
        if (_initialized)
            return;
        SingletonFactory.InstantiateAll();
        PersistTypeRegistry.RegisterAllFromAssembly(Assembly.GetExecutingAssembly());
        _initialized = true;
    }
}
