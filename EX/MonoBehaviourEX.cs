using JetBrains.Annotations;
using UnityEngine;

// ReSharper disable InconsistentNaming

namespace BepInExUtils.EX;

public static class MonoBehaviourEX
{
    extension(MonoBehaviour behaviour)
    {
        [UsedImplicitly]
        public string? FullName() => !behaviour ? null : behaviour.transform.FullName();
    }
}