using Godot;
using STS2RitsuLib.Scaffolding.Characters;
using STS2RitsuLib.Scaffolding.Content;
using STS2RitsuLib.Utils;

namespace Sin.SinCode.Characters;

public class SinCardPool : TypeListCardPoolModel, IModColorfulPhilosophersCardPool
{
    public override string Title => Sin.CharacterId; //This is not a display name.
    public override string EnergyColorName => Sin.CharacterId;

    // public override string BigEnergyIconPath => Sin.BigEnergyIconPath;
    // public override string TextEnergyIconPath => Sin.EnergyIconPath;

    private static readonly Material? _poolFrameMaterial = MaterialUtils.CreateHsvShaderMaterial(
        0.55f,
        0.2f,
        1.2f
    );
    public override Material? PoolFrameMaterial => _poolFrameMaterial;

    public override Color DeckEntryCardColor => Sin.Color;

    public override bool IsColorless => false;
}
