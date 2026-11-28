using BaseLib.Abstracts;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Players;
using MegaCrit.Sts2.Core.Entities.Powers;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models;
using Sin.SinCode.Api;
using Sin.SinCode.Api.Powers;

namespace Sin.SinCode.Powers;

public class EverChangingPower : SinPower, IHasSecondAmount
{
    private const string LoseAmount = "LoseAmount";
    public override PowerType Type => PowerType.Buff;
    public override PowerStackType StackType => PowerStackType.Counter;

    protected override IEnumerable<DynamicVar> CanonicalVars => [new(LoseAmount, 0)];

    public int Lose
    {
        get => DynamicVars[LoseAmount].IntValue;
        set => DynamicVars[LoseAmount].BaseValue = value;
    }

    public string GetSecondAmount() => $"{Lose}";

    public override async Task AfterPlayerTurnStart(
        PlayerChoiceContext choiceContext,
        Player player
    )
    {
        if (player.Creature != Owner)
        {
            return;
        }
        var rng = player.RunState.Rng.CombatOrbGeneration;
        var playerPowers = Owner
            .Powers.Where(p =>
                p.Type == PowerType.Buff && p is not Theft && p is not EverChangingPower
            )
            .ToList();
        var removePowers = playerPowers.TakeRandomUpTo(rng, Lose);
        foreach (var power in removePowers)
        {
            await PowerCmd.Remove(power);
        }
        var allPowers = ModelDb.AllPowers.Where(p => p.Type == PowerType.Buff).ToList();
        var addPowers = allPowers.TakeRandomUpTo(rng, Amount);
        foreach (var power in addPowers)
        {
            await PowerCmd.Apply(choiceContext, power, Owner, 1, Owner, null);
        }
    }
}
