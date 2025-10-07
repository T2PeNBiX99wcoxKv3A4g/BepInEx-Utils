using JetBrains.Annotations;

namespace BepInExUtils.Attributes;

[AttributeUsage(AttributeTargets.Class)]
[UsedImplicitly]
public class AccessInstanceAttribute<T> : Attribute
{
}