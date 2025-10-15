using BepInEx;
using JetBrains.Annotations;

namespace BepInExUtils.Interfaces;

[PublicAPI]
[Obsolete("Use IBepInUtils instead")]
public abstract class BepInUtilsUnityPlugin : BaseUnityPlugin
{
    protected abstract void PostAwake();
}