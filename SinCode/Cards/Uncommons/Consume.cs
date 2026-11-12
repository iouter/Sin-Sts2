using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.ValueProps;
using Sin.SinCode.Api.Cards;

namespace Sin.SinCode.Cards.Uncommons;

public class Consume() : SinCard(0, CardType.Attack, CardRarity.Uncommon, TargetType.RandomEnemy)
{
    protected override IEnumerable<DynamicVar> CanonicalVars =>
        [new DamageVar(15, ValueProp.Move), new IntVar("GoldLoss", 6)];
    protected override bool HasEnergyCostX => true;

    protected override void OnUpgrade()
    {
        DynamicVars["GoldLoss"].UpgradeValueBy(-3);
    }
}
