using UnityEngine;

// ReSharper disable InconsistentNaming

namespace BepInExUtils.EX;

public static class GameObjectEX
{
    public static string? FullName(this GameObject obj) => !obj ? null : obj.transform.FullName();
}