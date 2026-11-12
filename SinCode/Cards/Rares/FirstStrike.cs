using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.ValueProps;
using Sin.SinCode.Api.Cards;

namespace Sin.SinCode.Cards.Rares;

public class FirstStrike() : SinCard(0, CardType.Attack, CardRarity.Rare, TargetType.AnyEnemy)
{
    protected override IEnumerable<DynamicVar> CanonicalVars => [new DamageVar(18, ValueProp.Move)];
    public override IEnumerable<CardKeyword> CanonicalKeywords =>
        [CardKeyword.Innate, CardKeyword.Exhaust];

    protected override void OnUpgrade()
    {
        DynamicVars.Damage.UpgradeValueBy(4);
    }
}
