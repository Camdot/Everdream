using Content.Shared.Atmos;
using Content.Shared.Chemistry.Reagent;
using Robust.Shared.Prototypes;
using Robust.Shared.Serialization.TypeSerializers.Implementations.Custom;
using Robust.Shared.Serialization.TypeSerializers.Implementations.Custom.Prototype.List;
using Robust.Shared.Serialization.TypeSerializers.Implementations.Generic;


namespace Content.Server._Everdream.Atmos.Components;

/// <summary>
/// Periodically produces an amount of gas while a reagent is present in the given solution.
/// </summary>
[RegisterComponent, AutoGenerateComponentPause]
public sealed partial class SolutionDependentGasProducerComponent : Component
{
    /// <summary>
    /// Whether or not to release gas.
    /// </summary>
    public bool Enabled;

    /// <summary>
    /// The gas to release.
    /// </summary>
    public Gas ReleasedGas = Gas.WaterVapor;

    /// <summary>
    /// The amount of gas released.
    /// </summary>
    public float ReleaseMoleAmount = 1f;

    /// <summary>
    /// The temperature of the released gas.
    /// </summary>
    public float Temperature = 315.15f;

    /// <summary>
    /// The name of the solution to read.
    /// </summary>
    public string Solution = string.Empty;

    /// <summary>
    /// The reagent that must be in the solution to produce gas.
    /// </summary>
    public ProtoId<ReagentPrototype> Reagent = "Water";

    /// <summary>
    /// How long it takes to produce one batch of gas.
    /// </summary>
    public TimeSpan Duration = TimeSpan.FromSeconds(1);

    /// <summary>
    /// The time when the next purge will occur.
    /// </summary>
    [DataField("nextPurgeTime", customTypeSerializer: typeof(TimeOffsetSerializer))]
    [AutoPausedField]
    public TimeSpan NextPurgeTime = TimeSpan.FromSeconds(0);
}
