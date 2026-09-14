using Content.Server._Everdream.Speech.EntitySystems;

namespace Content.Server._Everdream.Speech.Components;

/// <summary>
/// Gagged accent replaces spoken letters simulating an occupied mouth.
/// </summary>
[RegisterComponent]
[Access(typeof(GaggedAccentSystem))]
public sealed partial class GaggedAccentComponent : Component { }
