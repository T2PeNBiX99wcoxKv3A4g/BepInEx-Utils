using System.Diagnostics;
using JetBrains.Annotations;

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

    [UsedImplicitly]
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
}