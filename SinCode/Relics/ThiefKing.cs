using MegaCrit.Sts2.Core.Entities.Relics;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models.Powers;
using MegaCrit.Sts2.Core.ValueProps;
using Sin.SinCode.Api.Relics;
using Sin.SinCode.Powers;

namespace Sin.SinCode.Relics;

public class ThiefKing : SinRelic
{
    public override RelicRarity Rarity => RelicRarity.Ancient;

    protected override IEnumerable<DynamicVar> CanonicalVars => [new PowerVar<Theft>(2)];
}
