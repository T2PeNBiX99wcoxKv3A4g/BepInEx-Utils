using JetBrains.Annotations;
using UnityEngine;

// ReSharper disable InconsistentNaming

namespace BepInExUtils.EX;

public static class TransformEX
{
    extension(Transform transform)
    {
        public string? FullName()
        {
            if (!transform) return null;
            var tmpName = transform.name;

            while (transform.parent)
            {
                transform = transform.parent;
                tmpName = transform.name + "/" + tmpName;
            }

            return tmpName;
        }

        // From https://discussions.unity.com/t/world-scale/374693
        [UsedImplicitly]
        public Vector3 GetWorldScale()
        {
            var worldScale = transform.localScale;
            var parent = transform.parent;

            while (parent)
            {
                worldScale = Vector3.Scale(worldScale, parent.localScale);
                parent = parent.parent;
            }

            return worldScale;
        }
    }
}