using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using Sin.SinCode.Api.Cards;

namespace Sin.SinCode.Cards.Rares;

public class Molt() : SinCard(1, CardType.Skill, CardRarity.Rare, TargetType.Self)
{
    protected override void OnUpgrade()
    {
        AddKeyword(CardKeyword.Retain);
    }
}
