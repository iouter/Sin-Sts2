using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models.Powers;
using Sin.SinCode.Api.Cards;
using Sin.SinCode.Powers;

namespace Sin.SinCode.Cards.Rares;

public class Excited() : SinCard(1, CardType.Power, CardRarity.Rare, TargetType.Self)
{
    protected override IEnumerable<DynamicVar> CanonicalVars => [new PowerVar<Theft>(5)];

    protected override void OnUpgrade()
    {
        AddKeyword(CardKeyword.Innate);
    }
}
