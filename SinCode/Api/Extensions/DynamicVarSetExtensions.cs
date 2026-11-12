using MegaCrit.Sts2.Core.Localization.DynamicVars;
using Sin.SinCode.Api.DynamicVars;

namespace Sin.SinCode.Api.Extensions;

public static class DynamicVarSetExtensions
{
    public static SpendGoldVar SpendGold(this DynamicVarSet vars)
    {
        return (SpendGoldVar)vars[SpendGoldVar.Key];
    }
}
