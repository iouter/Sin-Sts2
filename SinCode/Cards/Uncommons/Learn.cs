using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using Sin.SinCode.Api;
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
        var selected = hands.TakeRandomUpTo(this);
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
