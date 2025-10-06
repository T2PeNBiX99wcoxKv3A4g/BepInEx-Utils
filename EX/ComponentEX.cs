using JetBrains.Annotations;
using UnityEngine;

// ReSharper disable InconsistentNaming

namespace BepInExUtils.EX;

public static class ComponentEX
{
    extension(Component obj)
    {
        [UsedImplicitly]
        public string? FullName() => !obj ? null : obj.gameObject.FullName();
    }
}