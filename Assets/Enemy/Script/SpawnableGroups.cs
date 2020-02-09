using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static System.Math;

[System.Serializable]
public class OnGroupSpawn : UnityEvent<SpawnableGroups> { }

[System.Serializable]
public class SpawnableGroups : MonoBehaviour
{
    public List<SpawnableInstance> spawnInstances = new List<SpawnableInstance>();
    public SpawnableQuantity quantity = new SpawnableQuantity();

    public List<GameObject> instances
    {
        get;
        private set;
    } = new List<GameObject>();
    public OnSpawnEvent onSpawn = new OnSpawnEvent();

    public OnSpawnEvent onDestroy = new OnSpawnEvent();

    public UnityEvent onGroupDestroy;

    public UnityEvent onGroupSpawn;
    void Start()
    {
        foreach (var item in spawnInstances)
        {
            item.onSpawn.AddListener((GameObject instance) =>
            {
                onSpawn.Invoke(instance);
                instances.Add(instance);
            });
            item.onDestroy.AddListener((GameObject instance) =>
            {
                instances.Remove(instance);
                onDestroy.Invoke(instance);
            });
        }
    }
    public IEnumerator Spawn(SpawnZone zone)
    {
        int index = Random.Range(0, spawnInstances.Count);
        var itemTemplate = spawnInstances[index];
        int randomQuantity = Mathf.Clamp(Random.Range(quantity.min, quantity.max), quantity.min, quantity.total - instances.Count);
        if (randomQuantity > 0)
        {
            onGroupSpawn.Invoke();
        }
        for (int i = 0; i < randomQuantity; i++)
        {
            itemTemplate.StartCoroutine(itemTemplate.Spawn(zone));
        }
        StartCoroutine(WaitForAllDestroy());
        yield return null;
    }

    public IEnumerator WaitForAllDestroy()
    {
        if (instances.Count > 0)
        {
            yield return new WaitUntil(() => instances
                 .TrueForAll((g) => g == null));
            onGroupDestroy.Invoke();
            Debug.Log(name + " destroyed");
        }
    }
}
