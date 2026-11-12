using MegaCrit.Sts2.Core.Entities.Relics;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models.Powers;
using MegaCrit.Sts2.Core.ValueProps;
using Sin.SinCode.Api.Relics;
using Sin.SinCode.Powers;

namespace Sin.SinCode.Relics;

public class CardBelt : SinRelic
{
    public override RelicRarity Rarity => RelicRarity.Rare;

    protected override IEnumerable<DynamicVar> CanonicalVars => [new IntVar("Cards", 3)];
}
