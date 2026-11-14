using BaseLib.Utils;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.ValueProps;
using Sin.SinCode.Api.Cards;

namespace Sin.SinCode.Cards.Commons;

public class Essence() : SinCard(0, CardType.Skill, CardRarity.Common, TargetType.Self)
{
    protected override IEnumerable<DynamicVar> CanonicalVars =>
        [new CalculationBaseVar(5), new CalculationExtraVar(1), new CalculatedBlockVar(ValueProp.Move)
            .WithMultiplier((card, target) => card.CombatState == null ? 0 : card.CombatState.HittableEnemies.Select(c => c.Powers.Count).Sum())];
    public override bool GainsBlock => true;

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        await CommonActions.CardBlock(this, cardPlay);
    }

    protected override void OnUpgrade()
    {
        DynamicVars.CalculationExtra.UpgradeValueBy(1);
    }
}
