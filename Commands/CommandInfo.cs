namespace BepInExUtils.Commands;

public readonly record struct CommandInfo(string Name, string Description, CommandManager.Command Command)
{
    public readonly CommandManager.Command Command = Command;
    public readonly string Description = Description;
    public readonly string Name = Name;
}