using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using Sin.SinCode.Api.Cards;
using Sin.SinCode.Api.DynamicVars;

namespace Sin.SinCode.Cards.Uncommons;

public class Appreciate()
    : SinSpendGoldCard(1, CardType.Skill, CardRarity.Uncommon, TargetType.Self)
{
    protected override IEnumerable<DynamicVar> CanonicalVars => [new SpendGoldVar(15)];
    public override IEnumerable<CardKeyword> CanonicalKeywords => [CardKeyword.Exhaust];

    protected override void OnUpgrade()
    {
        EnergyCost.UpgradeBy(-1);
    }
}
