using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Players;
using MegaCrit.Sts2.Core.Entities.Powers;
using MegaCrit.Sts2.Core.ValueProps;
using Sin.SinCode.Api.Powers;

namespace Sin.SinCode.Powers;

public class AccumulatePower : SinPower
{
    public override PowerType Type => PowerType.Buff;
    public override PowerStackType StackType => PowerStackType.Single;

    public override async Task AfterModifyingGoldGained(Player player, decimal amount)
    {
        if (Owner != player.Creature)
        {
            return;
        }
        await CreatureCmd.GainBlock(Owner, amount, ValueProp.Move, null);
    }
}
