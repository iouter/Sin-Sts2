using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Entities.Powers;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Models;
using Sin.SinCode.Api.Powers;

namespace Sin.SinCode.Powers;

public class StealingSpreePower : SinPower
{
    public override PowerType Type => PowerType.Buff;
    public override PowerStackType StackType => PowerStackType.Counter;

    public override async Task AfterCardDrawn(
        PlayerChoiceContext choiceContext,
        CardModel card,
        bool fromHandDraw
    )
    {
        if (card.Owner.Creature != Owner || card.Keywords.Contains(CardKeyword.Exhaust))
        {
            return;
        }

        await CardPileCmd.Draw(choiceContext, Amount, card.Owner);
    }
}
