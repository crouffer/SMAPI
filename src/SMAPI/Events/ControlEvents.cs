using System;
using Microsoft.Xna.Framework.Input;
using StardewModdingAPI.Framework.Events;

namespace StardewModdingAPI.Events
{
    /// <summary>Events raised when the player uses a controller, keyboard, or mouse.</summary>
    public static class ControlEvents
    {
        /*********
        ** Properties
        *********/
        /// <summary>The core event manager.</summary>
        private static EventManager EventManager;


        /*********
        ** Events
        *********/
        /// <summary>Raised when the <see cref="KeyboardState"/> changes. That happens when the player presses or releases a key.</summary>
        public static event EventHandler<EventArgsKeyboardStateChanged> KeyboardChanged
        {
            add => ControlEvents.EventManager.Legacy_KeyboardChanged.Add(value);
            remove => ControlEvents.EventManager.Legacy_KeyboardChanged.Remove(value);
        }

        /// <summary>Raised after the player presses a keyboard key.</summary>
        public static event EventHandler<EventArgsKeyPressed> KeyPressed
        {
            add => ControlEvents.EventManager.Legacy_KeyPressed.Add(value);
            remove => ControlEvents.EventManager.Legacy_KeyPressed.Remove(value);
        }

        /// <summary>Raised after the player releases a keyboard key.</summary>
        public static event EventHandler<EventArgsKeyPressed> KeyReleased
        {
            add => ControlEvents.EventManager.Legacy_KeyReleased.Add(value);
            remove => ControlEvents.EventManager.Legacy_KeyReleased.Remove(value);
        }

        /// <summary>Raised when the <see cref="MouseState"/> changes. That happens when the player moves the mouse, scrolls the mouse wheel, or presses/releases a button.</summary>
        public static event EventHandler<EventArgsMouseStateChanged> MouseChanged
        {
            add => ControlEvents.EventManager.Legacy_MouseChanged.Add(value);
            remove => ControlEvents.EventManager.Legacy_MouseChanged.Remove(value);
        }

        /// <summary>The player pressed a controller button. This event isn't raised for trigger buttons.</summary>
        public static event EventHandler<EventArgsControllerButtonPressed> ControllerButtonPressed
        {
            add => ControlEvents.EventManager.Legacy_ControllerButtonPressed.Add(value);
            remove => ControlEvents.EventManager.Legacy_ControllerButtonPressed.Remove(value);
        }

        /// <summary>The player released a controller button. This event isn't raised for trigger buttons.</summary>
        public static event EventHandler<EventArgsControllerButtonReleased> ControllerButtonReleased
        {
            add => ControlEvents.EventManager.Legacy_ControllerButtonReleased.Add(value);
            remove => ControlEvents.EventManager.Legacy_ControllerButtonReleased.Remove(value);
        }

        /// <summary>The player pressed a controller trigger button.</summary>
        public static event EventHandler<EventArgsControllerTriggerPressed> ControllerTriggerPressed
        {
            add => ControlEvents.EventManager.Legacy_ControllerTriggerPressed.Add(value);
            remove => ControlEvents.EventManager.Legacy_ControllerTriggerPressed.Remove(value);
        }

        /// <summary>The player released a controller trigger button.</summary>
        public static event EventHandler<EventArgsControllerTriggerReleased> ControllerTriggerReleased
        {
            add => ControlEvents.EventManager.Legacy_ControllerTriggerReleased.Add(value);
            remove => ControlEvents.EventManager.Legacy_ControllerTriggerReleased.Remove(value);
        }


        /*********
        ** Public methods
        *********/
        /// <summary>Initialise the events.</summary>
        /// <param name="eventManager">The core event manager.</param>
        internal static void Init(EventManager eventManager)
        {
            ControlEvents.EventManager = eventManager;
        }
    }
}
