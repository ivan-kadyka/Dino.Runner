using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    private Dictionary<GameObject, Queue<GameObject>> poolDictionary = new Dictionary<GameObject, Queue<GameObject>>();

    public GameObject GetObject(GameObject prefab, Vector3 position, Quaternion rotation)
    {
        if (!poolDictionary.ContainsKey(prefab))
        {
            poolDictionary[prefab] = new Queue<GameObject>();
        }

        if (poolDictionary[prefab].Count == 0)
        {
            AddObjects(prefab, 1);
        }

        GameObject objectToSpawn = poolDictionary[prefab].Dequeue();
        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;

        poolDictionary[prefab].Enqueue(objectToSpawn);

        return objectToSpawn;
    }

    private void AddObjects(GameObject prefab, int count)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject newObject = Instantiate(prefab);
            newObject.SetActive(false);
            poolDictionary[prefab].Enqueue(newObject);
        }
    }
}