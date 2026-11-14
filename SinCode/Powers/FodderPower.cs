using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Entities.Powers;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Models;
using Sin.SinCode.Api;
using Sin.SinCode.Api.Powers;
using STS2RitsuLib.Combat.SecondaryResources;

namespace Sin.SinCode.Powers;

public class FodderPower : SinPower, ISecondaryResourceHookListener
{
    public override PowerType Type => PowerType.Buff;
    public override PowerStackType StackType => PowerStackType.Counter;

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
        card.Owner.Creature == Owner && card.Keywords.Contains(SinKeywords.Transform);

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

    public override async Task AfterCardPlayed(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        var card = cardPlay.Card;
        if (!ShouldModifyCost(card))
        {
            return;
        }

        await PowerCmd.Decrement(this);
    }
}
