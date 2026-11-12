using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using STS2RitsuLib.Interop.AutoRegistration;
using STS2RitsuLib.Models;

namespace Sin.SinCode.Api.Singletons;

[RegisterSingleton]
public class SneakAttackIsScaryHighSingleton() : HookedSingletonModel(hookType: HookType.Combat)
{
    public override Task AfterCardPlayed(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        var card = cardPlay.Card;
        if (!card.Keywords.Contains(SinKeywords.SneakAttackIsScaryHigh))
        {
            return Task.CompletedTask;
        }
        CardCmd.Upgrade(card);
        return Task.CompletedTask;
    }
}
