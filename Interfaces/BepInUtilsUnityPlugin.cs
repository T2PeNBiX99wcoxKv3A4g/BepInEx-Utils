using BepInEx;
using JetBrains.Annotations;

namespace BepInExUtils.Interfaces;

public abstract class BepInUtilsUnityPlugin : BaseUnityPlugin
{
    [UsedImplicitly]
    protected abstract void PostAwake();
}