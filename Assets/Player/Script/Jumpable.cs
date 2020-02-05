using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumpable : MonoBehaviour
{
    Rigidbody rb;

    public float force = 10f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("On Jump");
            rb.AddForce(Vector3.up * force, ForceMode.Impulse);
        }
    }
}
