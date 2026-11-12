using BaseLib.Extensions;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models.Powers;
using Sin.SinCode.Api;
using Sin.SinCode.Api.Cards;

namespace Sin.SinCode.Cards.Commons;

public class Lurk() : SinCard(1, CardType.Skill, CardRarity.Common, TargetType.Self)
{
    protected override IEnumerable<DynamicVar> CanonicalVars => [new PowerVar<DexterityPower>(1)];
    public override IEnumerable<CardKeyword> CanonicalKeywords => [SinKeywords.Transform];

    protected override void OnUpgrade()
    {
        DynamicVars.Power<DexterityPower>().UpgradeValueBy(1);
    }
}
