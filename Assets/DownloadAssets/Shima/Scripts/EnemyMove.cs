using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    Rigidbody2D rb2d;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        // rb2d.velocity = new Vector2(1, 0);

    }

    // Update is called once per frame
    void Update()
    {
        rb2d.velocity = new Vector2(transform.right.x, transform.right.y/2)*10;
        transform.Rotate(0, 0, 1f);
    }
}
