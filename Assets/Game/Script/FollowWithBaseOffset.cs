using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowWithBaseOffset : MonoBehaviour
{
    public Transform target;

    Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - target.position;
    }

    // Update is called once per frame
    void Update()
    {
        var nextPosition = target.position + offset;
        if (nextPosition.z > transform.position.z)
        {
            transform.position = target.position + offset;
        }

    }
}
