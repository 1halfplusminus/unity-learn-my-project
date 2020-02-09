using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollectableEcash : MonoBehaviour
{
    public UnityEvent callback;
    public int amount = 1;
    private void OnTriggerEnter(Collider other)
    {
        ECashStash eCashStash;
        if (other.TryGetComponent<ECashStash>(out eCashStash))
        {
            eCashStash.Collect(amount);
            Destroy(gameObject);
        }
    }
}
