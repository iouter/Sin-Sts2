using BaseLib.Utils;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.ValueProps;
using Sin.SinCode.Api.Cards;
using Sin.SinCode.Cards.Tokens;

namespace Sin.SinCode.Cards.Commons;

public class Windfall() : SinCard(1, CardType.Attack, CardRarity.Common, TargetType.AllEnemies)
{
    protected override IEnumerable<DynamicVar> CanonicalVars =>
        [new DamageVar(16, ValueProp.Move), new CardsVar(3)];

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        await CommonActions.CardAttack(this, cardPlay).Execute(choiceContext);
        if (CombatState == null)
        {
            return;
        }

        await CardPileCmd.AddGeneratedCardsToCombat(
            Enumerable
                .Range(0, DynamicVars.Cards.IntValue)
                .Select(_ => CombatState.CreateCard<Cost>(Owner))
                .ToList(),
            PileType.Draw,
            Owner
        );
    }

    protected override void OnUpgrade()
    {
        DynamicVars.Damage.UpgradeValueBy(2);
    }
}
