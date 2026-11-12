using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.ValueProps;
using Sin.SinCode.Api.Cards;

namespace Sin.SinCode.Cards.Rares;

public class Hoarder() : SinCard(2, CardType.Attack, CardRarity.Rare, TargetType.AnyEnemy)
{
    protected override IEnumerable<DynamicVar> CanonicalVars =>
        [new DamageVar(35, ValueProp.Move), new IntVar("BonusPerCard", 4)];

    protected override void OnUpgrade()
    {
        DynamicVars["BonusPerCard"].UpgradeValueBy(1);
    }
}
