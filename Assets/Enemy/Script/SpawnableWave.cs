using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Events;

[System.Serializable]
public class SpawnableWave : MonoBehaviour
{

    public List<SpawnableGroups> items = new List<SpawnableGroups>();
    public float spawnInterval = 10.0f;
    public float startDelay = 1f;
    public bool continuous = true;

    public List<GameObject> instances
    {
        get;
        private set;
    } = new List<GameObject>();

    public UnityEvent onWaveDestroy;
    void Start()
    {
        foreach (var item in items)
        {
            item.onSpawn.AddListener((GameObject instance) =>
            {
                instances.Add(instance);
            });
            item.onDestroy.AddListener((GameObject instance) =>
            {
                instances.Remove(instance);
            });
        }
    }
    public IEnumerator Spawn(SpawnZone zone)
    {
        yield return new WaitForSeconds(startDelay);
        yield return SpawnWave(zone);
    }

    IEnumerator SpawnWave(SpawnZone zone)
    {
        foreach (var item in items)
        {
            StartCoroutine(item.Spawn(zone));
        }
        if (!continuous)
        {
            yield return WaitForAllDestroy();
        }
        else
        {
            StartCoroutine(WaitForAllDestroy());
        }

        yield return new WaitForSeconds(spawnInterval);
        yield return SpawnWave(zone);
    }
    public IEnumerator WaitForAllDestroy()
    {
        yield return new WaitUntil(() => instances
        .TrueForAll((g) => g == null));
        onWaveDestroy.Invoke();
        Debug.Log(name + " destroyed");
    }
}