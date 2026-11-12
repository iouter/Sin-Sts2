using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using Sin.SinCode.Api.Cards;

namespace Sin.SinCode.Cards.Rares;

public class Burst() : SinCard(1, CardType.Skill, CardRarity.Rare, TargetType.Self)
{
    protected override IEnumerable<DynamicVar> CanonicalVars =>
        [new EnergyVar(5), new IntVar("CostIncrease", 2)];

    protected override void OnUpgrade()
    {
        DynamicVars["CostIncrease"].UpgradeValueBy(-1);
    }
}
