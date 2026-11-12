using System.Reflection;
using Godot;
using Godot.Bridge;
using HarmonyLib;
using MegaCrit.Sts2.Core.Logging;
using MegaCrit.Sts2.Core.Modding;
using Sin.SinCode.Api;
using Sin.SinCode.Api.Patches;
using STS2RitsuLib;
using STS2RitsuLib.Interop;
using STS2RitsuLib.Patching.Core;
using Logger = MegaCrit.Sts2.Core.Logging.Logger;

namespace Sin.SinCode;

[ModInitializer(nameof(Initialize))]
public partial class MainFile : Node
{
    public const string ModId = "Sin"; //At the moment, this is used only for the Logger and harmony names.

    public static Logger Logger { get; } = new(ModId, LogType.Generic);

    private static void InitializeTools()
    {
        var assembly = Assembly.GetExecutingAssembly();
        ScriptManagerBridge.LookupScriptsInAssembly(assembly);
    }

    public static void Initialize()
    {
        ModTypeDiscoveryHub.RegisterModAssembly(ModId, Assembly.GetExecutingAssembly());
        Gold.Register();

        var patcher = RitsuLibFramework.CreatePatcher(ModId, "sin-patches");
        patcher.RegisterPatch<PlayerGoldPatch>();

        if (!patcher.PatchAll())
            throw new InvalidOperationException("Critical patches failed.");

        Harmony harmony = new(ModId);
        InitializeTools();
        harmony.PatchAll();
    }
}
