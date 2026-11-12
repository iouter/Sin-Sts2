using BaseLib.Extensions;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Creatures;
using MegaCrit.Sts2.Core.Entities.Powers;
using MegaCrit.Sts2.Core.Entities.Relics;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models;
using Sin.SinCode.Api.Relics;
using Sin.SinCode.Powers;
using STS2RitsuLib.Interop.AutoRegistration;

namespace Sin.SinCode.Relics;

[RegisterCharacterStarterRelic(typeof(Characters.Sin))]
public class ThiefHeart : SinRelic
{
    public override RelicRarity Rarity => RelicRarity.Starter;
    protected override IEnumerable<DynamicVar> CanonicalVars => [new PowerVar<Theft>(1)];

    public override async Task AfterPowerAmountChanged(
        PlayerChoiceContext choiceContext,
        PowerModel power,
        decimal amount,
        Creature? applier,
        CardModel? cardSource
    )
    {
        if (power.Owner != Owner.Creature)
        {
            return;
        }

        if (power.Type != PowerType.Buff)
        {
            return;
        }

        if (amount < 0)
        {
            return;
        }
        await PowerCmd.Apply<Theft>(
            choiceContext,
            Owner.Creature,
            DynamicVars.Power<Theft>().BaseValue,
            Owner.Creature,
            null
        );
    }
}
