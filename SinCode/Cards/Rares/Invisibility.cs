using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models.Powers;
using Sin.SinCode.Api.Cards;

namespace Sin.SinCode.Cards.Rares;

public class Invisibility() : SinCard(0, CardType.Power, CardRarity.Rare, TargetType.Self)
{
    protected override IEnumerable<DynamicVar> CanonicalVars =>
        [new PowerVar<DexterityPower>(5), new PowerVar<StrengthPower>(-3)];

    protected override void OnUpgrade()
    {
        AddKeyword(CardKeyword.Innate);
    }
}
