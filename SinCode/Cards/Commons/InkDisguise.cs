using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.HoverTips;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models.Powers;
using Sin.SinCode.Api.Cards;
using Sin.SinCode.Powers;

namespace Sin.SinCode.Cards.Commons;

public class InkDisguise() : SinCard(1, CardType.Skill, CardRarity.Common, TargetType.Self)
{
    protected override IEnumerable<DynamicVar> CanonicalVars =>
        [
            new CalculationBaseVar(1),
            new CalculationExtraVar(1),
            new CalculatedVar(nameof(SlipperyPlayer)).WithMultiplier(
                (card, _) =>
                    card.CombatState == null
                        ? 0
                        : card
                            .CombatState.HittableEnemies.Select(e =>
                                e.GetPowerAmount<SlipperyPower>()
                            )
                            .Sum()
            ),
        ];
    public override IEnumerable<CardKeyword> CanonicalKeywords => [CardKeyword.Exhaust];
    protected override IEnumerable<IHoverTip> AdditionalHoverTips =>
        [HoverTipFactory.FromPower<SlipperyPlayer>()];

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        await PowerCmd.Apply<SlipperyPlayer>(
            choiceContext,
            Owner.Creature,
            ((CalculatedVar)DynamicVars[nameof(SlipperyPlayer)]).Calculate(null),
            Owner.Creature,
            this
        );
    }

    protected override void OnUpgrade()
    {
        DynamicVars.CalculationBase.UpgradeValueBy(1);
    }
}
