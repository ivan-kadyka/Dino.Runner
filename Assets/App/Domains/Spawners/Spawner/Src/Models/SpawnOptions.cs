namespace App.Spawner
{
    /// <summary>
    /// Represents the options for spawning objects, including any identifiers or properties needed to customize the spawn process.
    /// </summary>
    public class SpawnOptions
    {
        /// <summary>
        /// Gets the identifier for the spawn operation or the object being spawned.
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// Initializes a new instance of the SpawnOptions class with the specified identifier.
        /// </summary>
        /// <param name="id">The identifier for the spawn operation or the object.</param>
        public SpawnOptions(int id)
        {
            Id = id;
        }
    }

}