using MegaCrit.Sts2.Core.Entities.Cards;
using Sin.SinCode.Characters;
using STS2RitsuLib.Interop.AutoRegistration;

namespace Sin.SinCode.Api.Cards;

[RegisterCard(typeof(SinCardPool), Inherit = true)]
public abstract class SinSpendGoldCard(
    int cost,
    CardType type,
    CardRarity rarity,
    TargetType target
) : SpendGoldCard(cost, type, rarity, target);
