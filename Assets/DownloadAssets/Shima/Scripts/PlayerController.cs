using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
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
        // Debug.Log(x);
        // Debug.Log(y);

    }

    private void FixedUpdate()
    {

        if (x > 0)
        {
            rb2d.position += Vector2.right/10;
        }
        if (x < 0)
        {
            rb2d.position += Vector2.left/10;
        }
        if (y > 0)
        {
            rb2d.position += Vector2.up/10;
        }
        if (y < 0)
        {
            rb2d.position += Vector2.down/10;
        }
        if (x == 0 && y == 0)
        {
            rb2d.velocity = Vector2.zero;
        }

    }
}