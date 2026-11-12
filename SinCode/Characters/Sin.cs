using Godot;
using MegaCrit.Sts2.Core.Entities.Characters;
using MegaCrit.Sts2.Core.Nodes.Combat;
using STS2RitsuLib.Interop.AutoRegistration;
using STS2RitsuLib.Scaffolding.Characters;
using STS2RitsuLib.Scaffolding.Godot;

namespace Sin.SinCode.Characters;

[RegisterCharacter]
public class Sin : ModCharacterTemplate<SinCardPool, SinRelicPool, SinPotionPool>
{
    public const string CharacterId = "Sin";
    public static readonly Color Color = new(0.8f, 0.94f, 1f);

    // public const string EnergyIconPath =
    //     "res://Sin/..";
    // public const string BigEnergyIconPath =
    //     "res://Sin/..";

    public override Color NameColor => Color;
    public override Color EnergyLabelOutlineColor => Color;
    public override Color MapDrawingColor => Color;

    public override CharacterGender Gender => CharacterGender.Feminine;
    public override int StartingHp => 70;
    public override int StartingGold => 77;

    // public override CharacterAssetProfile AssetProfile =>
    //     CharacterAssetProfiles.Merge(
    //         CharacterAssetProfiles.Ironclad(),
    //             new(
    //                 )
    //         )
    //     );

    public override float AttackAnimDelay => 0.15f;
    public override float CastAnimDelay => 1f;

    public override bool RequiresEpochAndTimeline => false;

    protected override NCreatureVisuals? TryCreateCreatureVisuals() =>
        RitsuGodotNodeFactories.CreateFromScenePath<NCreatureVisuals>(
            AssetProfile.Scenes!.VisualsPath!
        );

    // 攻击建筑师的攻击特效列表
    public override List<string> GetArchitectAttackVfx() =>
        [
            "vfx/vfx_attack_blunt",
            "vfx/vfx_heavy_blunt",
            "vfx/vfx_attack_slash",
            "vfx/vfx_bloody_impact",
            "vfx/vfx_rock_shatter",
        ];
}
