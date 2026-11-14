using BaseLib.Utils;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.ValueProps;
using Sin.SinCode.Api.Cards;

namespace Sin.SinCode.Cards.Commons;

public class LootStrike() : SinCard(1, CardType.Attack, CardRarity.Common, TargetType.AnyEnemy)
{
    protected override IEnumerable<DynamicVar> CanonicalVars => [new DamageVar(7, ValueProp.Move)];

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        await CommonActions.CardAttack(this, cardPlay).Execute(choiceContext);
        var card = RunState?.Rng.CombatCardSelection.NextItem(
            PileType
                .Exhaust.GetPile(Owner)
                .Cards.Where(c => c.Type is CardType.Attack or CardType.Skill)
        );
        if (card == null)
        {
            return;
        }
        await CardCmd.AutoPlay(choiceContext, card, null);
        if (card.Pile is not { Type: PileType.Discard })
        {
            return;
        }
        await CardPileCmd.Add(card, PileType.Discard);
    }

    protected override void OnUpgrade()
    {
        DynamicVars.Damage.UpgradeValueBy(3);
    }
}
