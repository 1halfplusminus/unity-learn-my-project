using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelfOnTrigger : MonoBehaviour
{
    public List<GameObject> ignores = new List<GameObject>();
    private void OnTriggerEnter(Collider other)
    {
        if (!ignores.Contains(other.gameObject))
        {
            Debug.Log("Destroyed self on collision with" + other.gameObject.name);
            Destroy(gameObject);
        }
    }
}
