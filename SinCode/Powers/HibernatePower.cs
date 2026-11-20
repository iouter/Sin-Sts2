using MegaCrit.Sts2.Core.CardSelection;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Entities.Players;
using MegaCrit.Sts2.Core.Entities.Powers;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using Sin.SinCode.Api.Powers;

namespace Sin.SinCode.Powers;

public class HibernatePower : SinPower
{
    public override PowerType Type => PowerType.Buff;
    public override PowerStackType StackType => PowerStackType.Counter;

    public override async Task AfterPlayerTurnStart(
        PlayerChoiceContext choiceContext,
        Player player
    )
    {
        if (player.Creature != Owner)
        {
            return;
        }
        var pref = new CardSelectorPrefs(SelectionScreenPrompt, Amount);
        var cards = await CardSelectCmd.FromSimpleGrid(
            choiceContext,
            PileType
                .Draw.GetPile(player)
                .Cards.Where(c => c.Type is CardType.Attack or CardType.Skill)
                .ToList(),
            player,
            pref
        );
        await CardPileCmd.Add(cards, PileType.Hand);
        await PowerCmd.Remove(this);
    }
}
