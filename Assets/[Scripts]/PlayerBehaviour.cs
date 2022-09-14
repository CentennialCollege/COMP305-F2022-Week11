using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float speed = 10.0f;
    public float horizontalForce = 10.0f;
    public float verticalForce = 10.0f;


    private Rigidbody2D rigidBody2D;

    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
    }

    public void Move()
    {
        float x = Input.GetAxisRaw("Horizontal") * Time.deltaTime;
        float y = Input.GetAxisRaw("Jump") * Time.deltaTime;
        Vector2 horizontalVector = Vector2.zero; 
        Vector2 verticalVector = Vector2.zero;

        if (x != 0.0f)
        {
            Flip(x);

            // Repositioning
            //transform.position += new Vector3(x, 0.0f);

            horizontalVector = Vector2.right * ((x > 0.0) ? 1.0f : -1.0f) * horizontalForce;

            
            

            rigidBody2D.AddForce(horizontalVector);

            rigidBody2D.velocity = Vector2.ClampMagnitude(rigidBody2D.velocity, speed);
        }

        if (y > 0.0f)
        {
            verticalVector = Vector2.up * verticalForce;

            rigidBody2D.AddForce(verticalVector);
        }




    }

    public void Flip(float x)
    {
        if (x != 0.0f)
        {
            transform.localScale = new Vector3((x > 0.0f) ? 1.0f : -1.0f, 1.0f, 1.0f);
        }
        
    }
}
