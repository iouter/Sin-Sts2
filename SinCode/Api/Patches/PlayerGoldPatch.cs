using HarmonyLib;
using MegaCrit.Sts2.Core.Entities.Players;
using STS2RitsuLib.Patching.Models;

namespace Sin.SinCode.Api.Patches;

public class PlayerGoldPatch : IPatchMethod
{
    public static string PatchId => "player_gold";
    public static string Description => "sync player's gold and sin's gold";

    public static ModPatchTarget[] GetTargets() =>
        [new(typeof(Player), nameof(Player.Gold), MethodType.Setter)];

    static void Postfix(Player __instance)
    {
        _ = Gold.Set(__instance, __instance.Gold);
    }
}
