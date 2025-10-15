using HarmonyLib;
using JetBrains.Annotations;

namespace BepInExUtils.Proxy;

[UsedImplicitly]
public abstract class ClassProxy
{
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
        Native = instance ?? throw new NullReferenceException("instance is null");
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
        Native = Activator.CreateInstance(Type) ??
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
        Native = Activator.CreateInstance(Type, args) ??
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
        Native = Activator.CreateInstance(Type, args, activationAttributes) ??
                 throw new NullReferenceException("Could not create instance");
    }

    [Obsolete("Use Native instead.")]
    [UsedImplicitly]
    protected object Instance => Native;

    [UsedImplicitly] public object Native { get; }
}