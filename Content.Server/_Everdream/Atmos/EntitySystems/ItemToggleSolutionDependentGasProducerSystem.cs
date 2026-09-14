using Content.Server._Everdream.Atmos.Components;
using Content.Shared.Item.ItemToggle.Components;


namespace Content.Server._Everdream.Atmos.EntitySystems;

/// <summary>
/// Implements the behavior of <see cref="ItemToggleSolutionDependentGasProducerComponent"/>, causing <see cref="ItemToggledEvent"/>s to
/// enable and disable gas production on the entity.
/// </summary>
public sealed class ItemToggleSolutionDependentGasProducerSystem : EntitySystem

{
    [Dependency] private readonly SolutionDependentGasProducerSystem _producerSystem = default!;

    public override void Initialize()
    {
        base.Initialize();
        SubscribeLocalEvent<ItemToggleSolutionDependentGasProducerComponent, ItemToggledEvent>(OnItemToggled);
    }

    private void OnItemToggled(Entity<ItemToggleSolutionDependentGasProducerComponent> ent, ref ItemToggledEvent args)
    {
        if (!_producerSystem.TryGetProducer(ent.Owner, out var producer))
            return;

        _producerSystem.SetEnabled(ent.Owner, args.Activated, producer);
    }
}
