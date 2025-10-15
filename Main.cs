using BepInExUtils.Attributes;
using BepInExUtils.Commands;

namespace BepInExUtils;

[BepInUtils("io.github.ykysnk.BepinExUtils", "BepInEx Utils", Version)]
public partial class Main
{
    private const string Version = "0.8.2";

    protected override void PostAwake()
    {
        CommandManager.Init();
    }
}