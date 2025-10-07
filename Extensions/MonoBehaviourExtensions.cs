using JetBrains.Annotations;
using UnityEngine;

namespace BepInExUtils.Extensions;

public static class MonoBehaviourExtensions
{
    extension(MonoBehaviour behaviour)
    {
        [UsedImplicitly]
        public string? FullName() => !behaviour ? null : behaviour.transform.FullName();
    }
}