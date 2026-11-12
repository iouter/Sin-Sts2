using STS2RitsuLib.Cards.DynamicVars;
using STS2RitsuLib.Combat.SecondaryResources;

namespace Sin.SinCode.Api.DynamicVars;

public class SpendGoldVar : SecondaryResourceVar
{
    public const string Key = "SpendGold";

    public bool HasGoldCostX { get; init; } = false;

    public SpendGoldVar(decimal baseValue)
        : base(Key, Gold.Id, baseValue)
    {
        this.WithTooltip(_ => Gold.HoverTip());
    }
}
