using MegaCrit.Sts2.Core.Entities.Cards;
using STS2RitsuLib.Content;
using STS2RitsuLib.Interop.AutoRegistration;
using STS2RitsuLib.Keywords;

namespace Sin.SinCode.Api;

[RegisterOwnedCardKeyword(
    nameof(SneakAttackIsScaryHigh),
    CardDescriptionPlacement = ModKeywordCardDescriptionPlacement.AfterCardDescription
)]
[RegisterOwnedCardKeyword(
    nameof(Transform),
    CardDescriptionPlacement = ModKeywordCardDescriptionPlacement.AfterCardDescription
)]
[RegisterOwnedCardKeyword(
    nameof(TransformAncient),
    CardDescriptionPlacement = ModKeywordCardDescriptionPlacement.AfterCardDescription
)]
public class SinKeywords
{
    public static readonly CardKeyword SneakAttackIsScaryHigh = ModContentRegistry
        .GetQualifiedKeywordId(MainFile.ModId, nameof(SneakAttackIsScaryHigh))
        .GetModCardKeyword();
    public static readonly CardKeyword Transform = ModContentRegistry
        .GetQualifiedKeywordId(MainFile.ModId, nameof(Transform))
        .GetModCardKeyword();
    public static readonly CardKeyword TransformAncient = ModContentRegistry
        .GetQualifiedKeywordId(MainFile.ModId, nameof(TransformAncient))
        .GetModCardKeyword();
}
