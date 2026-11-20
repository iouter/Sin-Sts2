using BaseLib.Extensions;
using BaseLib.Utils;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models.Powers;
using Sin.SinCode.Api;
using Sin.SinCode.Api.Cards;
using Sin.SinCode.Api.DynamicVars;

namespace Sin.SinCode.Cards.Uncommons;

public class ConstructCore()
    : SinSpendGoldCard(2, CardType.Skill, CardRarity.Uncommon, TargetType.Self)
{
    protected override IEnumerable<DynamicVar> CanonicalVars =>
        [new SpendGoldVar(10), new PowerVar<ArtifactPower>(1)];
    public override IEnumerable<CardKeyword> CanonicalKeywords => [SinKeywords.Transform];

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        await CommonActions.Apply<AfterimagePower>(choiceContext, this, cardPlay);
        var cards = PileType
            .Hand.GetPile(Owner)
            .Cards.Where(c => c.Type is CardType.Status)
            .ToList();
        var amount = cards.Count;
        foreach (var card in cards)
        {
            await CardCmd.Exhaust(choiceContext, card);
        }
        await CommonActions.ApplySelf<ArtifactPower>(choiceContext, this, amount);
    }

    protected override void OnUpgrade()
    {
        DynamicVars.Power<ArtifactPower>().UpgradeValueBy(1);
    }
}
