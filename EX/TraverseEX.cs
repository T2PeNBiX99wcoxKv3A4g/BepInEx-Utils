using HarmonyLib;

// ReSharper disable InconsistentNaming
// ReSharper disable UnusedType.Global

namespace BepInExUtils.EX;

public class TraverseEX<T>(Traverse<T> traverse)
{
    private readonly Traverse<T> _traverse = traverse;

    // ReSharper disable UnusedMember.Global
    public void Set(T value) => _traverse.Value = value;
    public T Get() => _traverse.Value;
    // ReSharper restore UnusedMember.Global

    public T V
    {
        get => _traverse.Value;
        set => _traverse.Value = value;
    }

    public static implicit operator T(TraverseEX<T> instance) => instance._traverse.Value;
    public static explicit operator TraverseEX<T>(Traverse<T> traverse) => new(traverse);
}