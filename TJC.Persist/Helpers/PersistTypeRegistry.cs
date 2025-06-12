using System.Reflection;

namespace TJC.Persist.Helpers;

internal static class PersistTypeRegistry
{
    private static readonly Type _persistObjectBaseType = typeof(IPersistObject);
    private static readonly Dictionary<string, Type> _nameToType = [];
    private static readonly Dictionary<Type, string> _typeToName = [];

    #region Register

    internal static void Register(Type type)
    {
        var name = type.Name;
        ValidateRegistration(type);
        _nameToType[name] = type;
        _typeToName[type] = name;
    }

    internal static void RegisterAllFromAssembly(Assembly assembly)
    {
        var types = assembly.GetTypes();

        var inheritedTypes = types.Where(TryValidateRegistration);

        foreach (var type in inheritedTypes)
            Register(type);
    }

    private static bool TryValidateRegistration(Type type)
    {
        try
        {
            ValidateRegistration(type);
        }
        catch
        {
            return false;
        }

        return true;
    }

    private static void ValidateRegistration(Type type)
    {
        if (type.IsAbstract)
            throw new InvalidOperationException($"Type name '{type.Name}' is abstract.");

        if (!_persistObjectBaseType.IsAssignableFrom(type))
            throw new InvalidOperationException($"Type name '{type.Name}' does not inherit from '{nameof(IPersistObject)}'.");

        if (_nameToType.ContainsKey(type.Name))
            throw new InvalidOperationException($"Type name '{type.Name}' is already registered.");
    }

    #endregion

    #region Retrieve

    internal static Type GetTypeByName(string name)
    {
        if (!_nameToType.TryGetValue(name, out var type))
            throw new InvalidOperationException($"Unregistered type name: '{name}'");
        return type;
    }

    internal static string GetName(Type type)
    {
        if (!_typeToName.TryGetValue(type, out var name))
            throw new InvalidOperationException($"Unregistered type: '{type.FullName}'");
        return name;
    }

    #endregion
}