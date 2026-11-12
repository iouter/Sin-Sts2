using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.Factories;
using MegaCrit.Sts2.Core.Models;

namespace Sin.SinCode.Api;

public static class SinUtils
{
    public static async Task<CardPileAddResult?> Transform(
        CardModel source,
        CardModel original,
        CardPoolModel? cardPool
    )
    {
        var rng = source.Owner.RunState.Rng.CombatCardGeneration;
        if (cardPool is null)
        {
            return await CardCmd.TransformToRandom(original, rng);
        }

        var result = original.Type is CardType.Curse or CardType.Status
            ? CardFactory.CreateRandomCardForTransform(original, cardPool.AllCards, true, rng)
            : CardFactory.CreateRandomCardForTransform(original, true, rng);

        return await CardCmd.Transform(original, result);
    }
}
