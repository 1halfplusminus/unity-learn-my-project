using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public List<GameObject> spawnItems = new List<GameObject>();
    public Vector3 minSpawnRange = new Vector3(-20, 0, 0);
    public Vector3 maxSpawnRange = new Vector3(20, 0, 0);
    public Vector3 spawnPos = new Vector3(0, 0, 20);

    public float spawnInterval = 1.5f;
    public float startDelay = 2f;

    List<GameObject> animalInstances = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(SpawnRandom), startDelay, spawnInterval);
    }

    void SpawnRandom()
    {
        if (enabled)
        {
            int animalIndex = Random.Range(0, spawnItems.Count);
            Vector3 instancePos = new Vector3(
                Random.Range(minSpawnRange.x, maxSpawnRange.x),
                Random.Range(minSpawnRange.y, maxSpawnRange.y),
                Random.Range(minSpawnRange.z, maxSpawnRange.z)) + spawnPos;
            var instance = Instantiate(spawnItems[animalIndex], instancePos, spawnItems[animalIndex].transform.rotation);
            animalInstances.Add(instance);
        }
    }
    public void Stop()
    {
        enabled = false;
        DestroyAll();
    }
    public void DestroyAll()
    {
        foreach (var instance in animalInstances)
        {
            Destroy(instance);
        }
    }
}
