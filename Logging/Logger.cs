using JetBrains.Annotations;

namespace BepInExUtils.Logging;

[PublicAPI]
public class Logger(string sourceName)
{
    private AsyncLogSource? _logger;

    private AsyncLogSource LogSource => _logger ??= CreateAsyncLogSource(sourceName);

    public static AsyncLogSource CreateAsyncLogSource(string sourceName)
    {
        var logSource = new AsyncLogSource(sourceName);
        BepInEx.Logging.Logger.Sources.Add(logSource);
        return logSource;
    }

    public void LogError(object data) => LogSource.LogError($"[{MethodUtils.CallerName}] {data}").Wait();
    public async Task LogErrorAsync(object data) => await LogSource.LogError($"[{MethodUtils.CallerName}] {data}");
    public void LogDebug(object data) => LogSource.LogDebug($"[{MethodUtils.CallerName}] {data}").Wait();
    public async Task LogDebugAsync(object data) => await LogSource.LogDebug($"[{MethodUtils.CallerName}] {data}");
    public void LogWarning(object data) => LogSource.LogWarning($"[{MethodUtils.CallerName}] {data}").Wait();
    public async Task LogWarningAsync(object data) => await LogSource.LogWarning($"[{MethodUtils.CallerName}] {data}");
    public void LogFatal(object data) => LogSource.LogFatal($"[{MethodUtils.CallerName}] {data}").Wait();
    public async Task LogFatalAsync(object data) => await LogSource.LogFatal($"[{MethodUtils.CallerName}] {data}");
    public void LogInfo(object data) => LogSource.LogInfo($"[{MethodUtils.CallerName}] {data}").Wait();
    public async Task LogInfoAsync(object data) => await LogSource.LogInfo($"[{MethodUtils.CallerName}] {data}");
    public void LogMessage(object data) => LogSource.LogMessage($"[{MethodUtils.CallerName}] {data}").Wait();
    public async Task LogMessageAsync(object data) => await LogSource.LogMessage($"[{MethodUtils.CallerName}] {data}");
    public void Error(object data) => LogSource.LogError($"[{MethodUtils.CallerName}] {data}").Wait();
    public async Task ErrorAsync(object data) => await LogSource.LogError($"[{MethodUtils.CallerName}] {data}");
    public void Debug(object data) => LogSource.LogDebug($"[{MethodUtils.CallerName}] {data}").Wait();
    public async Task DebugAsync(object data) => await LogSource.LogDebug($"[{MethodUtils.CallerName}] {data}");
    public void Warning(object data) => LogSource.LogWarning($"[{MethodUtils.CallerName}] {data}").Wait();
    public async Task WarningAsync(object data) => await LogSource.LogWarning($"[{MethodUtils.CallerName}] {data}");
    public void Fatal(object data) => LogSource.LogFatal($"[{MethodUtils.CallerName}] {data}").Wait();
    public async Task FatalAsync(object data) => await LogSource.LogFatal($"[{MethodUtils.CallerName}] {data}");
    public void Info(object data) => LogSource.LogInfo($"[{MethodUtils.CallerName}] {data}").Wait();
    public async Task InfoAsync(object data) => await LogSource.LogInfo($"[{MethodUtils.CallerName}] {data}");
    public void Message(object data) => LogSource.LogMessage($"[{MethodUtils.CallerName}] {data}").Wait();
    public async Task MessageAsync(object data) => await LogSource.LogMessage($"[{MethodUtils.CallerName}] {data}");
}