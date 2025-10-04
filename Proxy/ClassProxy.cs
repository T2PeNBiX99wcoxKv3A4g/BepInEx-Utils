using HarmonyLib;

// ReSharper disable UnusedType.Global
// ReSharper disable UnusedMember.Global

namespace BepInExUtils.Proxy;

public abstract class ClassProxy
{
    // ReSharper disable once MemberCanBePrivate.Global
    protected readonly object? Instance;

    // ReSharper disable once MemberCanBePrivate.Global
    protected readonly Type Type;

    protected ClassProxy(object? instance, string className)
    {
        if (string.IsNullOrEmpty(className))
            throw new ArgumentException("Class name cannot be null or empty", className);
        Type = AccessTools.TypeByName(className);
        Instance = instance;
    }

    protected ClassProxy(string className)
    {
        if (string.IsNullOrEmpty(className))
            throw new ArgumentException("Class name cannot be null or empty", className);
        Type = AccessTools.TypeByName(className);
        if (Type.IsAbstract) return;
        Instance = Activator.CreateInstance(Type) ?? throw new NullReferenceException("Could not create instance");
    }

    protected ClassProxy(string className, params object[] args)
    {
        if (string.IsNullOrEmpty(className))
            throw new ArgumentException("Class name cannot be null or empty", className);
        Type = AccessTools.TypeByName(className);
        Instance = typeof(Activator).GetMethod(nameof(Activator.CreateInstance))?.Invoke(Instance, args) ??
                   throw new NullReferenceException("Could not create instance");
    }

    protected ClassProxy(string className, object[] args, object[] activationAttributes)
    {
        if (string.IsNullOrEmpty(className))
            throw new ArgumentException("Class name cannot be null or empty", className);
        Type = AccessTools.TypeByName(className);
        Instance = Activator.CreateInstance(Type, args, activationAttributes) ??
                   throw new NullReferenceException("Could not create instance");
    }

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