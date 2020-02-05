using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTargetCollider : MonoBehaviour
{
    public List<GameObject> ignores = new List<GameObject>();
    private void OnTriggerEnter(Collider other)
    {
        if (!ignores.Contains(other.gameObject))
        {
            Debug.Log("Destroyed on collision " + other.gameObject.name);
            Destroy(other.gameObject);
        }
    }
}
