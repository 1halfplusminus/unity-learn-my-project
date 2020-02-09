using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpawnableInstance : MonoBehaviour
{
    public GameObject prefab;
    public OnSpawnEvent onSpawn;

    public OnSpawnEvent onDestroy;
    public IEnumerator Spawn(SpawnZone zone)
    {
        Vector3 instancePos = zone.GetRandomPoint();
        return Spawn(zone.GetRandomPoint());
    }
    public IEnumerator Spawn(Vector3 instancePos)
    {
        var instance = Instantiate(prefab, instancePos, prefab.transform.rotation);
        return AfterSpawn(instance);
    }
    public IEnumerator Spawn(GameObject target)
    {
        var instance = Instantiate(prefab, target.transform.position, prefab.transform.rotation, target.transform);
        return AfterSpawn(instance);
    }
    public IEnumerator Spawn(Collision target)
    {
        var instance = Instantiate(prefab, target.transform.position, prefab.transform.rotation, target.transform);
        return AfterSpawn(instance);
    }
    private IEnumerator AfterSpawn(GameObject instance)
    {
        onSpawn.Invoke(instance);
        var name = instance.name;
        yield return new WaitUntil(() => instance == null);
        Debug.Log("AfterSpawn " + name + " destroyed ");
        onDestroy.Invoke(instance);
    }
}
