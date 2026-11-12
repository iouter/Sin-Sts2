using BaseLib.Utils;
using MegaCrit.Sts2.Core.CardSelection;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Factories;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Random;
using Sin.SinCode.Api.Cards;
using Sin.SinCode.Characters;

namespace Sin.SinCode.Cards.Commons;

public class Chameleon() : SinCard(0, CardType.Skill, CardRarity.Common, TargetType.Self)
{
    protected override IEnumerable<DynamicVar> CanonicalVars => [new CardsVar(1)];

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        var count = DynamicVars.Cards.IntValue;
        var rng = Owner.RunState.Rng.CombatCardGeneration;

        var cards = await CommonActions.SelectCards(
            this,
            CardSelectorPrefs.TransformSelectionPrompt,
            choiceContext,
            PileType.Hand,
            count: count
        );
        var results = cards.Select(c => new CardTransformation(c, TransformCard(c, rng)));

        await CardCmd.Transform(results, rng);
    }

    private static CardModel TransformCard(CardModel original, Rng rng)
    {
        return original.Type is CardType.Curse or CardType.Status
            ? CardFactory.CreateRandomCardForTransform(
                original,
                ModelDb.CardPool<SinCardPool>().AllCards.Where(c => c.Rarity == CardRarity.Common),
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
