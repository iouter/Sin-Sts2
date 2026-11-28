using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Entities.Players;
using MegaCrit.Sts2.Core.Entities.Powers;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Models;
using Sin.SinCode.Api.Powers;
using STS2RitsuLib.Combat.SecondaryResources;

namespace Sin.SinCode.Powers;

public class RepeatOffenderPower : SinPower, ISecondaryResourceHookListener
{
    public override PowerType Type => PowerType.Buff;
    public override PowerStackType StackType => PowerStackType.Counter;

    protected override object InitInternalData() => new Data();

    public override bool TryModifyEnergyCostInCombatLate(
        CardModel card,
        decimal originalCost,
        out decimal modifiedCost
    )
    {
        modifiedCost = originalCost;
        if (!ShouldModifyCost(card))
            return false;
        modifiedCost = 0;
        return true;
    }

    private bool ShouldModifyCost(CardModel card) =>
        card.Owner.Creature == Owner
        && (
            card.Keywords.Contains(CardKeyword.Exhaust)
            || card.Keywords.Contains(CardKeyword.Ethereal)
                && GetInternalData<Data>().CardPlayed > Amount
        );

    public override bool TryModifyStarCost(
        CardModel card,
        decimal originalCost,
        out decimal modifiedCost
    )
    {
        modifiedCost = originalCost;
        if (!ShouldModifyCost(card))
            return false;
        modifiedCost = 0;
        return true;
    }

    public decimal ModifySecondaryResourceCostLate(
        SecondaryResourceCostContext context,
        decimal cost
    )
    {
        return !ShouldModifyCost(context.Card) ? cost : 0;
    }

    public override Task AfterCardPlayed(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        var card = cardPlay.Card;
        if (ShouldModifyCost(card))
        {
            GetInternalData<Data>().CardPlayed++;
        }
        return Task.CompletedTask;
    }

    public override Task AfterPlayerTurnStart(PlayerChoiceContext choiceContext, Player player)
    {
        GetInternalData<Data>().CardPlayed = 0;
        return Task.CompletedTask;
    }

    private class Data
    {
        public int CardPlayed;
    }
}
