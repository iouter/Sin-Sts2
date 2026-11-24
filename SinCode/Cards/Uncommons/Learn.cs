using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using Sin.SinCode.Api.Cards;

namespace Sin.SinCode.Cards.Uncommons;

public class Learn() : SinCard(1, CardType.Skill, CardRarity.Uncommon, TargetType.AnyPlayer)
{
    protected override IEnumerable<DynamicVar> CanonicalVars => [new CardsVar(2)];

    public override CardMultiplayerConstraint MultiplayerConstraint =>
        CardMultiplayerConstraint.MultiplayerOnly;

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        var player = cardPlay.Target?.Player;
        if (player == null)
        {
            return;
        }

        var hands = PileType.Hand.GetPile(player).Cards.ToList();

        RunState!.Rng.CombatCardSelection.Shuffle(hands);

        var take = Math.Clamp(DynamicVars.Cards.IntValue, 0, hands.Count);
        var selected = hands.GetRange(0, take);
        if (selected.Count == 0)
        {
            return;
        }

        await CardPileCmd.AddGeneratedCardsToCombat(
            selected.Select(c => c.CreateClone()),
            PileType.Hand,
            Owner
        );
    }

    protected override void OnUpgrade()
    {
        EnergyCost.UpgradeBy(-1);
    }
}
