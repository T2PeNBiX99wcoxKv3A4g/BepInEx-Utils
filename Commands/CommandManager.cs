using JetBrains.Annotations;

namespace BepInExUtils.Commands;

[PublicAPI]
public static class CommandManager
{
    public delegate Task Command(string[] args);

    private static readonly Dictionary<string, CommandInfo> Infos = [];

    private static readonly List<CommandInfo> DefaultCommands =
    [
        new("help", "Show command infos", async _ =>
        {
            var cmdInfos = Infos.Values.Select(cmd => $"{cmd.Name} - {cmd.Description}");
            await Utils.Logger.InfoAsync($"Available commands:\n{string.Join("\n", cmdInfos)}");
        }),
        new("echo", "Echo args", async args => { await Utils.Logger.InfoAsync(string.Join("\n", args)); })
    ];

    internal static void Init()
    {
        DefaultCommands.ForEach(AddCommand);
        Utils.Logger.Debug("CommandManager init");
    }

    public static void AddCommand(CommandInfo commandInfo) => Infos.Add(commandInfo.Name, commandInfo);

    public static void AddCommand(string commandName, string description, Command command) =>
        AddCommand(new(commandName, description, command));

    public static async Task<bool> ExecuteCommand(string command, params string[] args)
    {
        if (!Infos.TryGetValue(command, out var info)) return false;
        await info.Command(args);
        return true;
    }
}