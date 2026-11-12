using Godot;
using STS2RitsuLib.Scaffolding.Content;

namespace Sin.SinCode.Characters;

public class SinPotionPool : TypeListPotionPoolModel
{
    public override string EnergyColorName => Sin.CharacterId;
    public override Color LabOutlineColor => Sin.Color;

    // public override string BigEnergyIconPath => Sin.BigEnergyIconPath;
    // public override string TextEnergyIconPath => Sin.EnergyIconPath;
}
