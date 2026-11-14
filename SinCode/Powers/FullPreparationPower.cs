using BaseLib.Abstracts;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Players;
using MegaCrit.Sts2.Core.Entities.Powers;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models.Powers;
using Sin.SinCode.Api.Powers;

namespace Sin.SinCode.Powers;

public class FullPreparationPower : SinPower, IHasSecondAmount
{
    private const string PowerCount = "PowerAmount";
    public override PowerType Type => PowerType.Buff;
    public override PowerStackType StackType => PowerStackType.Counter;
    protected override IEnumerable<DynamicVar> CanonicalVars => [new(PowerCount, 0)];

    public int PowerAmount
    {
        get => DynamicVars[PowerCount].IntValue;
        set => DynamicVars[PowerCount].BaseValue = value;
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

        await PlayerCmd.GainEnergy(PowerAmount, player);
        await PowerCmd.Apply<TemporaryStrengthPower>(
            choiceContext,
            Owner,
            PowerAmount,
            Owner,
            null
        );
        await PowerCmd.Decrement(this);
    }

    public string GetSecondAmount() => $"{PowerAmount}";
}
