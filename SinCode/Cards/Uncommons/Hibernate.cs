using BaseLib.Utils;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models.Powers;
using Sin.SinCode.Api.Cards;
using HibernatePower = Sin.SinCode.Powers.HibernatePower;

namespace Sin.SinCode.Cards.Uncommons;

public class Hibernate() : SinCard(2, CardType.Skill, CardRarity.Uncommon, TargetType.Self)
{
    protected override IEnumerable<DynamicVar> CanonicalVars => [new EnergyVar(2), new CardsVar(3)];
    public override IEnumerable<CardKeyword> CanonicalKeywords => [CardKeyword.Exhaust];

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        await CommonActions.ApplySelf<EnergyNextTurnPower>(
            choiceContext,
            this,
            DynamicVars.Energy.BaseValue
        );
        await CommonActions.ApplySelf<HibernatePower>(
            choiceContext,
            this,
            DynamicVars.Cards.BaseValue
        );
    }

    protected override void OnUpgrade()
    {
        EnergyCost.UpgradeBy(-1);
    }
}
