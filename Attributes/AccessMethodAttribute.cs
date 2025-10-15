using JetBrains.Annotations;

namespace BepInExUtils.Attributes;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
[PublicAPI]
public class AccessMethodAttribute(string methodName, params Type[] args) : Attribute
{
    public string MethodName { get; protected set; } = methodName;
    public Type[] Args { get; protected set; } = args;
}

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
[PublicAPI]
public class AccessMethodAttribute<T>(string methodName, params Type[] args) : Attribute
{
    public string MethodName { get; protected set; } = methodName;
    public Type[] Args { get; protected set; } = args;
}