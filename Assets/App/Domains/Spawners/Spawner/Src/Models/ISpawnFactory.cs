namespace App.Spawner
{
    /// <summary>
    /// Defines a generic interface for a factory that creates spawn views based on provided spawn options.
    /// This interface enforces type constraints to ensure that the options and views are of compatible types.
    /// </summary>
    /// <typeparam name="TOptions">The type of options to use for spawning. Must derive from SpawnOptions.</typeparam>
    /// <typeparam name="TView">The type of view to be created. Must implement ISpawnView and be a class.</typeparam>
    public interface ISpawnFactory<in TOptions, out TView>
        where TView : class, ISpawnView
        where TOptions : SpawnOptions
    {
        /// <summary>
        /// Creates an instance of a spawn view based on the specified spawn options.
        /// </summary>
        /// <param name="options">The options that dictate how the view should be spawned.</param>
        /// <returns>An instance of TView, created based on the provided TOptions.</returns>
        TView Create(TOptions options);
    }

}