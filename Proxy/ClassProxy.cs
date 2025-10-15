using HarmonyLib;
using JetBrains.Annotations;

namespace BepInExUtils.Proxy;

[PublicAPI]
public abstract class ClassProxy
{
    protected readonly string ClassName;
    protected readonly Type Type;

    protected ClassProxy(object? instance, string className)
    {
        if (string.IsNullOrEmpty(className))
            throw new ArgumentException("Class name cannot be null or empty", nameof(className));
        Type = AccessTools.TypeByName(className);
        if (Type == null)
            throw new TypeAccessException($"Type {className} not found.");
        if (Type.BaseType == GetType())
            throw new TypeAccessException($"Type {className} is subclass of {GetType().Name}.");
        var instanceType = instance?.GetType();
        if (instanceType != Type)
            throw new TypeAccessException($"instance {instanceType?.FullName} is not match {Type.FullName}.");
        ClassName = className;
        Native = instance ?? throw new NullReferenceException("instance is null");
    }

    protected ClassProxy(string className)
    {
        if (string.IsNullOrEmpty(className))
            throw new ArgumentException("Class name cannot be null or empty", nameof(className));
        Type = AccessTools.TypeByName(className);
        if (Type == null)
            throw new TypeAccessException($"Type {className} not found.");
        if (Type.BaseType == GetType())
            throw new TypeAccessException($"Type {className} is subclass of {GetType().Name}.");
        if (Type.IsAbstract)
            throw new TypeAccessException($"Type {className} is abstract class.");
        ClassName = className;
        Native = Activator.CreateInstance(Type) ??
                 throw new NullReferenceException("Could not create instance");
    }

    protected ClassProxy(string className, params object[] args)
    {
        if (string.IsNullOrEmpty(className))
            throw new ArgumentException("Class name cannot be null or empty", nameof(className));
        Type = AccessTools.TypeByName(className);
        if (Type == null)
            throw new TypeAccessException($"Type {className} not found.");
        if (Type.BaseType == GetType())
            throw new TypeAccessException($"Type {className} is subclass of {GetType().Name}.");
        if (Type.IsAbstract)
            throw new TypeAccessException($"Type {className} is abstract class.");
        ClassName = className;
        Native = Activator.CreateInstance(Type, args) ??
                 throw new NullReferenceException("Could not create instance");
    }

    protected ClassProxy(string className, object[] args, object[] activationAttributes)
    {
        if (string.IsNullOrEmpty(className))
            throw new ArgumentException("Class name cannot be null or empty", nameof(className));
        Type = AccessTools.TypeByName(className);
        if (Type == null)
            throw new TypeAccessException($"Type {className} not found.");
        if (Type.BaseType == GetType())
            throw new TypeAccessException($"Type {className} is subclass of {GetType().Name}.");
        if (Type.IsAbstract)
            throw new TypeAccessException($"Type {className} is abstract class.");
        ClassName = className;
        Native = Activator.CreateInstance(Type, args, activationAttributes) ??
                 throw new NullReferenceException("Could not create instance");
    }

    [Obsolete("Use Native instead.")] protected object Instance => Native;

    public object Native { get; }
}