using JetBrains.Annotations;

namespace BepInExUtils.Attributes;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public class AccessMethodAttribute(string methodName, params Type[] args) : Attribute
{
    [UsedImplicitly] public string MethodName { get; protected set; } = methodName;
    [UsedImplicitly] public Type[] Args { get; protected set; } = args;
}

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
[UsedImplicitly]
public class AccessMethodAttribute<T>(string methodName, params Type[] args) : Attribute
{
    [UsedImplicitly] public string MethodName { get; protected set; } = methodName;
    [UsedImplicitly] public Type[] Args { get; protected set; } = args;
}