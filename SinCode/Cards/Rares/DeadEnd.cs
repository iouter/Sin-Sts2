using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using Sin.SinCode.Api.Cards;

namespace Sin.SinCode.Cards.Rares;

public class DeadEnd() : SinCard(1, CardType.Power, CardRarity.Rare, TargetType.Self)
{
    protected override IEnumerable<DynamicVar> CanonicalVars => [new IntVar("BonusPercent", 25)];

    protected override void OnUpgrade()
    {
        DynamicVars["BonusPercent"].UpgradeValueBy(25);
    }
}
