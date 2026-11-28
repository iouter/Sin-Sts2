using BaseLib.Utils;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using Sin.SinCode.Api.Cards;
using Sin.SinCode.Powers;

namespace Sin.SinCode.Cards.Uncommons;

public class EverChanging() : SinCard(3, CardType.Power, CardRarity.Uncommon, TargetType.Self)
{
    private const string LoseCount = "LoseCount";

    protected override IEnumerable<DynamicVar> CanonicalVars =>
        [new(LoseCount, 1), new PowerVar<EverChangingPower>(2)];

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        (await CommonActions.Apply<EverChangingPower>(choiceContext, this, cardPlay))[0].Lose +=
            DynamicVars[LoseCount].IntValue;
    }

    protected override void OnUpgrade()
    {
        EnergyCost.UpgradeBy(-1);
    }
}
