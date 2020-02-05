using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicProjectile : MonoBehaviour
{
    public GameObject projectile;
    public float lifetime = 1f;
    public float fireRate = 1f;

    float lastFire;
    List<GameObject> instances;
    // Start is called before the first frame update
    void Start()
    {
        instances = new List<GameObject>();
        lastFire = Time.time;

    }

    public void Fire()
    {
        if (Time.time >= lastFire + fireRate)
        {
            var instance = Instantiate(projectile, transform.position, projectile.transform.rotation);
            instances.Add(instance);
            StartCoroutine(Destroy(instance));
            lastFire = Time.time;
        }

    }
    public IEnumerator Destroy(GameObject instance)
    {
        yield return new WaitForSeconds(lifetime);

        instances.Remove(instance);

        Destroy(instance);

    }
}
