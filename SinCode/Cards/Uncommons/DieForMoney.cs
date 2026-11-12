using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using Sin.SinCode.Api.Cards;

namespace Sin.SinCode.Cards.Uncommons;

public class DieForMoney() : SinCard(1, CardType.Skill, CardRarity.Uncommon, TargetType.Self)
{
    protected override IEnumerable<DynamicVar> CanonicalVars => [new IntVar("GoldMultiplier", 1)];

    protected override void OnUpgrade()
    {
        DynamicVars["GoldMultiplier"].UpgradeValueBy(1);
    }
}
