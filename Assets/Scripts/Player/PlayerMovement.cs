using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float lastHorizontalVector { get; private set; }
    public float lastVerticalVector { get; private set; }
    public Vector2 moveDir { get; private set; }
    public Vector2 lastMoveVector { get; private set; }
    
    private Rigidbody2D rb;
    private PlayerStats player;
    
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerStats>();
        rb = GetComponent<Rigidbody2D>();
        lastMoveVector = new Vector2(1, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        InputManagement();
    }

    void FixedUpdate()
    {
        Move();
    }

    void InputManagement()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDir = new Vector2(moveX, moveY).normalized;

        if (moveDir.x != 0)
        {
            lastHorizontalVector = moveDir.x;
            lastMoveVector = new Vector2(lastHorizontalVector, 0f);
        }

        if (moveDir.y != 0)
        {
            lastVerticalVector = moveDir.y;
            lastMoveVector = new Vector2(0f, lastVerticalVector);
        }

        if (moveDir.x != 0 && moveDir.y != 0)
        {
            lastMoveVector = new Vector2(lastHorizontalVector, lastVerticalVector);
        }
    }

    void Move()
    {
        rb.velocity = new Vector2(moveDir.x * player.currentMoveSpeed, moveDir.y * player.currentMoveSpeed);
    }
}
