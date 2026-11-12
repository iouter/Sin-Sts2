using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Factories;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Models;
using Sin.SinCode.Characters;
using STS2RitsuLib.Interop.AutoRegistration;
using STS2RitsuLib.Models;

namespace Sin.SinCode.Api.Singletons;

[RegisterSingleton]
public class TransformSingleton() : HookedSingletonModel(hookType: HookType.Combat)
{
    public override async Task AfterCardPlayed(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        var card = cardPlay.Card;
        if (!card.Keywords.Contains(SinKeywords.Transform) || card.Type == CardType.Power)
        {
            return;
        }

        var upgradeAmount = card.CurrentUpgradeLevel;

        var rng = CurrentCombatState!.RunState.Rng.CombatCardSelection;

        var result = card.Type is CardType.Curse or CardType.Status
            ? CardFactory.CreateRandomCardForTransform(
                card,
                ModelDb.CardPool<SinCardPool>().AllCards,
                true,
                rng
            )
            : CardFactory.CreateRandomCardForTransform(card, true, rng);

        result.AddKeyword(SinKeywords.Transform);

        for (var i = 0; i < upgradeAmount; i++)
        {
            result.UpgradeInternal();
        }

        await CardCmd.Transform(card, result);
    }
}
