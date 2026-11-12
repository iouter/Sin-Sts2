using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.ValueProps;
using Sin.SinCode.Api.Cards;

namespace Sin.SinCode.Cards.Rares;

public class CoinBurst() : SinCard(1, CardType.Attack, CardRarity.Rare, TargetType.AnyEnemy)
{
    protected override IEnumerable<DynamicVar> CanonicalVars =>
        [new DamageVar(3, ValueProp.Move), new IntVar("TheftMultiplier", 2)];

    protected override void OnUpgrade()
    {
        EnergyCost.UpgradeBy(-1);
    }
}
