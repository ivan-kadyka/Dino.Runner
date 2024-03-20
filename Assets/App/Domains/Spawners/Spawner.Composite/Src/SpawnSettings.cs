namespace App.Spawner.Composite
{
    public class SpawnSettings
    {
        public float MinSpawnRate { get; }
        
        public float MaxSpawnRate { get; }
        
        public float CoinsSpawnChance { get; }

        public SpawnSettings(float minSpawnRate, float maxSpawnRate, float coinsSpawnChance)
        {
            MinSpawnRate = minSpawnRate;
            MaxSpawnRate = maxSpawnRate;
            CoinsSpawnChance = coinsSpawnChance;
        }

        public SpawnSettings() 
            : this(1, 1.5f, 0.33f)
        {
        }
    }
}