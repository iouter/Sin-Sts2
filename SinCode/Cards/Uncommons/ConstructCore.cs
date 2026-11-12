using BaseLib.Extensions;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models.Powers;
using Sin.SinCode.Api;
using Sin.SinCode.Api.Cards;
using Sin.SinCode.Api.DynamicVars;

namespace Sin.SinCode.Cards.Uncommons;

public class ConstructCore()
    : SinSpendGoldCard(2, CardType.Skill, CardRarity.Uncommon, TargetType.Self)
{
    protected override IEnumerable<DynamicVar> CanonicalVars =>
        [new SpendGoldVar(10), new PowerVar<ArtifactPower>(1)];
    public override IEnumerable<CardKeyword> CanonicalKeywords => [SinKeywords.Transform];

    protected override void OnUpgrade()
    {
        DynamicVars.Power<ArtifactPower>().UpgradeValueBy(1);
    }
}
