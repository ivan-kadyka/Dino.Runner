using UnityEngine;

[CreateAssetMenu(fileName = "ObstacleSO", menuName = "ScriptableObjects/ObstacleScriptableObject", order = 1)]
internal class ObstacleScriptableObject : ScriptableObject
{
    public ObstacleObject[] items;
}

[System.Serializable]
internal struct ObstacleObject
{
    public GameObject prefab;
    [Range(0f, 1f)]
    public float spawnChance;
}