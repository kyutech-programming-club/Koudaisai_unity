using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;//この行を追記


public class NewBehaviourScript : MonoBehaviour
{
    Rigidbody2D rb2d;
    private float x;
    private float first_x;
    private float first_y;
    private Vector2 dic;
    private GameObject player;
    public SpriteRenderer spriteRenderer;
    public Sprite sprit1;
    public Sprite sprit2;


    void Start()
    {
        x = transform.position.x;
        rb2d = GetComponent<Rigidbody2D>();
        // rb2d.velocity = new Vector2(1, 0);
        y = transform.position.y;
        first_x = transform.position.x;
        first_y = y;
        rnd = Random.Range(1, 3);
        Debug.Log(transform.position);
        if (transform.position.x <= -10)
        {
            dic = new Vector2(1, 0);
        }
        else if (transform.position.y >= 10)
        {
            dic = new Vector2(0, -1);
        }
        else if (transform.position.y <= -10)
        {
            dic = new Vector2(0, 1);
        }
        else
        {
            dic = new Vector2(-1, 0);
        }
        //Debug.Log(dic);
    }
    private int rnd;
    private float y;
    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < 21 && transform.position.y < 12 && transform.position.x > -12 && transform.position.y > -12)
            x += 0.01f * dic.x;
            y += 0.01f * dic.y;
        transform.position = new Vector3(x, y, 0);
        if (rnd == 1)
        {
            if (first_y == 10 || first_y == -10)
            {
                spriteRenderer.sprite = sprit2;
                transform.position = new Vector2(Mathf.Sin(y * 2) * 3/2 + first_x, y);
            }
            else if (first_x == 5 || first_x == -10)
            {
                spriteRenderer.sprite = sprit2;
                transform.position = new Vector2(x, Mathf.Sin(x * 2) * 3/2 + first_y);
            }
        }
        else if (rnd == 2)
        {
            spriteRenderer.sprite = sprit1;
            transform.position = new Vector3(x, y, 0);
        }
        if (transform.position.x > 6 || transform.position.y > 12 || transform.position.x < -12 || transform.position.y < -12)
        {
            Destroy(this.gameObject);
        }

        if (transform.position.x == -12 && transform.position.y == 12)
        {
            transform.position = new Vector3(-12, 12, 0);
            rb2d.velocity = new Vector3(0, 0, 0);
        }
       
    }
        void OnCollisionEnter2D(Collision2D collision)
        {
        if (collision.transform.tag == "Player")
        {
            SceneManager.LoadScene(1);
            Debug.Log("Damage");
        }
        }
    }
