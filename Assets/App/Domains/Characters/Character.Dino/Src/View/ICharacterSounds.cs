namespace App.Character.Dino
{
    /// <summary>
    /// Defines an interface for managing and playing character-specific sounds, such as those associated with actions like jumping or being idle.
    /// </summary>
    internal interface ICharacterSounds
    {
        /// <summary>
        /// Plays a sound corresponding to the specified character sound type.
        /// </summary>
        /// <param name="soundType">The type of sound to play, as defined by the CharacterSoundType enum.</param>
        void Play(CharacterSoundType soundType);
    }

}