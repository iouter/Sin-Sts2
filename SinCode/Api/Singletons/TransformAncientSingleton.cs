using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Factories;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Models;
using STS2RitsuLib.Interop.AutoRegistration;
using STS2RitsuLib.Models;

namespace Sin.SinCode.Api.Singletons;

[RegisterSingleton]
public class TransformAncientSingleton() : HookedSingletonModel(hookType: HookType.Combat)
{
    public override async Task AfterCardPlayed(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        var card = cardPlay.Card;
        if (!card.Keywords.Contains(SinKeywords.TransformAncient) || card.Type == CardType.Power)
        {
            return;
        }

        var upgradeAmount = card.CurrentUpgradeLevel;
        var energy = card.EnergyCost.GetResolved();

        var rng = CurrentCombatState!.RunState.Rng.CombatCardSelection;
        var result = CardFactory.CreateRandomCardForTransform(
            card,
            ModelDb.AllCards.Where(cardModel =>
                cardModel is { Rarity: CardRarity.Ancient, Type: CardType.Attack or CardType.Skill }
            ),
            true,
            rng
        );
        result.AddKeyword(SinKeywords.TransformAncient);

        for (var i = 0; i < upgradeAmount; i++)
        {
            result.UpgradeInternal();
        }

        result.EnergyCost.SetThisCombat(energy);

        await CardCmd.Transform(card, result);
    }
}
