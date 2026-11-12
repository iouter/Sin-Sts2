using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.ValueProps;
using Sin.SinCode.Api.Cards;

namespace Sin.SinCode.Cards.Rares;

public class Elusive() : SinCard(1, CardType.Attack, CardRarity.Rare, TargetType.AnyEnemy)
{
    protected override IEnumerable<DynamicVar> CanonicalVars =>
        [new DamageVar(8, ValueProp.Move), new IntVar("BonusDamage", 8)];

    protected override void OnUpgrade()
    {
        DynamicVars["BonusDamage"].UpgradeValueBy(3);
    }
}
