using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using Sin.SinCode.Api.Cards;

namespace Sin.SinCode.Cards.Uncommons;

public class Fine() : SinCard(1, CardType.Skill, CardRarity.Uncommon, TargetType.Self)
{
    protected override IEnumerable<DynamicVar> CanonicalVars => [new GoldVar(3)];

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        var cards = PileType.Exhaust.GetPile(Owner).Cards.Where(c => c.Type == CardType.Skill);
        foreach (var card in cards)
        {
            await CardCmd.AutoPlay(choiceContext, card, null);
            if (card.Pile != null && card.Pile.Type != PileType.Discard)
            {
                await CardPileCmd.Add(card, PileType.Discard);
            }
            await PlayerCmd.LoseGold(DynamicVars.Gold.IntValue, Owner);
        }
    }

    protected override void OnUpgrade()
    {
        DynamicVars.Gold.UpgradeValueBy(-1);
    }
}
