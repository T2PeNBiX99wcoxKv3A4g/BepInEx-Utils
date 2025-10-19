using JetBrains.Annotations;

namespace BepInExUtils.Commands;

[PublicAPI]
public static class CommandManager
{
    public delegate void Command(string[] args);

    public delegate void OnCommandManagerInitEvent();

    private static readonly Dictionary<string, CommandInfo> Infos = [];

    private static readonly List<CommandInfo> DefaultCommands =
    [
        new("help", "Show command infos", _ =>
        {
            var cmdInfos = Infos.Values.Select(cmd => $"{cmd.Name} - {cmd.Description}");
            Utils.Logger.Info($"Available commands:\n{string.Join("\n", cmdInfos)}");
        }),
        new("echo", "Echo args", args => Utils.Logger.Info(string.Join("\n", args)))
    ];

    internal static void Init()
    {
        DefaultCommands.ForEach(AddCommand);
        Utils.Logger.Debug("CommandManager init");
    }

    public static void AddCommand(CommandInfo commandInfo) => Infos.Add(commandInfo.Name, commandInfo);

    public static void AddCommand(string commandName, string description, Command command) =>
        AddCommand(new(commandName, description, command));

    public static bool TryExecuteCommand(string command, params string[] args)
    {
        if (!Infos.TryGetValue(command, out var info)) return false;
        info.Command(args);
        return true;
    }
}