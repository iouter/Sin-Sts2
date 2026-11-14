using BaseLib.Extensions;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using Sin.SinCode.Api.Cards;
using Sin.SinCode.Powers;

namespace Sin.SinCode.Cards.Commons;

public class Motive() : SinCard(0, CardType.Skill, CardRarity.Common, TargetType.Self)
{
    protected override IEnumerable<DynamicVar> CanonicalVars =>
        [new PowerVar<Theft>(4), new EnergyVar(3)];
    public override IEnumerable<CardKeyword> CanonicalKeywords => [CardKeyword.Exhaust];

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        var theft = Owner.Creature.GetPower<Theft>();
        if (theft == null || theft.Amount <= DynamicVars.Power<Theft>().IntValue)
        {
            return;
        }
        await PowerCmd.ModifyAmount(
            choiceContext,
            theft,
            -1 * DynamicVars.Power<Theft>().IntValue,
            Owner.Creature,
            this
        );
        await PlayerCmd.GainEnergy(DynamicVars.Energy.IntValue, Owner);
    }

    protected override bool IsPlayable =>
        Owner.Creature.GetPowerAmount<Theft>() > DynamicVars.Power<Theft>().IntValue;

    protected override void OnUpgrade()
    {
        DynamicVars.Power<Theft>().UpgradeValueBy(-1);
    }
}
