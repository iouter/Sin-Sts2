using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models.Powers;
using Sin.SinCode.Api;
using Sin.SinCode.Api.Cards;

namespace Sin.SinCode.Cards.Uncommons;

public class Conceal() : SinCard(1, CardType.Skill, CardRarity.Uncommon, TargetType.Self)
{
    protected override IEnumerable<DynamicVar> CanonicalVars => [new PowerVar<IntangiblePower>(1)];
    public override IEnumerable<CardKeyword> CanonicalKeywords => [SinKeywords.Transform];

    protected override void OnUpgrade()
    {
        AddKeyword(CardKeyword.Innate);
    }
}
