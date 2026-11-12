using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using Sin.SinCode.Api;
using Sin.SinCode.Api.Cards;

namespace Sin.SinCode.Cards.Uncommons;

public class SellOff() : SinCard(1, CardType.Skill, CardRarity.Uncommon, TargetType.Self)
{
    protected override IEnumerable<DynamicVar> CanonicalVars => [new IntVar("GoldMultiplier", 3)];
    public override IEnumerable<CardKeyword> CanonicalKeywords => [SinKeywords.Transform];

    protected override void OnUpgrade()
    {
        DynamicVars["GoldMultiplier"].UpgradeValueBy(2);
    }
}
