using BaseLib.Utils;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models.Powers;
using MegaCrit.Sts2.Core.ValueProps;
using Sin.SinCode.Api.Cards;

namespace Sin.SinCode.Cards.Commons;

public class StealingStrike() : SinCard(1, CardType.Attack, CardRarity.Common, TargetType.AnyEnemy)
{
    protected override IEnumerable<DynamicVar> CanonicalVars => [new DamageVar(8, ValueProp.Move)];
    protected override HashSet<CardTag> CanonicalTags => [CardTag.Strike];

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        await CommonActions.CardAttack(this, cardPlay).Execute(choiceContext);
        var target = cardPlay.Target;
        if (target == null)
        {
            return;
        }
        var hasStrength = target.HasPower<StrengthPower>();
        var hasDexterity = target.HasPower<DexterityPower>();
        if (hasStrength && !hasDexterity)
        {
            await CommonActions.ApplySelf<StrengthPower>(
                choiceContext,
                this,
                target.GetPowerAmount<StrengthPower>()
            );
        }
        else if (!hasStrength && hasDexterity)
        {
            await CommonActions.ApplySelf<DexterityPower>(
                choiceContext,
                this,
                target.GetPowerAmount<DexterityPower>()
            );
        }
        else if (hasStrength && hasDexterity)
        {
            var random = Owner.RunState.Rng.CombatOrbGeneration.NextBool();
            if (random)
            {
                await CommonActions.ApplySelf<StrengthPower>(
                    choiceContext,
                    this,
                    target.GetPowerAmount<StrengthPower>()
                );
            }
            else
            {
                await CommonActions.ApplySelf<DexterityPower>(
                    choiceContext,
                    this,
                    target.GetPowerAmount<DexterityPower>()
                );
            }
        }
    }

    protected override void OnUpgrade()
    {
        DynamicVars.Damage.UpgradeValueBy(3);
    }
}
