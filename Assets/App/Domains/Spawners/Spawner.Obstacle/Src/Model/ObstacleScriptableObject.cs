using UnityEngine;

[CreateAssetMenu(fileName = "ObstacleSO", menuName = "ScriptableObjects/ObstacleScriptableObject", order = 1)]
public class ObstacleScriptableObject : ScriptableObject
{
    public ObstacleObject[] items;
}

[System.Serializable]
public struct ObstacleObject
{
    public GameObject prefab;
    [Range(0f, 1f)]
    public float spawnChance;
}