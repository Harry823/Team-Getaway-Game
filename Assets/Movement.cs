﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public string horizontal_axis_name = "Horizontal";
    //public string vertical_axis_name = "Vertical";

    Rigidbody2D rb;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    public int speed = 5;

    //public Vector2 jump;
    public float jumpForce = 1.0f;
    //public bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //jump = new Vector3(0.0f, 2.0f, 0.0f);
    }


    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);

        float time = Time.deltaTime;
        float displacement_x = Input.GetAxis(horizontal_axis_name) * speed * time;
        transform.position += new Vector3(displacement_x, 0, 0);

        if (Input.GetButton("Jump"))
        {
			//Debug.Log("The jump button registers");
			rb.AddForce(new Vector2(rb.velocity.x, jumpForce), ForceMode2D.Impulse);
			//rb.velocity = new Vector2(rb.velocity.x, jumpForce);
		}
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * time;
        }
        else if(rb.velocity.y > 0 && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * time;
        }

    }
}
