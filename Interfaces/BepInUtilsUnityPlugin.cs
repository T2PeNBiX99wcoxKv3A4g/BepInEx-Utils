using BepInEx;
using JetBrains.Annotations;

namespace BepInExUtils.Interfaces;

[PublicAPI]
public abstract class BepInUtilsUnityPlugin : BaseUnityPlugin
{
    protected abstract void PostAwake();
}