using MegaCrit.Sts2.Core.Commands;
using STS2RitsuLib.Combat.SecondaryResources;
using STS2RitsuLib.Interop.AutoRegistration;
using STS2RitsuLib.Models;

namespace Sin.SinCode.Api.Singletons;

[RegisterSingleton]
public class GoldSingleton()
    : HookedSingletonModel(hookType: HookType.Run),
        ISecondaryResourceHookListener
{
    public async Task AfterSecondaryResourceChanged(SecondaryResourceChangeContext context)
    {
        if (context.Definition != Gold.Definition)
        {
            return;
        }
        var player = context.Player;
        await PlayerCmd.SetGold(Gold.Get(player), player);
    }

    public async Task AfterSecondaryResourceSpent(SecondaryResourceSpendContext context)
    {
        if (context.Definition != Gold.Definition)
        {
            return;
        }
        var player = context.Player;
        await PlayerCmd.SetGold(Gold.Get(player), player);
    }

    public override async Task BeforeCombatStart()
    {
        var players = CurrentRunState?.Players;
        if (players == null)
            return;
        foreach (var player in players)
        {
            await Gold.Set(player, player.Gold);
        }
    }
}
