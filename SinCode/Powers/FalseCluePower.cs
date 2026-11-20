using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.Entities.Powers;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.ValueProps;
using Sin.SinCode.Api.Powers;

namespace Sin.SinCode.Powers;

public class FalseCluePower : SinPower
{
    public override PowerType Type => PowerType.Buff;
    public override PowerStackType StackType => PowerStackType.Counter;

    public override async Task AfterPowerAmountChanged(
        PlayerChoiceContext choiceContext,
        PowerModel power,
        decimal amount,
        Creature? applier,
        CardModel? cardSource
    )
    {
        if (power is not Theft || power.Owner != Owner)
        {
            return;
        }
        await CreatureCmd.Damage(
            choiceContext,
            CombatState.HittableEnemies,
            Amount,
            ValueProp.Unpowered,
            Owner
        );
    }
}
