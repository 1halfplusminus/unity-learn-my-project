using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movable : MonoBehaviour
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
        var vAxis = Input.GetAxis("Vertical");
        var hAxis = Input.GetAxis("Horizontal");
        Debug.Log("On Move");
        /*     moveRb.AddForce(Vector3.right * hAxis * speed, ForceMode.Acceleration); */
        moveRb.AddForce(transform.forward * vAxis * speed, ForceMode.Acceleration);
        transform.Rotate(Vector3.up * hAxis);
    }
}
