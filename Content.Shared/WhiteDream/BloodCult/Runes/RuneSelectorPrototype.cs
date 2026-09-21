// SPDX-FileCopyrightText: 2024 Remuchi <72476615+Remuchi@users.noreply.github.com>
// SPDX-FileCopyrightText: 2025 sleepyyapril <123355664+sleepyyapril@users.noreply.github.com>
//
// SPDX-License-Identifier: AGPL-3.0-or-later AND MIT

using Content.Shared.Damage;
using Robust.Shared.Prototypes;

namespace Content.Shared.WhiteDream.BloodCult.Runes;

[Prototype("runeSelector")]
public sealed partial class RuneSelectorPrototype : IPrototype
{
    [IdDataField]
    public string ID { get; set; } = default!;

    [DataField(required: true)]
    public EntProtoId Prototype;

    [DataField]
    public float DrawTime = 4f;

    [DataField]
    public bool RequireTargetDead;

    [DataField]
    public int RequiredTotalCultists = 1;

    /// <summary>
    ///     Damage dealt on the rune drawing.
    /// </summary>
    [DataField]
    public DamageSpecifier DrawDamage = new() { DamageDict = new() { ["Slash"] = 15 } };
}
