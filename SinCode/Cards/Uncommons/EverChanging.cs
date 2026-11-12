using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using Sin.SinCode.Api.Cards;

namespace Sin.SinCode.Cards.Uncommons;

public class EverChanging() : SinCard(3, CardType.Power, CardRarity.Uncommon, TargetType.Self)
{
    protected override IEnumerable<DynamicVar> CanonicalVars =>
        [new IntVar("LoseCount", 1), new IntVar("GainCount", 2)];

    protected override void OnUpgrade()
    {
        EnergyCost.UpgradeBy(-1);
    }
}
