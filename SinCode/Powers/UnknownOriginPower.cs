using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Entities.Players;
using MegaCrit.Sts2.Core.Entities.Powers;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using Sin.SinCode.Api.Powers;
using Sin.SinCode.Cards.Uncommons;

namespace Sin.SinCode.Powers;

public class UnknownOriginPower : SinPower
{
    public override PowerType Type => PowerType.Buff;
    public override PowerStackType StackType => PowerStackType.Counter;

    public override async Task AfterPlayerTurnStart(
        PlayerChoiceContext choiceContext,
        Player player
    )
    {
        if (player.Creature != Owner)
        {
            return;
        }
        await PowerCmd.Decrement(this);
    }

    public override async Task AfterCardPlayed(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        var player = cardPlay.Card.Owner;
        if (player.Creature != Owner)
        {
            return;
        }
        if (
            PileType
                .Hand.GetPile(player)
                .Cards.Any(c => c.Type is CardType.Attack or CardType.Skill)
        )
        {
            return;
        }

        PileType[] piles = [PileType.Draw, PileType.Discard];
        var cards = piles.SelectMany(p => p.GetPile(player).Cards).Where(c => c is UnknownOrigin);
        foreach (var card in cards)
        {
            card.EnergyCost.AddThisCombat(1);
            await CardPileCmd.Add(card, PileType.Hand);
        }
        await PowerCmd.Decrement(this);
    }
}
