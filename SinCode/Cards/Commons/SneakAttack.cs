using MegaCrit.Sts2.Core.Commands.Builders;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using Sin.SinCode.Api;
using Sin.SinCode.Api.Cards;

namespace Sin.SinCode.Cards.Commons;

public class SneakAttack() : SinCard(0, CardType.Attack, CardRarity.Common, TargetType.AnyEnemy)
{
    private const string MinDamage = "MinDamage";
    private const string MaxDamage = "MaxDamage";

    protected override IEnumerable<DynamicVar> CanonicalVars =>
        [new(MinDamage, 1), new(MaxDamage, 6)];
    public override IEnumerable<CardKeyword> CanonicalKeywords =>
        [CardKeyword.Exhaust, SinKeywords.SneakAttackIsScaryHigh];

    public override int MaxUpgradeLevel => 999999999;

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        var rng = Owner.RunState.Rng.CombatOrbGeneration;
        var damage = rng.NextInt(DynamicVars[MinDamage].IntValue, DynamicVars[MaxDamage].IntValue + 1);
        await new AttackCommand(damage).Targeting(cardPlay.Target!).FromCard(this, cardPlay).Execute(choiceContext);
    }

    protected override void OnUpgrade()
    {
        DynamicVars[MinDamage].UpgradeValueBy(1);
        DynamicVars[MaxDamage].UpgradeValueBy(6);
    }
}
