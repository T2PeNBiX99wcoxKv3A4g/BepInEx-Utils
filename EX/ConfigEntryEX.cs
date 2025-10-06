using BepInEx.Configuration;
using JetBrains.Annotations;

// ReSharper disable InconsistentNaming

namespace BepInExUtils.EX;

public static class ConfigEntryEX
{
    extension<T>(ConfigEntry<T>? configEntry)
    {
        [UsedImplicitly]
        public ConfigEntryEX<T> TryGetValue(T defaultValue = default!) => new(configEntry, defaultValue);

        [UsedImplicitly]
        public ConfigEntryEX<T> Value() => TryGetValue(configEntry, (T?)configEntry?.DefaultValue ?? default!);
    }
}

public class ConfigEntryEX<T>(ConfigEntry<T>? configEntry, T defaultValue = default!)
{
    private T _value => configEntry == null ? defaultValue : configEntry.Value;

    [UsedImplicitly]
    public T V
    {
        get => _value;
        set => Set(value);
    }

    [UsedImplicitly]
    public void Set(T value)
    {
        if (configEntry == null) return;
        configEntry.Value = value;
    }

    public static implicit operator T(ConfigEntryEX<T> instance) => instance._value;
    public static explicit operator ConfigEntryEX<T>(ConfigEntry<T>? configEntry) => new(configEntry);
}