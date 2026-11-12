using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models.Powers;
using MegaCrit.Sts2.Core.ValueProps;
using Sin.SinCode.Api.Cards;

namespace Sin.SinCode.Cards.Rares;

public class DazzlingStrike() : SinCard(2, CardType.Attack, CardRarity.Rare, TargetType.AnyEnemy)
{
    protected override IEnumerable<DynamicVar> CanonicalVars =>
        [
            new DamageVar(10, ValueProp.Move),
            new IntVar("TheftThreshold", 15),
            new PowerVar<IntangiblePower>(1),
        ];
    protected override HashSet<CardTag> CanonicalTags => [CardTag.Strike];

    protected override void OnUpgrade()
    {
        DynamicVars.Damage.UpgradeValueBy(6);
        DynamicVars["TheftThreshold"].UpgradeValueBy(-3);
    }
}
