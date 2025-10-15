using BepInEx.Configuration;
using JetBrains.Annotations;

namespace BepInExUtils.Extensions;

public static class ConfigEntryExtensions
{
    extension<T>(ConfigEntry<T>? configEntry)
    {
        [PublicAPI]
        public ConfigEntryEx<T> TryGetValue(T defaultValue = default!) => new(configEntry, defaultValue);

        [PublicAPI]
        public ConfigEntryEx<T> Value() => TryGetValue(configEntry, (T?)configEntry?.DefaultValue ?? default!);
    }
}

[PublicAPI]
public class ConfigEntryEx<T>(ConfigEntry<T>? configEntry, T defaultValue = default!)
{
    private T Value => configEntry == null ? defaultValue : configEntry.Value;

    public T V
    {
        get => Value;
        set => Set(value);
    }

    public void Set(T value)
    {
        if (configEntry == null) return;
        configEntry.Value = value;
    }

    public static implicit operator T(ConfigEntryEx<T> instance) => instance.Value;
    public static explicit operator ConfigEntryEx<T>(ConfigEntry<T>? configEntry) => new(configEntry);
}