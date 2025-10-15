using JetBrains.Annotations;
using UnityEngine;

namespace BepInExUtils.Extensions;

public static class GameObjectExtensions
{
    extension(GameObject obj)
    {
        [PublicAPI]
        public string? FullName() => !obj ? null : obj.transform.FullName();
    }
}