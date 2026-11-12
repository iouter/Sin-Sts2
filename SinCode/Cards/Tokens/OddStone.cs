using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using Sin.SinCode.Api.Cards;

namespace Sin.SinCode.Cards.Tokens;

public class OddStone() : SinCard(-1, CardType.Quest, CardRarity.Quest, TargetType.Self)
{
    protected override IEnumerable<DynamicVar> CanonicalVars => [new IntVar("Elites", 3)];
    public override IEnumerable<CardKeyword> CanonicalKeywords => [CardKeyword.Unplayable];
}
