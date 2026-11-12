using MegaCrit.Sts2.Core.Entities.Cards;
using STS2RitsuLib.Scaffolding.Content;

namespace Sin.SinCode.Api.Cards;

public abstract class SinBaseCard(int cost, CardType type, CardRarity rarity, TargetType target)
    : ModCardTemplate(cost, type, rarity, target)
{
    public override CardAssetProfile AssetProfile =>
        new(
            PortraitPath: $"res://Sin/images/cards/{GetType().Name}.png",
            BetaPortraitPath: $"res://Sin/images/cards/beta/{GetType().Name}.png"
        );
}
