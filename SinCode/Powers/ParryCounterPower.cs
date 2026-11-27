using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Powers;
using Sin.SinCode.Cards.Uncommons;
using STS2RitsuLib.Interop.AutoRegistration;

namespace Sin.SinCode.Powers;

[RegisterPower]
public class ParryCounterPower : TemporaryThornsPower
{
    public override AbstractModel OriginModel => ModelDb.Card<ParryCounter>();
}
