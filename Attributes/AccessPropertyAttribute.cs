using JetBrains.Annotations;

namespace BepInExUtils.Attributes;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
[UsedImplicitly]
public class AccessPropertyAttribute<T>(string propertyName) : Attribute
{
    [UsedImplicitly] public string PropertyName { get; protected set; } = propertyName;
}