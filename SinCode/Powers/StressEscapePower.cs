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
    public override PowerStackType StackType => PowerStackType.Single;

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
        if (GetInternalData<Data>().IsAttacked)
        {
            var card = player.RunState.Rng.CombatCardSelection.NextItem(
                PileType.Hand.GetPile(player).Cards
            );
            if (card != null)
            {
                await SinUtils.Transform(
                    player,
                    card,
                    ModelDb.CardPool<SinCardPool>(),
                    c => c.Rarity == CardRarity.Common
                );
            }
        }

        await PowerCmd.Remove(this);
    }

    private class Data
    {
        public bool IsAttacked = false;
    }
}
