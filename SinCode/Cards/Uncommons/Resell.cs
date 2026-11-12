using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using Sin.SinCode.Api.Cards;

namespace Sin.SinCode.Cards.Uncommons;

public class Resell() : SinCard(2, CardType.Power, CardRarity.Uncommon, TargetType.Self)
{
    protected override void OnUpgrade()
    {
        EnergyCost.UpgradeBy(-1);
    }
}
