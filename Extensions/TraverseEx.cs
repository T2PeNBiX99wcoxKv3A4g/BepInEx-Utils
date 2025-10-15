using HarmonyLib;
using JetBrains.Annotations;

namespace BepInExUtils.Extensions;

[PublicAPI]
public class TraverseEx<T>(Traverse<T> traverse)
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

    public static implicit operator T(TraverseEx<T> instance) => instance._traverse.Value;
    public static explicit operator TraverseEx<T>(Traverse<T> traverse) => new(traverse);
}