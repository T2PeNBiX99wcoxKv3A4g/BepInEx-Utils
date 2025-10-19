using System.Diagnostics;
using JetBrains.Annotations;

namespace BepInExUtils;

[PublicAPI]
public static class MethodUtils
{
    private const string UnknownName = "Unknown";

    public static string CallerName => GetCallerName(2);

    public static string MethodName => GetMethodName(1);

    public static string GetCallerName(int index = 1)
    {
        var newIndex = index + 1;
        var stackTrace = new StackTrace();
        var frame = stackTrace.GetFrame(newIndex);
        if (frame == null) return UnknownName;
        var caller = frame.GetMethod();
        if (caller == null) return UnknownName;
        return caller.DeclaringType?.Name ?? caller.Name;
    }

    public static string GetMethodName(int index = 0)
    {
        var newIndex = index + 1;
        var stackTrace = new StackTrace();
        var frame = stackTrace.GetFrame(newIndex);
        if (frame == null) return UnknownName;
        var caller = frame.GetMethod();
        return caller == null ? UnknownName : caller.Name;
    }
}