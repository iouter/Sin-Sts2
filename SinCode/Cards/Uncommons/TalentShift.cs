using BaseLib.Utils;
using MegaCrit.Sts2.Core.CardSelection;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Factories;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.CardPools;
using Sin.SinCode.Api.Cards;
using Sin.SinCode.Characters;

namespace Sin.SinCode.Cards.Uncommons;

public class TalentShift() : SinCard(1, CardType.Skill, CardRarity.Uncommon, TargetType.Self)
{
    protected override IEnumerable<DynamicVar> CanonicalVars => [new CardsVar(2)];

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        var cards = (
            await CommonActions.SelectCards(
                this,
                CardSelectorPrefs.ExhaustSelectionPrompt,
                choiceContext,
                PileType.Hand,
                0,
                DynamicVars.Cards.IntValue
            )
        ).ToList();
        if (cards.Count == 0)
        {
            return;
        }

        await CardPileCmd.AddGeneratedCardsToCombat(
            cards.Select(c => CombatState!.CreateCard(GetCardResult(c), Owner)),
            PileType.Hand,
            Owner
        );
    }

    private CardModel GetCardResult(CardModel original)
    {
        var rng = RunState!.Rng.CombatCardGeneration;
        return original.Type is CardType.Curse or CardType.Status
            ? CardFactory.CreateRandomCardForTransform(
                original,
                ModelDb.CardPool<ColorlessCardPool>().AllCards,
                true,
                rng
            )
            : CardFactory.CreateRandomCardForTransform(
                original,
                ModelDb.CardPool<SinCardPool>().AllCards.Where(c => c.Rarity == CardRarity.Rare),
                true,
                rng
            );
    }

    protected override void OnUpgrade()
    {
        DynamicVars.Cards.UpgradeValueBy(1);
    }
}
