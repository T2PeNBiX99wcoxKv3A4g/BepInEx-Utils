using BepInExUtils.Extensions;
using HarmonyLib;
using JetBrains.Annotations;

namespace BepInExUtils.Proxy;

[UsedImplicitly]
public abstract class ClassProxy
{
    private readonly object? _internalInstance;

    [UsedImplicitly] protected readonly Type Type;

    protected ClassProxy(object? instance, string className)
    {
        if (string.IsNullOrEmpty(className))
            throw new ArgumentException("Class name cannot be null or empty", className);
        Type = AccessTools.TypeByName(className);
        if (Type == null)
            throw new TypeAccessException($"Type {className} not found.");
        if (Type.BaseType == GetType())
            throw new TypeAccessException($"Type {className} is subclass of {GetType().Name}.");
        _internalInstance = instance ?? throw new NullReferenceException("instance is null");
    }

    protected ClassProxy(string className)
    {
        if (string.IsNullOrEmpty(className))
            throw new ArgumentException("Class name cannot be null or empty", className);
        Type = AccessTools.TypeByName(className);
        if (Type == null)
            throw new TypeAccessException($"Type {className} not found.");
        if (Type.BaseType == GetType())
            throw new TypeAccessException($"Type {className} is subclass of {GetType().Name}.");
        if (Type.IsAbstract)
            throw new TypeAccessException($"Type {className} is abstract class.");
        _internalInstance = Activator.CreateInstance(Type) ??
                            throw new NullReferenceException("Could not create instance");
    }

    protected ClassProxy(string className, params object[] args)
    {
        if (string.IsNullOrEmpty(className))
            throw new ArgumentException("Class name cannot be null or empty", className);
        Type = AccessTools.TypeByName(className);
        if (Type == null)
            throw new TypeAccessException($"Type {className} not found.");
        if (Type.BaseType == GetType())
            throw new TypeAccessException($"Type {className} is subclass of {GetType().Name}.");
        if (Type.IsAbstract)
            throw new TypeAccessException($"Type {className} is abstract class.");
        _internalInstance = Activator.CreateInstance(Type, args) ??
                            throw new NullReferenceException("Could not create instance");
    }

    protected ClassProxy(string className, object[] args, object[] activationAttributes)
    {
        if (string.IsNullOrEmpty(className))
            throw new ArgumentException("Class name cannot be null or empty", className);
        Type = AccessTools.TypeByName(className);
        if (Type == null)
            throw new TypeAccessException($"Type {className} not found.");
        if (Type.BaseType == GetType())
            throw new TypeAccessException($"Type {className} is subclass of {GetType().Name}.");
        if (Type.IsAbstract)
            throw new TypeAccessException($"Type {className} is abstract class.");
        _internalInstance = Activator.CreateInstance(Type, args, activationAttributes) ??
                            throw new NullReferenceException("Could not create instance");
    }

    [UsedImplicitly]
    protected object Instance => _internalInstance ?? throw new NullReferenceException("instance is null");

    [Obsolete("Use object.MethodInvoke instead.")]
    [UsedImplicitly]
    protected T? MethodAccess<T>(string methodName, params object?[] parameters) =>
        Instance.MethodInvoke<T>(methodName, parameters);

    [Obsolete("Use object.MethodInvoke instead.")]
    [UsedImplicitly]
    protected void MethodAccess(string methodName, params object?[] parameters) =>
        Instance.MethodInvoke(methodName, parameters);
}