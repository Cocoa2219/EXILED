// -----------------------------------------------------------------------
// <copyright file="KeycardInteractingEventArgs.cs" company="ExMod Team">
// Copyright (c) ExMod Team. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace Exiled.Events.EventArgs.Item
{
    using Exiled.API.Features;
    using Exiled.API.Features.Doors;
    using Exiled.API.Features.Pickups;
    using Exiled.Events.EventArgs.Interfaces;
    using Interactables.Interobjects.DoorUtils;

    using BaseKeycardPickup = InventorySystem.Items.Keycards.KeycardPickup;

    /// <summary>
    /// Contains all information before a keycard interacts with a door.
    /// </summary>
    public class KeycardInteractingEventArgs : IPlayerEvent, IDeniableEvent, IDoorEvent, IPickupEvent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="KeycardInteractingEventArgs"/> class.
        /// </summary>
        /// <param name="pickup"><inheritdoc cref="Pickup"/></param>
        /// <param name="player"><inheritdoc cref="Player"/></param>
        /// <param name="door"><inheritdoc cref="Door"/></param>
        /// <param name="isAllowed"><inheritdoc cref="IsAllowed"/></param>
        public KeycardInteractingEventArgs(BaseKeycardPickup pickup, Player player, DoorVariant door, bool isAllowed = true)
        {
            KeycardPickup = Pickup.Get<KeycardPickup>(pickup);
            Player = player;
            Door = Door.Get(door);
            IsAllowed = isAllowed;
        }

        /// <summary>
        /// Gets the item that's interacting with the door.
        /// </summary>
        public Pickup Pickup => KeycardPickup;

        /// <inheritdoc cref="Pickup"/>
        public KeycardPickup KeycardPickup { get; }

        /// <summary>
        /// Gets the player who's threw the keycard.
        /// </summary>
        public Player Player { get; }

        /// <summary>
        /// Gets the <see cref="API.Features.Doors.Door"/> instance.
        /// </summary>
        public Door Door { get; }

        /// <summary>
        /// Gets or sets a value indicating whether the keycard can interact with the door.
        /// </summary>
        public bool IsAllowed { get; set; }
    }
}