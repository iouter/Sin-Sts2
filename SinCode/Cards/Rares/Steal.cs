using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using Sin.SinCode.Api.Cards;

namespace Sin.SinCode.Cards.Rares;

public class Steal() : SinCard(1, CardType.Power, CardRarity.Rare, TargetType.Self)
{
    protected override IEnumerable<DynamicVar> CanonicalVars =>
        [new IntVar("Cards", 1), new IntVar("RandomCards", 3)];

    protected override void OnUpgrade()
    {
        DynamicVars["Cards"].UpgradeValueBy(1);
    }
}
