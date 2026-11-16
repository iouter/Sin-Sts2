using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using Sin.SinCode.Api.Cards;
using Sin.SinCode.Cards.Tokens;
using Sin.SinCode.Powers;

namespace Sin.SinCode.Cards.Uncommons;

public class Gambler() : SinCard(1, CardType.Skill, CardRarity.Uncommon, TargetType.Self)
{
    private const string GoldChance = "GoldChance";

    protected override IEnumerable<DynamicVar> CanonicalVars =>
        [new IntVar(GoldChance, 50), new IntVar("GoldMultiplier", 10)];
    public override IEnumerable<CardKeyword> CanonicalKeywords => [CardKeyword.Exhaust];

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        var rng = RunState!.Rng.CombatOrbGeneration;
        var success = rng.NextInt(100) < DynamicVars[GoldChance].IntValue;
        if (success)
        {
            await PlayerCmd.GainGold(Owner.Creature.GetPowerAmount<Theft>(), Owner);
        }
        else
        {
            await CardPileCmd.AddGeneratedCardToCombat(
                CombatState!.CreateCard<Greed>(Owner),
                PileType.Hand,
                Owner
            );
        }
    }

    protected override void OnUpgrade()
    {
        DynamicVars[GoldChance].UpgradeValueBy(25);
    }
}
