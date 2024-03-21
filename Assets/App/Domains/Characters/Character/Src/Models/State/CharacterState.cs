namespace App.Character
{
    /// <summary>
    /// Enumerates the different states that can be applied to a character's behavior or state.
    /// </summary>
    public enum CharacterState
    {
        /// <summary>
        /// Represents the default state, with no modifications applied.
        /// </summary>
        Default,

        /// <summary>
        /// Indicates that the character is in an idle state
        /// </summary>
        Idle,

        /// <summary>
        /// Applies a slow state to the character, reducing its movement speed or action speed.
        /// </summary>
        Slow,

        /// <summary>
        /// Applies a fast state to the character, increasing its movement speed or action speed.
        /// </summary>
        Fast,

        /// <summary>
        /// Enables the character to fly, possibly changing its mode of movement and interaction with the environment.
        /// </summary>
        Fly
    }
}