using MegaCrit.Sts2.Core.Entities.Cards;
using STS2RitsuLib.CardTags;
using STS2RitsuLib.Content;
using STS2RitsuLib.Interop.AutoRegistration;

namespace Sin.SinCode.Api;

[RegisterOwnedCardTag(nameof(SpendGold))]
public class SinTags
{
    public static readonly CardTag SpendGold = ModContentRegistry
        .GetQualifiedCardTagId(MainFile.ModId, nameof(SpendGold))
        .GetModCardTag();
}
