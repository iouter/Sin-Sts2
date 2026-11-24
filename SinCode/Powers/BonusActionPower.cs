using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Entities.Players;
using MegaCrit.Sts2.Core.Entities.Powers;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using Sin.SinCode.Api.Powers;

namespace Sin.SinCode.Powers;

public class BonusActionPower : SinPower
{
    public override PowerType Type => PowerType.Buff;
    public override PowerStackType StackType => PowerStackType.Counter;

    public override async Task AfterCardPlayed(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        var card = cardPlay.Card;
        if (Owner != card.Owner.Creature || card.Type != CardType.Attack)
        {
            return;
        }

        await CardPileCmd.Draw(choiceContext, card.Owner);
    }

    public override async Task AfterPlayerTurnStart(
        PlayerChoiceContext choiceContext,
        Player player
    )
    {
        await PowerCmd.Decrement(this);
    }
}
