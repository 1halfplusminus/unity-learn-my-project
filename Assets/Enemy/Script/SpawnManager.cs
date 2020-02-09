
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class SpawnZone
{
    public Collider zone;

    public Vector3 GetRandomPoint()
    {
        var randomX = Random.Range(zone.bounds.min.x, zone.bounds.max.x);
        var randomY = Random.Range(zone.bounds.min.y, zone.bounds.max.y);
        var randomZ = Random.Range(zone.bounds.min.z, zone.bounds.max.z);
        return zone.ClosestPoint(new Vector3(randomX, randomY, randomZ));
    }
}

[System.Serializable]
public class OnSpawnEvent : UnityEvent<GameObject> { }

[System.Serializable]
public class SpawnableQuantity
{
    public int min = 1;
    public int max = 1;
    public int total = 1;
    public SpawnableQuantity() { }
    public SpawnableQuantity(int min, int max, int total)
    {
        this.min = min;
        this.max = max;
        this.total = total;
    }
    public static SpawnableQuantity operator +(SpawnableQuantity a, int b) => new SpawnableQuantity(a.min + b, a.max + b, a.total + b);
}


public class SpawnManager : MonoBehaviour
{

    public List<SpawnZone> spawnZones;

    public List<SpawnableWave> spawnables = new List<SpawnableWave>();

    // Start is called before the first frame update
    void Start()
    {
        foreach (var spawnItem in spawnables)
        {
            StartCoroutine(spawnItem.Spawn(GetRandomZone()));
        }
    }

    SpawnZone GetRandomZone()
    {
        var index = Random.Range(0, spawnZones.Count);
        return spawnZones[index];
    }
    public void Stop()
    {
        enabled = false;
        StopAllCoroutines();
    }
}
