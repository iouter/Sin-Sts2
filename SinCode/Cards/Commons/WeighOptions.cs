using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.ValueProps;
using Sin.SinCode.Api.Cards;

namespace Sin.SinCode.Cards.Commons;

public class WeighOptions() : SinCard(1, CardType.Skill, CardRarity.Common, TargetType.Self)
{
    protected override IEnumerable<DynamicVar> CanonicalVars =>
        [new BlockVar(5, ValueProp.Move), new IntVar("PerTheft", 1)];
    public override bool GainsBlock => true;

    protected override void OnUpgrade()
    {
        DynamicVars["PerTheft"].UpgradeValueBy(1);
    }
}
