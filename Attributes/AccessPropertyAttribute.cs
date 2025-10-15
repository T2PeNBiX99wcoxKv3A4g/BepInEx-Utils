using JetBrains.Annotations;

namespace BepInExUtils.Attributes;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
[PublicAPI]
public class AccessPropertyAttribute<T>(string propertyName) : Attribute
{
    public string PropertyName { get; protected set; } = propertyName;
}