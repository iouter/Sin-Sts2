using MegaCrit.Sts2.Core.Entities.Cards;
using Sin.SinCode.Api.Extensions;
using STS2RitsuLib.Combat.SecondaryResources;

namespace Sin.SinCode.Api.Cards;

public abstract class SpendGoldCard : SinBaseCard
{
    protected virtual HashSet<CardTag> AdditionalCanonicalTags => [];
    protected sealed override HashSet<CardTag> CanonicalTags =>
        [SinTags.SpendGold, .. AdditionalCanonicalTags];

    public bool HasGoldCostX => DynamicVars.SpendGold().HasGoldCostX;

    protected SpendGoldCard(int cost, CardType type, CardRarity rarity, TargetType target)
        : base(cost, type, rarity, target)
    {
        var spendGoldVar = DynamicVars.SpendGold();
        if (spendGoldVar.HasGoldCostX)
        {
            this.SecondaryCosts().Set(Gold.Id, SecondaryResourceCost.X());
            return;
        }
        this.SecondaryCosts().Set(Gold.Id, spendGoldVar.IntValue);
    }

    protected void UpgradeGoldValueBy(int addend)
    {
        DynamicVars.SpendGold().UpgradeValueBy(addend);
        this.SecondaryCosts().Set(Gold.Id, DynamicVars.SpendGold().IntValue);
    }

    protected int ResolveGoldXValue(CardPlay play)
    {
        if (!HasGoldCostX)
        {
            throw new InvalidOperationException("This card does not have an X-cost.");
        }
        return play.SecondaryResources().Value(Gold.Id);
    }
}
