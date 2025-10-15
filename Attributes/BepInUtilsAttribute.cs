using JetBrains.Annotations;

namespace BepInExUtils.Attributes;

[AttributeUsage(AttributeTargets.Class)]
[PublicAPI]
public class BepInUtilsAttribute(string guid, string name, string version) : Attribute
{
    public string Guid { get; protected set; } = guid;
    public string Name { get; protected set; } = name;
    public string Version { get; protected set; } = version;
}