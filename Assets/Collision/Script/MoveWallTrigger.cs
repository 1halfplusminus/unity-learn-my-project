using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWallTrigger : MonoBehaviour
{
    public GameObject wall;
    public GameObject target;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerController>())
        {
            StartCoroutine(MoveAfterDelay());
        }
    }

    IEnumerator MoveAfterDelay()
    {
        yield return new WaitForFixedUpdate();
        wall.transform.position = target.transform.position - target.transform.forward;
    }
}
