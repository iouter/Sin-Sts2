using BaseLib.Utils;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using Sin.SinCode.Api.Cards;

namespace Sin.SinCode.Cards.Commons;

public class SortLoot() : SinCard(1, CardType.Skill, CardRarity.Common, TargetType.Self)
{
    protected override IEnumerable<DynamicVar> CanonicalVars => [new CardsVar(3)];
    public override IEnumerable<CardKeyword> CanonicalKeywords => [CardKeyword.Retain];

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        var cards = await CommonActions.SelectCards(
            this,
            SelectionScreenPrompt,
            choiceContext,
            PileType.Hand,
            count: DynamicVars.Cards.IntValue
        );
        foreach (var card in cards)
        {
            card.AddKeyword(CardKeyword.Ethereal);
        }
    }

    protected override void OnUpgrade()
    {
        EnergyCost.UpgradeBy(-1);
    }
}
