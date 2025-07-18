using System.Linq.Expressions;
using UnityEngine;

public class Triangle : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private GameObject player;
    private Vector2 direct;
    private Rigidbody2D rigidbody2D;
     public float speed = 2f;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        direct = player.transform.position - transform.position;

        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
         rigidbody2D.MovePosition(rigidbody2D.position + direct.normalized * speed * Time.fixedDeltaTime);
    }
    

}
