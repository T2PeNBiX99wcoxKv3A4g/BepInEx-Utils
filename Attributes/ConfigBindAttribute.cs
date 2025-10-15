using BepInEx.Configuration;
using JetBrains.Annotations;

namespace BepInExUtils.Attributes;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
[PublicAPI]
public class ConfigBindAttribute<T> : Attribute where T : IComparable
{
    public ConfigBindAttribute(string key, string section, T defaultValue, string description)
    {
        Key = key;
        ConfigDefinition = new(section, key);
        DefaultValue = defaultValue;
        ConfigDescription = new(description);
    }

    public ConfigBindAttribute(string key, string section, T defaultValue, string description, T minValue, T maxValue)
    {
        Key = key;
        ConfigDefinition = new(section, key);
        DefaultValue = defaultValue;
        ConfigDescription = new(description, new AcceptableValueRange<T>(minValue, maxValue));
    }

    public string Key { get; protected set; }
    public ConfigDefinition ConfigDefinition { get; protected set; }
    public T DefaultValue { get; protected set; }
    public ConfigDescription? ConfigDescription { get; protected set; }
}