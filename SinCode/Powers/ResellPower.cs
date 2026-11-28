using MegaCrit.Sts2.Core.Combat;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.Entities.Powers;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using Sin.SinCode.Api.Powers;

namespace Sin.SinCode.Powers;

public class ResellPower : SinPower
{
    public override PowerType Type => PowerType.Buff;
    public override PowerStackType StackType => PowerStackType.Single;

    public override Task AfterSideTurnEnd(
        PlayerChoiceContext choiceContext,
        CombatSide side,
        IEnumerable<Creature> participants
    )
    {
        if (side != CombatSide.Player || Owner.Player == null)
        {
            return Task.CompletedTask;
        }
        var player = Owner.Player;
        var cards = PileType.Discard.GetPile(player).Cards.ToList();
        foreach (var card in cards)
        {
            if (card.Keywords.Contains(CardKeyword.Exhaust))
            {
                card.RemoveKeyword(CardKeyword.Exhaust);
            }
            else
            {
                card.AddKeyword(CardKeyword.Exhaust);
            }
        }
        return Task.CompletedTask;
    }
}
