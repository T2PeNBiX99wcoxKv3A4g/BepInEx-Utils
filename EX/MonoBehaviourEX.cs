using UnityEngine;

// ReSharper disable UnusedType.Global
// ReSharper disable InconsistentNaming

namespace BepInExUtils.EX;

public static class MonoBehaviourEX
{
    public static string? FullName(this MonoBehaviour behaviour) =>
        !behaviour ? null : behaviour.transform.FullName();
}