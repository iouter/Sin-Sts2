using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using Sin.SinCode.Api;
using Sin.SinCode.Api.Cards;

namespace Sin.SinCode.Cards.Uncommons;

public class ReactiveDefense()
    : SinCard(1, CardType.Skill, CardRarity.Uncommon, TargetType.AnyEnemy)
{
    protected override IEnumerable<DynamicVar> CanonicalVars => [new CardsVar(5)];

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        var target = cardPlay.Target;

        if (target?.Monster is { IntendsToAttack: false })
        {
            return;
        }

        var piles = PileType.Draw.GetPile(Owner).Cards.Where(c => c.GainsBlock).ToList();
        var cards = SinUtils.TakeRandomUpTo(piles, this);
        if (cards.Count == 0)
        {
            return;
        }

        await CardPileCmd.Add(cards, PileType.Hand);
    }

    protected override void OnUpgrade()
    {
        AddKeyword(CardKeyword.Retain);
    }
}
