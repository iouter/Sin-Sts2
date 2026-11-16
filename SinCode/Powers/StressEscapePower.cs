using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.Entities.Players;
using MegaCrit.Sts2.Core.Entities.Powers;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.ValueProps;
using Sin.SinCode.Api;
using Sin.SinCode.Api.Powers;
using Sin.SinCode.Characters;

namespace Sin.SinCode.Powers;

public class StressEscapePower : SinPower
{
    public override PowerType Type => PowerType.Debuff;
    public override PowerStackType StackType => PowerStackType.Counter;

    protected override object InitInternalData() => new Data();

    public override Task AfterDamageReceived(
        PlayerChoiceContext choiceContext,
        Creature target,
        DamageResult result,
        ValueProp props,
        Creature? _,
        CardModel? __
    )
    {
        if (target != Owner || !props.IsPoweredAttack() || result.UnblockedDamage <= 0)
            return Task.CompletedTask;
        Flash();
        GetInternalData<Data>().IsAttacked = true;
        return Task.CompletedTask;
    }

    public override async Task AfterPlayerTurnStart(
        PlayerChoiceContext choiceContext,
        Player player
    )
    {
        if (player.Creature != Owner)
        {
            return;
        }
        await ApplyTransformIfAttacked(player);
        await PowerCmd.Remove(this);
    }

    private async Task ApplyTransformIfAttacked(Player player)
    {
        if (!GetInternalData<Data>().IsAttacked)
            return;

        var handCards = PileType.Hand.GetPile(player).Cards.ToList();
        if (handCards.Count == 0)
            return;

        player.RunState.Rng.CombatCardSelection.Shuffle(handCards);

        var take = Math.Clamp(Amount, 0, handCards.Count);
        if (take == 0)
            return;

        var selected = handCards.GetRange(0, take);

        await SinUtils.Transform(
            player,
            selected.ToArray(),
            ModelDb.CardPool<SinCardPool>(),
            c => c.Rarity == CardRarity.Common
        );
    }

    private class Data
    {
        public bool IsAttacked = false;
    }
}
