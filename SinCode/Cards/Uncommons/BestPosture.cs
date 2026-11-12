using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using Sin.SinCode.Api.Cards;

namespace Sin.SinCode.Cards.Uncommons;

public class BestPosture() : SinCard(1, CardType.Power, CardRarity.Uncommon, TargetType.Self)
{
    protected override void OnUpgrade()
    {
        AddKeyword(CardKeyword.Innate);
    }
}
