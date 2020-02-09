using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Move
{
    void Move();
}
public class Movable : MonoBehaviour, Move
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
        var vAxis = Input.GetAxis("Vertical");
        var hAxis = Input.GetAxis("Horizontal");
        moveRb.AddForce(transform.forward * vAxis * speed);
        transform.Rotate(Vector3.up * hAxis);
    }
}
