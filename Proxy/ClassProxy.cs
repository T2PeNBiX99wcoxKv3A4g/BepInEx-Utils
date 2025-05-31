using HarmonyLib;

// ReSharper disable UnusedType.Global
// ReSharper disable UnusedMember.Global

namespace BepInExUtils.Proxy;

public abstract class ClassProxy(object instance, string className = "")
{
    // ReSharper disable once MemberCanBePrivate.Global
    protected readonly Type Type = AccessTools.TypeByName(className);

    // ReSharper disable once MemberCanBePrivate.Global
    protected readonly object Instance = instance;

    // ReSharper disable once UnusedMember.Global
    protected T? MethodAccess<T>(string methodName, params object?[] parameters)
    {
        var method = AccessTools.Method(Type, methodName);
        if (method == null)
            throw new MethodAccessException($"Method {methodName} not found.");
        var result = method.Invoke(Instance, parameters);
        return result is T a ? a : default;
    }

    protected void MethodAccess(string methodName, params object?[] parameters)
    {
        var method = AccessTools.Method(Type, methodName);
        if (method == null)
            throw new MethodAccessException($"Method {methodName} not found.");
        method.Invoke(Instance, parameters);
    }
}