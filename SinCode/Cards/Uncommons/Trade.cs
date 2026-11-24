using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using Sin.SinCode.Api.Cards;
using Sin.SinCode.Api.DynamicVars;

namespace Sin.SinCode.Cards.Uncommons;

public class Trade() : SinSpendGoldCard(0, CardType.Skill, CardRarity.Uncommon, TargetType.Self)
{
    protected override IEnumerable<DynamicVar> CanonicalVars =>
        [new SpendGoldVar(16), new EnergyVar(1)];

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        await PlayerCmd.GainEnergy(DynamicVars.Energy.BaseValue, Owner);
    }

    protected override CardLocation GetResultLocationForCardPlay()
    {
        var baseLocation = base.GetResultLocationForCardPlay();
        return baseLocation.pileType == PileType.Discard
            ? new CardLocation(baseLocation.player, PileType.Hand, baseLocation.position)
            : baseLocation;
    }

    protected override void OnUpgrade()
    {
        UpgradeGoldValueBy(-4);
    }
}
