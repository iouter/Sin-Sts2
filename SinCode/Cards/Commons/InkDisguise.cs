using BaseLib.Extensions;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models.Powers;
using Sin.SinCode.Api.Cards;
using Sin.SinCode.Powers;

namespace Sin.SinCode.Cards.Commons;

public class InkDisguise() : SinCard(1, CardType.Skill, CardRarity.Common, TargetType.Self)
{
    protected override IEnumerable<DynamicVar> CanonicalVars => [new PowerVar<SlipperyPlayer>(1)];
    public override IEnumerable<CardKeyword> CanonicalKeywords => [CardKeyword.Exhaust];

    protected override void OnUpgrade()
    {
        DynamicVars.Power<SlipperyPlayer>().UpgradeValueBy(1);
    }
}
