using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.ValueProps;
using Sin.SinCode.Api;
using Sin.SinCode.Api.Cards;

namespace Sin.SinCode.Cards.Commons;

public class ArmorTheft() : SinCard(3, CardType.Skill, CardRarity.Common, TargetType.Self)
{
    protected override IEnumerable<DynamicVar> CanonicalVars => [new BlockVar(6, ValueProp.Move)];
    public override IEnumerable<CardKeyword> CanonicalKeywords => [SinKeywords.Transform];
    public override bool GainsBlock => true;

    protected override void OnUpgrade()
    {
        EnergyCost.UpgradeBy(-1);
    }
}
