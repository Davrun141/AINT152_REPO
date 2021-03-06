﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCharacterController2D : MonoBehaviour {
    public float speed = 5.0f;
    Rigidbody2D RB2D;
    void Start()
    {
        RB2D = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        RB2D.velocity = new Vector2(x, y) * speed;
        RB2D.angularVelocity = 0.0f;
    }
}
