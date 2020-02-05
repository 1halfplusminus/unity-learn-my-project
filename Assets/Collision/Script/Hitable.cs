using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Hitable : MonoBehaviour
{
    public UnityEvent onHit;

    public void Hit()
    {
        onHit.Invoke();
    }
}
