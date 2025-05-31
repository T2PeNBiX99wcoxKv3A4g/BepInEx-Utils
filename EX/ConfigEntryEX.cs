using BepInEx.Configuration;

// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedType.Global
// ReSharper disable InconsistentNaming

namespace BepInExUtils.EX;

public static class ConfigEntryEX
{
    // ReSharper disable once MemberCanBePrivate.Global
    public static ConfigEntryEX<T> TryGetValue<T>(this ConfigEntry<T>? configEntry, T defaultValue = default!) =>
        new(configEntry, defaultValue);

    public static ConfigEntryEX<T> Value<T>(this ConfigEntry<T>? configEntry) =>
        TryGetValue(configEntry, (T?)configEntry?.DefaultValue ?? default!);
}

public class ConfigEntryEX<T>(ConfigEntry<T>? configEntry, T defaultValue = default!)
{
    private T _value => configEntry == null ? defaultValue : configEntry.Value;

    // ReSharper disable once UnusedMember.Global
    // ReSharper disable once MemberCanBePrivate.Global
    public void Set(T value)
    {
        if (configEntry == null) return;
        configEntry.Value = value;
    }

    public T V
    {
        get => _value;
        set => Set(value);
    }

    public static implicit operator T(ConfigEntryEX<T> instance) => instance._value;
    public static explicit operator ConfigEntryEX<T>(ConfigEntry<T>? configEntry) => new(configEntry);
}