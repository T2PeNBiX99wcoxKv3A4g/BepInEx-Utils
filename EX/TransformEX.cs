using UnityEngine;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace BepInExUtils.EX;

public static class TransformEX
{
    public static string? FullName(this Transform transform)
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
    public static Vector3 GetWorldScale(this Transform transform)
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