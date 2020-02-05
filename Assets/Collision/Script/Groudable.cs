using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Groudable : MonoBehaviour
{
    public UnityEvent onGrounded;
    public UnityEvent onGroundExit;
    bool grounded;

    public void OnGround()
    {
        grounded = true;
        onGrounded.Invoke();
    }
    public void OnGroundExit()
    {
        grounded = false;
        onGroundExit.Invoke();
    }
    public bool isGrounded()
    {
        return grounded;
    }
}
