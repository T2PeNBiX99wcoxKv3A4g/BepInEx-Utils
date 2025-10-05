using BepInEx.Configuration;
using JetBrains.Annotations;

namespace BepInExUtils.Attributes;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public class ConfigBindAttribute<T> : Attribute
{
    // public ConfigBindAttribute(string key, ConfigDefinition configDefinition, T defaultValue,
    //     ConfigDescription? configDescription = null)
    // {
    //     Key = key;
    //     ConfigDefinition = configDefinition;
    //     DefaultValue = defaultValue;
    //     ConfigDescription = configDescription;
    // }

    public ConfigBindAttribute(string key, string section, T defaultValue, string description)
    {
        Key = key;
        ConfigDefinition = new(section, key);
        DefaultValue = defaultValue;
        ConfigDescription = new(description);
    }

    public ConfigBindAttribute(string key, string section, T defaultValue,
        ConfigDescription? configDescription = null)
    {
        Key = key;
        ConfigDefinition = new(section, key);
        DefaultValue = defaultValue;
        ConfigDescription = configDescription;
    }

    [UsedImplicitly] public string Key { get; protected set; }
    [UsedImplicitly] public ConfigDefinition ConfigDefinition { get; protected set; }
    [UsedImplicitly] public T DefaultValue { get; protected set; }
    [UsedImplicitly] public ConfigDescription? ConfigDescription { get; protected set; }
}