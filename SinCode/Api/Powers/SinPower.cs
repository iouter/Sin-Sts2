using STS2RitsuLib.Interop.AutoRegistration;
using STS2RitsuLib.Scaffolding.Content;

namespace Sin.SinCode.Api.Powers;

[RegisterPower(Inherit = true)]
public abstract class SinPower : ModPowerTemplate
{
    public override PowerAssetProfile AssetProfile =>
        new(
            IconPath: $"res://Sin/images/powers/{GetType().Name}.png",
            BigIconPath: $"res://Sin/images/powers/big/{GetType().Name}.png"
        );
}
