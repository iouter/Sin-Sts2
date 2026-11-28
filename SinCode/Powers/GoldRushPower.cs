using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Commands.Builders;
using MegaCrit.Sts2.Core.Entities.Powers;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Models;
using Sin.SinCode.Api.Powers;

namespace Sin.SinCode.Powers;

public class GoldRushPower : SinPower
{
    public override PowerType Type => PowerType.Buff;
    public override PowerStackType StackType => PowerStackType.Counter;

    public override async Task AfterAttack(PlayerChoiceContext choiceContext, AttackCommand command)
    {
        var source = command.ModelSource;
        if (source is not CardModel cardSource || cardSource.Owner.Creature != Owner)
        {
            return;
        }

        var player = cardSource.Owner;
        await PlayerCmd.GainGold(Amount, player);
    }
}
