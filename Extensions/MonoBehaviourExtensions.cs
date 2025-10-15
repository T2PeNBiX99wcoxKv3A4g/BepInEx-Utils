using JetBrains.Annotations;
using UnityEngine;

namespace BepInExUtils.Extensions;

public static class MonoBehaviourExtensions
{
    extension(MonoBehaviour behaviour)
    {
        [PublicAPI]
        public string? FullName() => !behaviour ? null : behaviour.transform.FullName();
    }
}