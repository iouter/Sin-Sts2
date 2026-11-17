using BaseLib.Utils;
using MegaCrit.Sts2.Core.CardSelection;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using Sin.SinCode.Api;
using Sin.SinCode.Api.Cards;
using Sin.SinCode.Cards.Tokens;

namespace Sin.SinCode.Cards.Uncommons;

public class SlipAway() : SinCard(1, CardType.Skill, CardRarity.Uncommon, TargetType.Self)
{
    protected override IEnumerable<DynamicVar> CanonicalVars => [new CardsVar(3)];
    public override IEnumerable<CardKeyword> CanonicalKeywords => [SinKeywords.Transform];

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        var count = (
            await CommonActions.SelectCards(
                this,
                CardSelectorPrefs.ExhaustSelectionPrompt,
                choiceContext,
                PileType.Hand,
                count: DynamicVars.Cards.IntValue
            )
        ).Count();
        await CardPileCmd.AddGeneratedCardsToCombat(
            Enumerable.Range(0, count).Select(_ => CombatState!.CreateCard<Escape>(Owner)).ToList(),
            PileType.Hand,
            Owner
        );
    }

    protected override void OnUpgrade()
    {
        AddKeyword(CardKeyword.Retain);
    }
}
