using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableLinear : MonoBehaviour, Move
{
    Rigidbody moveRb;

    public float speed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        moveRb = GetComponent<Rigidbody>();
    }
    public void Move()
    {
        if (!enabled)
        {
            return;
        }
        /*         var vAxis = Input.GetAxis("Vertical"); */
        var hAxis = Input.GetAxis("Horizontal");
        /*     moveRb.AddForce(Vector3.right * hAxis * speed, ForceMode.Acceleration); */
        moveRb.AddForce(transform.forward * hAxis * speed);
        /*   transform.Rotate(Vector3.up * hAxis); */
    }
}
