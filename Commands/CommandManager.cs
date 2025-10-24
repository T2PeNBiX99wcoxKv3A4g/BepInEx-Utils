using JetBrains.Annotations;

namespace BepInExUtils.Commands;

[PublicAPI]
public sealed class CommandManager
{
    public delegate Task Command(string[] args);

    public static readonly CommandManager Instance = new();

    private readonly Dictionary<string, CommandInfo> _commands = [];

    private CommandManager()
    {
        AddDefaultCommands();
        Utils.Logger.Debug("CommandManager init");
    }

    private void AddDefaultCommands()
    {
        AddCommand(new("help", "Show command infos", async _ =>
        {
            var cmdInfos = _commands.Values.Select(cmd => $"{cmd.Name} - {cmd.Description}");
            await Utils.Logger.InfoAsync($"Available commands:\n{string.Join("\n", cmdInfos)}");
        }));
        AddCommand(new("echo", "Echo args", async args => { await Utils.Logger.InfoAsync(string.Join("\n", args)); }));
    }

    public void AddCommand(CommandInfo commandInfo)
    {
        if (_commands.ContainsKey(commandInfo.Name))
        {
            Utils.Logger.Error($"Command {commandInfo.Name} already exists");
            return;
        }

        _commands.Add(commandInfo.Name, commandInfo);
    }

    public void AddCommand(string commandName, string description, Command command)
    {
        AddCommand(new(commandName, description, command));
    }

    public async Task<bool> ExecuteCommand(string command, params string[] args)
    {
        if (!_commands.TryGetValue(command, out var info)) return false;
        await info.Command(args);
        return true;
    }
}