using BepInExUtils.Attributes;
using BepInExUtils.Commands;

namespace BepInExUtils;

[BepInUtils("io.github.ykysnk.BepinExUtils", "BepInEx Utils", Version)]
public partial class Main
{
    private const string Version = "0.9.1";

    public void Init()
    {
        CommandManager.Init();
    }
}