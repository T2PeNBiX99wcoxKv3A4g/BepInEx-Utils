using UnityEngine;

namespace BepInExUtils.Extensions;

public static class GameObjectExtensions
{
    extension(GameObject obj)
    {
        public string? FullName() => !obj ? null : obj.transform.FullName();
    }
}