using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using Sin.SinCode.Api.Cards;

namespace Sin.SinCode.Cards.Uncommons;

public class ReactiveDefense() : SinCard(1, CardType.Skill, CardRarity.Uncommon, TargetType.Self)
{
    protected override IEnumerable<DynamicVar> CanonicalVars => [new IntVar("Cards", 5)];

    protected override void OnUpgrade()
    {
        AddKeyword(CardKeyword.Retain);
    }
}
