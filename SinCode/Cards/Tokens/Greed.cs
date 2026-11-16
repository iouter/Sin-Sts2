using MegaCrit.Sts2.Core.Entities.Cards;
using Sin.SinCode.Api.Cards;

namespace Sin.SinCode.Cards.Tokens;

public class Greed() : SinCard(-1, CardType.Curse, CardRarity.Status, TargetType.Self)
{
    public override IEnumerable<CardKeyword> CanonicalKeywords =>
        [CardKeyword.Retain, CardKeyword.Unplayable];
}
