using BaseLib.Utils;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Factories;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.HoverTips;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models;
using Sin.SinCode.Api;
using Sin.SinCode.Api.Cards;
using Sin.SinCode.Characters;

namespace Sin.SinCode.Cards.Uncommons;

public class PassiveShift() : SinCard(1, CardType.Skill, CardRarity.Uncommon, TargetType.Self)
{
    protected override IEnumerable<DynamicVar> CanonicalVars => [new CardsVar(2)];
    protected override IEnumerable<IHoverTip> AdditionalHoverTips =>
        [HoverTipFactory.FromKeyword(SinKeywords.Transform)];

    protected override async Task OnPlay(PlayerChoiceContext choiceContext, CardPlay cardPlay)
    {
        var cards = await CommonActions.SelectCards(
            this,
            SelectionScreenPrompt,
            choiceContext,
            PileType.Hand,
            count: DynamicVars.Cards.IntValue
        );

        foreach (var card in cards)
        {
            if (card.Type is CardType.Curse or CardType.Status)
            {
                var result = CardFactory.CreateRandomCardForTransform(
                    card,
                    ModelDb
                        .CardPool<SinCardPool>()
                        .AllCards.Where(c => c.Rarity == CardRarity.Rare),
                    true,
                    RunState!.Rng.CombatCardGeneration
                );
                result.AddKeyword(SinKeywords.Transform);
                await CardCmd.Transform(card, result);
                continue;
            }
            card.AddKeyword(SinKeywords.Transform);
            await CardCmd.AutoPlay(choiceContext, card, null);
        }
    }

    protected override void OnUpgrade()
    {
        DynamicVars.Cards.UpgradeValueBy(1);
    }
}
