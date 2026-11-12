using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Relics;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Relics;
using STS2RitsuLib.Patching.Models;

namespace Sin.SinCode.Api.Patches;

public class DragonFruitAfterObtainedPatch : IPatchMethod
{
    public static string PatchId => "dragon_fruit";
    public static string Description => "remove dragon fruit and give another relic";

    public static ModPatchTarget[] GetTargets() =>
        [new(typeof(DragonFruit), nameof(DragonFruit.AfterObtained))];

    static void Postfix(DragonFruit __instance)
    {
        if (__instance.Owner.Character is not Characters.Sin)
        {
            return;
        }
        var rng = __instance.Owner.RunState.Rng.CombatOrbGeneration;
        var relic = rng.NextItem(
            ModelDb.AllRelics.Where(r => r.Rarity == RelicRarity.Shop && r is not DragonFruit)
        );
        if (relic == null)
        {
            return;
        }
        _ = RelicCmd.Replace(__instance, relic);
    }
}
