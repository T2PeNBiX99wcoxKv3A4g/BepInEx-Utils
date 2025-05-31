using UnityEngine;

// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global

namespace BepInExUtils.EX;

public static class ComponentEX
{
    public static string? FullName(this Component obj) => !obj ? null : obj.gameObject.FullName();
}