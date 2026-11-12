using BaseLib.Utils;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Models.Powers;
using Sin.SinCode.Api;
using Sin.SinCode.Api.Cards;
using STS2RitsuLib.Interop.AutoRegistration;

namespace Sin.SinCode.Cards.Basics;

[RegisterCharacterStarterCard(typeof(Characters.Sin), Order = 2)]
public class Imitate() : SinCard(0, CardType.Skill, CardRarity.Basic, TargetType.AnyEnemy)
{
    public override IEnumerable<CardKeyword> CanonicalKeywords => [SinKeywords.Transform];

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
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
        AddKeyword(CardKeyword.Retain);
    }
}
