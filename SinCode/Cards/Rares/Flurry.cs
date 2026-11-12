using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.ValueProps;
using Sin.SinCode.Api.Cards;

namespace Sin.SinCode.Cards.Rares;

public class Flurry() : SinCard(1, CardType.Attack, CardRarity.Rare, TargetType.Self)
{
    protected override IEnumerable<DynamicVar> CanonicalVars =>
        [new CardsVar(2), new DamageVar(3, ValueProp.Move)];

    protected override void OnUpgrade()
    {
        EnergyCost.UpgradeBy(-1);
    }
}
