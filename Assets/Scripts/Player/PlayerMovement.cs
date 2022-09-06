using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header ("Player Movement Variables")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;

    [Header("Bengal Variables")]
    [SerializeField] private Transform bengalTransform;

    private float movX, movY = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movX = Input.GetAxis("Horizontal");
        movY = Input.GetAxis("Vertical");

    }
    private void FixedUpdate()
    {
        Move();
        RotateBengal();
    }
    private void Move()
    {
        rb.velocity = new Vector2(movX * speed, movY * speed);


    }
    private void Rotate(bool faceRight)
    {
        if(faceRight)
            transform.rotation = Quaternion.Euler(Vector3.zero);
        else
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
               
        }
    }

    private void RotateBengal()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 targetPos = Camera.main.WorldToScreenPoint(transform.localPosition);
        Vector2 diff = new Vector2(mousePos.x - targetPos.x, mousePos.y - targetPos.y);
        float angle = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;

        if (angle < -90 || angle > 90)
        {
            if (this.transform.eulerAngles.y.Equals(0))
            {
                Rotate(false);
                bengalTransform.localRotation = Quaternion.Euler(180, 0, -angle);
            }
           else if(this.transform.eulerAngles.y.Equals(180))
                bengalTransform.localRotation = Quaternion.Euler(180, 180, -angle);


        }
        else
        {
            Rotate(true);
            bengalTransform.localRotation = Quaternion.Euler(0f, 0f, angle);
        }
    }
}
