using BaseLib.Utils;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models.Powers;
using MegaCrit.Sts2.Core.ValueProps;
using Sin.SinCode.Api.Cards;
using Sin.SinCode.Powers;

namespace Sin.SinCode.Cards.Uncommons;

public class CarriedAway() : SinCard(0, CardType.Attack, CardRarity.Uncommon, TargetType.AnyEnemy)
{
    protected override IEnumerable<DynamicVar> CanonicalVars => [new DamageVar(4, ValueProp.Move)];

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        await CommonActions
            .CardAttack(this, cardPlay, hitCount: Owner.Creature.GetPowerAmount<Theft>())
            .Execute(choiceContext);
        var target = cardPlay.Target;
        var swipe = target?.GetPower<SwipePower>();
        var card = swipe?.StolenCard;
        if (card == null || RunState == null || card.DeckVersion == null)
        {
            return;
        }
        RunState.AddCard(card.DeckVersion, Owner);
        await CardPileCmd.Add(card, PileType.Hand);
        await CardPileCmd.Add(card, PileType.Deck);
        await PowerCmd.Remove(swipe);
    }

    protected override void OnUpgrade()
    {
        DynamicVars.Damage.UpgradeValueBy(1);
    }
}
