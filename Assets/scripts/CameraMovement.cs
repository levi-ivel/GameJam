using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float moveHorizontal = 0f;
        float moveVertical = 0f;

        if (Input.GetKey(KeyCode.W))
        {
            moveVertical = 1f;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            moveVertical = -1f;
        }

        if (Input.GetKey(KeyCode.D))
        {
            moveHorizontal = 1f;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            moveHorizontal = -1f;
        }

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb.AddForce(movement);
    }
}

    
