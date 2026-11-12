using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using Sin.SinCode.Api;
using Sin.SinCode.Api.Cards;

namespace Sin.SinCode.Cards.Commons;

public class SneakAttack() : SinCard(0, CardType.Attack, CardRarity.Common, TargetType.AnyEnemy)
{
    protected override IEnumerable<DynamicVar> CanonicalVars =>
        [new IntVar("MinDamage", 1), new IntVar("MaxDamage", 6)];
    public override IEnumerable<CardKeyword> CanonicalKeywords =>
        [CardKeyword.Exhaust, SinKeywords.SneakAttackIsScaryHigh];

    protected override void OnUpgrade()
    {
        DynamicVars["MinDamage"].UpgradeValueBy(1);
        DynamicVars["MaxDamage"].UpgradeValueBy(6);
    }
}
