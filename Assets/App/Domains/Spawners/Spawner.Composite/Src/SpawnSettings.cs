namespace App.Spawner.Composite
{
    public class SpawnSettings
    {
        public float MinSpawnRate { get; }
        
        public float MaxSpawnRate { get; }

        public SpawnSettings(float minSpawnRate, float maxSpawnRate)
        {
            MinSpawnRate = minSpawnRate;
            MaxSpawnRate = maxSpawnRate;
        }

        public SpawnSettings() : this(1, 1.5f)
        {
        }
    }
}