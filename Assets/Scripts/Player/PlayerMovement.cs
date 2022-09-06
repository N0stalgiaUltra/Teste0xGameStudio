using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;

    private float movX, movY = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movX = Input.GetAxis("Horizontal");
        movY = Input.GetAxis("Vertical");
        Rotate();

    }
    private void FixedUpdate()
    {
        Move();

    }
    private void Move()
    {
        rb.velocity = new Vector2(movX * speed, movY * speed);
    }
    private void Rotate()
    {
        if (movX > 0)
            transform.rotation = Quaternion.Euler(Vector3.zero);
        else if (movX < 0)
            transform.rotation = Quaternion.Euler(0, 180, 0);
    }
}
