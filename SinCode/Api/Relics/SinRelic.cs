using Sin.SinCode.Characters;
using STS2RitsuLib.Interop.AutoRegistration;
using STS2RitsuLib.Scaffolding.Content;

namespace Sin.SinCode.Api.Relics;

[RegisterRelic(typeof(SinRelicPool), Inherit = true)]
public abstract class SinRelic : ModRelicTemplate
{
    public override RelicAssetProfile AssetProfile =>
        new(
            IconPath: $"res://Sin/images/relics/{GetType().Name}.png",
            IconOutlinePath: $"res://Sin/images/relics/outline/{GetType().Name}.png",
            BigIconPath: $"res://Sin/images/relics/big/{GetType().Name}.png"
        );
}
