using System.Diagnostics;
using HarmonyLib;

// ReSharper disable UnusedMember.Global

namespace BepInExUtils;

public static class MethodUtils
{
    private const string UnknownName = "Unknown";

    public static string CallerName
    {
        get
        {
            var stackTrace = new StackTrace();
            var frame = stackTrace.GetFrame(2);
            if (frame == null) return UnknownName;
            var caller = frame.GetMethod();
            if (caller == null) return UnknownName;
            return caller.DeclaringType?.Name ?? caller.Name;
        }
    }

    public static string MethodName
    {
        get
        {
            var stackTrace = new StackTrace();
            var frame = stackTrace.GetFrame(1);
            if (frame == null) return UnknownName;
            var caller = frame.GetMethod();
            return caller == null ? UnknownName : caller.Name;
        }
    }

    public static T2? MethodAccess<T, T2>(this T obj, string methodName, params object?[] parameters)
    {
        if (obj == null)
            throw new NullReferenceException($"obj {nameof(obj)} is null.");
        var method = AccessTools.Method(obj.GetType(), methodName);
        if (method == null)
            throw new MethodAccessException($"Method {methodName} not found.");
        var result = method.Invoke(obj, parameters);
        return result is T2 a ? a : default;
    }

    public static void MethodAccess<T>(this T obj, string methodName, params object?[] parameters)
    {
        if (obj == null)
            throw new NullReferenceException($"obj {nameof(obj)} is null.");
        var method = AccessTools.Method(obj.GetType(), methodName);
        if (method == null)
            throw new MethodAccessException($"Method {methodName} not found.");
        method.Invoke(obj, parameters);
    }
}