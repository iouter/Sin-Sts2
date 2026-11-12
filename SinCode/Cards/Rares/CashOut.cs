using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using Sin.SinCode.Api.Cards;

namespace Sin.SinCode.Cards.Rares;

public class CashOut() : SinCard(2, CardType.Power, CardRarity.Rare, TargetType.Self)
{
    protected override void OnUpgrade()
    {
        EnergyCost.UpgradeBy(-1);
    }
}
