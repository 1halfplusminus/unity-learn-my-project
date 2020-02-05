using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class SimpleTrigger : MonoBehaviour
{
    public UnityEvent callback;
    public List<GameObject> ignores = new List<GameObject>();
    private void OnTriggerEnter(Collider other)
    {
        if (!ignores.Contains(other.gameObject))
        {
            callback.Invoke();
        }
    }
}
