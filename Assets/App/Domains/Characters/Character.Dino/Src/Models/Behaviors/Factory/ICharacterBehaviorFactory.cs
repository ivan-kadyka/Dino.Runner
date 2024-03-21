namespace App.Character.Dino
{
    /// <summary>
    /// Defines an interface for a factory that creates ICharacterBehavior instances based on provided options.
    /// </summary>
    internal interface ICharacterBehaviorFactory
    {
        /// <summary>
        /// Creates an instance of a character behavior based on the specified options.
        /// </summary>
        /// <param name="options">The options that define the behavior characteristics and parameters.</param>
        /// <returns>An instance of ICharacterBehavior that matches the provided options.</returns>
        ICharacterBehavior Create(CharacterBehaviorOptions options);
    }

}