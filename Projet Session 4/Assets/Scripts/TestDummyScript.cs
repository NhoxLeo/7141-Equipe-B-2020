﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDummyScript : MonoBehaviour
{
    Vector3 move;
    public Rigidbody playerRigidBody;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        move.x = Input.GetAxisRaw("Horizontal");
        move.z = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        playerRigidBody.MovePosition(playerRigidBody.position + (move * 5) * Time.fixedDeltaTime);
    }


}