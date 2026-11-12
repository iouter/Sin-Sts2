using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.ValueProps;
using Sin.SinCode.Api.Cards;

namespace Sin.SinCode.Cards.Rares;

public class VanishingTrick() : SinCard(6, CardType.Attack, CardRarity.Rare, TargetType.AnyEnemy)
{
    protected override IEnumerable<DynamicVar> CanonicalVars => [new DamageVar(60, ValueProp.Move)];

    protected override void OnUpgrade()
    {
        DynamicVars.Damage.UpgradeValueBy(15);
    }
}
