using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb2d;
    [SerializeField] float speed;
    float x, y;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");

    }

    private void FixedUpdate()
    { 
        if (x > 0)
        {
            rb2d.position += Vector2.right/5;
        }
        if(x < 0)
        {
            rb2d.position += Vector2.left/5;
        }
        if(y > 0)
        {
            rb2d.position += Vector2.up/5;
        }
        if(y < 0)
        {
            rb2d.position += Vector2.down/5;
        }
        if (x == 0 && y == 0)
        {
            rb2d.velocity = Vector2.zero;
        }

    }
}