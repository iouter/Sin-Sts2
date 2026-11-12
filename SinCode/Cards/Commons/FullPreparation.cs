using BaseLib.Extensions;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models.Powers;
using Sin.SinCode.Api.Cards;

namespace Sin.SinCode.Cards.Commons;

public class FullPreparation() : SinCard(1, CardType.Skill, CardRarity.Common, TargetType.Self)
{
    protected override IEnumerable<DynamicVar> CanonicalVars =>
        [new IntVar("Turns", 2), new EnergyVar(1), new PowerVar<TemporaryStrengthPower>(1)];

    protected override void OnUpgrade()
    {
        DynamicVars.Energy.UpgradeValueBy(1);
        DynamicVars.Power<TemporaryStrengthPower>().UpgradeValueBy(1);
    }
}
