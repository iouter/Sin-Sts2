using BaseLib.Utils;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Models.Powers;
using Sin.SinCode.Api.Cards;

namespace Sin.SinCode.Cards.Uncommons;

public class Impersonate() : SinCard(1, CardType.Skill, CardRarity.Uncommon, TargetType.AnyEnemy)
{
    public override IEnumerable<CardKeyword> CanonicalKeywords => [CardKeyword.Exhaust];

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        var target = cardPlay.Target;
        if (target == null)
        {
            return;
        }

        var strength = target.GetPower<StrengthPower>();
        var dexterity = target.GetPower<DexterityPower>();
        if (strength != null)
        {
            await CommonActions.ApplySelf<StrengthPower>(choiceContext, this, strength.Amount);
            await PowerCmd.Remove(strength);
        }

        if (dexterity != null)
        {
            await CommonActions.ApplySelf<DexterityPower>(choiceContext, this, dexterity.Amount);
            await PowerCmd.Remove(dexterity);
        }
    }
}
