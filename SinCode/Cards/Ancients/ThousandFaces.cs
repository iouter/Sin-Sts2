using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using Sin.SinCode.Api;
using Sin.SinCode.Api.Cards;

namespace Sin.SinCode.Cards.Ancients;

public class ThousandFaces() : SinCard(1, CardType.Skill, CardRarity.Ancient, TargetType.AnyEnemy)
{
    public override IEnumerable<CardKeyword> CanonicalKeywords =>
        [SinKeywords.TransformAncient, CardKeyword.Eternal];

    protected override void OnUpgrade()
    {
        EnergyCost.UpgradeBy(-1);
    }
}
