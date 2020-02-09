using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DestroyEnemyOnTrigger : MonoBehaviour
{
    public UnityEvent callback;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<BaseEnemy>())
        {
            Destroy(other.gameObject);
            callback.Invoke();
        }
    }
}
