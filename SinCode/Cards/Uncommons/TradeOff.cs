using BaseLib.Utils;
using MegaCrit.Sts2.Core.CardSelection;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using Sin.SinCode.Api.Cards;

namespace Sin.SinCode.Cards.Uncommons;

public class TradeOff() : SinCard(1, CardType.Skill, CardRarity.Uncommon, TargetType.Self)
{
    protected override IEnumerable<DynamicVar> CanonicalVars => [new CardsVar(2)];

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        var cards = (
            await CommonActions.SelectCards(
                this,
                CardSelectorPrefs.DiscardSelectionPrompt,
                choiceContext,
                PileType.Hand,
                minCount: 0,
                maxCount: DynamicVars.Cards.IntValue
            )
        ).ToList();
        foreach (var card in cards.Where(card => card.Keywords.Contains(CardKeyword.Exhaust)))
        {
            await CardCmd.AutoPlay(choiceContext, card, null);
        }
        await CardPileCmd.Draw(choiceContext, cards.Count, Owner);
    }

    protected override void OnUpgrade()
    {
        DynamicVars.Cards.UpgradeValueBy(1);
    }
}
