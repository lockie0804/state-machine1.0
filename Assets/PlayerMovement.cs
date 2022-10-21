using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;

    void Update()
    {
        Movement();
    }

    void Movement()
    {
        float xAxis = Input.GetAxisRaw("Horizontal");
        float yAxis = Input.GetAxisRaw("Vertical");
        Vector2 move = new Vector2(xAxis, yAxis);

        move.Normalize();
        move *= speed * Time.deltaTime;

        transform.position += (Vector3)move;
    }

    void OldMovement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            //transform.position.y += speed;
            Vector2 newPosition = transform.position;
            newPosition.y += speed * Time.deltaTime;
            transform.position = newPosition;

        }

        if (Input.GetKey(KeyCode.S))
        {
            Vector2 playerPosition = transform.position;
            playerPosition.y -= speed * Time.deltaTime;
            transform.position = playerPosition;

        }

        if (Input.GetKey(KeyCode.D))
        {
            Vector2 playerPosition = transform.position;
            playerPosition.x += speed * Time.deltaTime;
            transform.position = playerPosition;

        }


        if (Input.GetKey(KeyCode.A))
        {
            Vector2 playerPosition = transform.position;
            playerPosition.x -= speed * Time.deltaTime;
            transform.position = playerPosition;

        }
    }
}
