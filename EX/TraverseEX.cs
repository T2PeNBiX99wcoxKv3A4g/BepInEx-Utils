using HarmonyLib;
using JetBrains.Annotations;

// ReSharper disable InconsistentNaming

namespace BepInExUtils.EX;

public class TraverseEX<T>(Traverse<T> traverse)
{
    private readonly Traverse<T> _traverse = traverse;

    [UsedImplicitly]
    public T Value
    {
        get => _traverse.Value;
        set => _traverse.Value = value;
    }

    [UsedImplicitly]
    public T V
    {
        get => _traverse.Value;
        set => _traverse.Value = value;
    }

    [UsedImplicitly]
    public void Set(T value) => _traverse.Value = value;

    [UsedImplicitly]
    public T Get() => _traverse.Value;

    public static implicit operator T(TraverseEX<T> instance) => instance._traverse.Value;
    public static explicit operator TraverseEX<T>(Traverse<T> traverse) => new(traverse);
}