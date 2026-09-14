using System.Diagnostics.CodeAnalysis;
using Content.Server._Everdream.Atmos.Components;
using Content.Server.Atmos.EntitySystems;
using Content.Shared.Atmos;
using Content.Shared.Chemistry.Components.SolutionManager;
using Content.Shared.Chemistry.EntitySystems;
using Robust.Shared.Timing;


namespace Content.Server._Everdream.Atmos.EntitySystems;

/// <summary>
/// Produce a gas when a certain reagent is present within a certain solution.
/// For example, sauna coals produce steam from water.
/// </summary>
public sealed class SolutionDependentGasProducerSystem : EntitySystem
{
    [Dependency] private readonly AtmosphereSystem _atmosphere = default!;
    [Dependency] private readonly SharedSolutionContainerSystem _solutionContainer = default!;
    [Dependency] private readonly IGameTiming _timing = default!;

    public bool TryGetProducer(EntityUid uid, [NotNullWhen(true)] out SolutionDependentGasProducerComponent? component)
    {
        if (TryComp<SolutionDependentGasProducerComponent>(uid, out var comp))
        {
            component = comp;
            return true;
        }

        component = null;
        return false;
    }

    public void SetEnabled(EntityUid uid, bool enabled, SolutionDependentGasProducerComponent component)
    {
        component.Enabled = enabled;
    }

    public override void Update(float frameTime)
    {
        base.Update(frameTime);

        var query = EntityQueryEnumerator<SolutionDependentGasProducerComponent, SolutionContainerManagerComponent>();
        while (query.MoveNext(out var uid, out var producer, out var manager))
        {
            if (!producer.Enabled)
                continue;

            if (_timing.CurTime < producer.NextPurgeTime)
                continue;

            // timer ignores if it's empty, it's just a fixed cycle
            producer.NextPurgeTime += producer.Duration;

            if (!_solutionContainer.TryGetSolution((uid, manager), producer.Solution, out var entity))
                continue;

            if (!entity.Value.Comp.Solution.ContainsPrototype(producer.Reagent))
                continue;

            ProduceGas(uid, producer);
        }
    }

    private void ProduceGas(EntityUid uid, SolutionDependentGasProducerComponent component)
    {
        var environment = _atmosphere.GetContainingMixture(uid, true, true) ?? GasMixture.SpaceGas;

        environment.Temperature = component.Temperature;
        environment.AdjustMoles(component.ReleasedGas, component.ReleaseMoleAmount);
    }
}
