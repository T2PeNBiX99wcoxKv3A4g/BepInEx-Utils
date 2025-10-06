using UnityEngine;

// ReSharper disable InconsistentNaming

namespace BepInExUtils.EX;

public static class GameObjectEX
{
    extension(GameObject obj)
    {
        public string? FullName() => !obj ? null : obj.transform.FullName();
    }
}