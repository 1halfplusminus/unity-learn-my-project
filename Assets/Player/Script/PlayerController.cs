﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Groudable groudable;
    Movable movable;
    Jumpable jumpable;
    // Start is called before the first frame update
    void Start()
    {
        groudable = GetComponent<Groudable>();
        movable = GetComponent<Movable>();
        jumpable = GetComponent<Jumpable>();
    }

    // Update is called once per frame
    void Update()
    {
        if (groudable.isGrounded())
        {
            movable.Move();
            jumpable.Jump();
        }
    }

}
