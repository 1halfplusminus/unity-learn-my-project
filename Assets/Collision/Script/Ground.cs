using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ground : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("OnGround");
        Groudable groudable;
        if (collision.gameObject.TryGetComponent<Groudable>(out groudable))
        {
            groudable.OnGround();
        }
    }
    void OnCollisionExit(Collision collision)
    {
        Debug.Log("LeaveGround");
        Groudable groudable;
        if (collision.gameObject.TryGetComponent<Groudable>(out groudable))
        {
            groudable.OnGroundExit();
        }
    }
}
