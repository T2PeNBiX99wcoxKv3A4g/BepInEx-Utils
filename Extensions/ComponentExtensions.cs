using JetBrains.Annotations;
using UnityEngine;

namespace BepInExUtils.Extensions;

public static class ComponentExtensions
{
    extension(Component obj)
    {
        [PublicAPI]
        public string? FullName() => !obj ? null : obj.gameObject.FullName();
    }
}