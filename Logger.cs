using BepInEx.Logging;

// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedType.Global

namespace BepInExUtils;

public class Logger(string sourceName)
{
    private ManualLogSource? _logger;
    private ManualLogSource LogSource => _logger ??= BepInEx.Logging.Logger.CreateLogSource(sourceName);

    public void LogError(object data) => LogSource.LogError($"[{MethodUtils.CallerName}] {data}");
    public void LogDebug(object data) => LogSource.LogDebug($"[{MethodUtils.CallerName}] {data}");
    public void LogWarning(object data) => LogSource.LogWarning($"[{MethodUtils.CallerName}] {data}");
    public void LogFatal(object data) => LogSource.LogFatal($"[{MethodUtils.CallerName}] {data}");
    public void LogInfo(object data) => LogSource.LogInfo($"[{MethodUtils.CallerName}] {data}");
    public void LogMessage(object data) => LogSource.LogMessage($"[{MethodUtils.CallerName}] {data}");
    public void Error(object data) => LogSource.LogError($"[{MethodUtils.CallerName}] {data}");
    public void Debug(object data) => LogSource.LogDebug($"[{MethodUtils.CallerName}] {data}");
    public void Warning(object data) => LogSource.LogWarning($"[{MethodUtils.CallerName}] {data}");
    public void Fatal(object data) => LogSource.LogFatal($"[{MethodUtils.CallerName}] {data}");
    public void Info(object data) => LogSource.LogInfo($"[{MethodUtils.CallerName}] {data}");
    public void Message(object data) => LogSource.LogMessage($"[{MethodUtils.CallerName}] {data}");
}