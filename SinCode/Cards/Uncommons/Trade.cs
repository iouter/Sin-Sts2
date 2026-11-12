using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using Sin.SinCode.Api.Cards;
using Sin.SinCode.Api.DynamicVars;

namespace Sin.SinCode.Cards.Uncommons;

public class Trade() : SinSpendGoldCard(0, CardType.Skill, CardRarity.Uncommon, TargetType.Self)
{
    protected override IEnumerable<DynamicVar> CanonicalVars =>
        [new SpendGoldVar(16), new EnergyVar(1)];

    protected override void OnUpgrade()
    {
        UpgradeGoldValueBy(-4);
    }
}
