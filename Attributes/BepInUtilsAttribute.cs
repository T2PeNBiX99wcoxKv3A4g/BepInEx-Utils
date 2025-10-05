using JetBrains.Annotations;

namespace BepInExUtils.Attributes;

[AttributeUsage(AttributeTargets.Class)]
public class BepInUtilsAttribute(string guid, string name, string version) : Attribute
{
    [UsedImplicitly] public string Guid { get; protected set; } = guid;
    [UsedImplicitly] public string Name { get; protected set; } = name;
    [UsedImplicitly] public string Version { get; protected set; } = version;
}