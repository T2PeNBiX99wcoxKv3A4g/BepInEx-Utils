using BepInEx.Logging;
using JetBrains.Annotations;

namespace BepInExUtils.Logging;

[PublicAPI]
public class AsyncLogSource(string sourceName) : ILogSource
{
    public string SourceName { get; } = sourceName;
    public event EventHandler<LogEventArgs>? LogEvent;

    public void Dispose()
    {
    }

    public async Task Log(LogLevel level, object data) =>
        await Task.Run(() => LogEvent?.Invoke(this, new(data, level, this)));

    public async Task LogFatal(object data) => await Log(LogLevel.Fatal, data);

    public async Task LogError(object data) => await Log(LogLevel.Error, data);

    public async Task LogWarning(object data) => await Log(LogLevel.Warning, data);

    public async Task LogMessage(object data) => await Log(LogLevel.Message, data);

    public async Task LogInfo(object data) => await Log(LogLevel.Info, data);

    public async Task LogDebug(object data) => await Log(LogLevel.Debug, data);
}