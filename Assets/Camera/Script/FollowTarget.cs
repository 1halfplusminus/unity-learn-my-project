using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public float height = 1f;
    public float distance = 2f;

    public float turnSpeed = 4.0f;

    public Transform target;
    private Vector3 offsetX;
    private Vector3 offsetY;
    // Start is called before the first frame update
    void Start()
    {
        LateUpdate();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        offsetX = new Vector3(0, height, distance);
        offsetY = new Vector3(0, 0, distance);
        transform.position = target.position + target.TransformDirection(offsetX);
        transform.rotation = Quaternion.LookRotation(target.forward + target.TransformVector(offsetY));
        transform.LookAt(target.position);
    }
}
