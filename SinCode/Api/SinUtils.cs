using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Entities.Players;
using MegaCrit.Sts2.Core.Factories;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Random;

namespace Sin.SinCode.Api;

public static class SinUtils
{
    public static async Task<CardPileAddResult?> Transform(
        Player player,
        CardModel original,
        CardPoolModel? cardPool = null,
        Func<CardModel, bool>? filter = null
    )
    {
        var rng = player.RunState.Rng.CombatCardGeneration;
        var result = GetTransformResult(original, rng, cardPool, filter);
        return await CardCmd.Transform(original, result);
    }

    public static async Task<IEnumerable<CardPileAddResult>> TransformList(
        Player player,
        CardModel[] originals,
        CardPoolModel? cardPool = null,
        Func<CardModel, bool>? filter = null
    )
    {
        var rng = player.RunState.Rng.CombatCardGeneration;
        var results = originals.Select(o => new CardTransformation(
            o,
            GetTransformResult(o, rng, cardPool, filter)
        ));
        return await CardCmd.Transform(results, rng);
    }

    public static CardModel GetTransformResult(
        CardModel original,
        Rng rng,
        CardPoolModel? cardPool = null,
        Func<CardModel, bool>? filter = null
    )
    {
        if (cardPool is null || original.Type is not CardType.Curse and CardType.Status)
        {
            return CardFactory.CreateRandomCardForTransform(original, true, rng);
        }

        var cards = cardPool.AllCards;
        if (filter is not null)
        {
            cards = cards.Where(filter);
        }
        return CardFactory.CreateRandomCardForTransform(original, cards, true, rng);
    }
}
