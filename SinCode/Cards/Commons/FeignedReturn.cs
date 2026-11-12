using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.ValueProps;
using Sin.SinCode.Api.Cards;

namespace Sin.SinCode.Cards.Commons;

public class FeignedReturn() : SinCard(2, CardType.Attack, CardRarity.Common, TargetType.AllEnemies)
{
    protected override IEnumerable<DynamicVar> CanonicalVars =>
        [new DamageVar(13, ValueProp.Move), new IntVar("Cards", 1)];

    protected override void OnUpgrade()
    {
        DynamicVars["Cards"].UpgradeValueBy(1);
    }
}
