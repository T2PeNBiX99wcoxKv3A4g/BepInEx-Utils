using System.Diagnostics.CodeAnalysis;
using HarmonyLib;

// ReSharper disable InconsistentNaming
// ReSharper disable UnusedType.Global

namespace BepInExUtils.EX;

[SuppressMessage("ReSharper", "UnusedMember.Global")]
public class TraverseEX<T>(Traverse<T> traverse)
{
    private readonly Traverse<T> _traverse = traverse;

    public T Value
    {
        get => _traverse.Value;
        set => _traverse.Value = value;
    }

    public T V
    {
        get => _traverse.Value;
        set => _traverse.Value = value;
    }

    public void Set(T value) => _traverse.Value = value;
    public T Get() => _traverse.Value;

    public static implicit operator T(TraverseEX<T> instance) => instance._traverse.Value;
    public static explicit operator TraverseEX<T>(Traverse<T> traverse) => new(traverse);
}