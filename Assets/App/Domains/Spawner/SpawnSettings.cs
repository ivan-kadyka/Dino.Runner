namespace App.Domains.Spawner
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
    }
}