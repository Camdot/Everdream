// SPDX-FileCopyrightText: 2025 Cami
// SPDX-FileCopyrightText: 2025 sleepyyapril
//
// SPDX-License-Identifier: MIT

using Robust.Shared.Prototypes;


namespace Content.Shared._DEN.Hub;


/// <summary>
/// This is a prototype for declaring new servers to put on the in-game hub menu.
/// </summary>
[Prototype]
public sealed partial class HubServerPrototype : IPrototype
{
    /// <inheritdoc/>
    [IdDataField]
    public string ID { get; set; } = default!;

    [DataField(required: true)]
    public string StatusUrl { get; set; } = string.Empty;

    [DataField(required: true)]
    public string ConnectAddress { get; set; } = string.Empty;

    [DataField(required: true)]
    public LocId DisplayName { get; set; }

    [DataField]
    public bool CanConnect { get; set; } = true;
}
