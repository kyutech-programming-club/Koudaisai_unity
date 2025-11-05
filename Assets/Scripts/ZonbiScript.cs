using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class ZonbiScript : MonoBehaviour
{
    public GameObject Idle;
    public List<GameObject> GameObjectsList = new List<GameObject>();

    // Start is called before the first frame update
    private Rigidbody2D rigidbody2D;
    public Sprite sprite;
    public float span;
    public float walkspeed;
    public GameObject player;
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 diff = player.transform.position - transform.position;
        float angle = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg; // 向きの角度を求める
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        Walk();
        rigidbody2D.velocity = transform.right.normalized * walkspeed;
    }
    void Iddle()
    {
        foreach (GameObject g in GameObjectsList)
        {
            g.SetActive(false);
        }
        Idle.SetActive(true);
    }

    void Walk()
    {
        span += Time.deltaTime * walkspeed * 2;
        if (span <= 1)
        {
            Idle.SetActive(false);
            GameObjectsList[0].SetActive(true);
            GameObjectsList[1].SetActive(false);
        }
        else if (span <= 2)
        {
            Idle.SetActive(false);
            GameObjectsList[0].SetActive(false);
            GameObjectsList[1].SetActive(true);
        }
        else
        {
            span = 0;
        }
    }
    public List<GameObject> gameObjects;
    public GameObject Deathset;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        // if (collision.transform.tag == "Bullet")
        // {
        //     GetDamage(10);
        //     Destroy(collision.gameObject);
        // }
        if (collision.transform.tag == "Bom")
        {
            GetDamage(100);
        }
        if (collision.transform.tag == "Ice")
        {
            sp = walkspeed;
            walkspeed = sp / 2;
            Invoke("BackStatus", 3f);
        }
        if (collision.transform.tag == "Wind")
        {
            sp = walkspeed;
            walkspeed = sp / 1.5f;
            Invoke("BackStatus", 3f);
        }
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.tag == "Fire")
        {
            GetDamage(0.1f);
        }
        if (collision.transform.tag == "Wind")
        {
            GetDamage(0.05f);
        }
    }
    private float sp;
    public void BackStatus()
    {
        walkspeed = sp;
    }
    public Slider slider;
    private float Hp = 50;

    public GameObject sliderObj;
    public void GetDamage(float damage)
    {
        if (sliderObj.activeSelf == false)
        {
            sliderObj.SetActive(true);
        }
        Hp -= damage;
        if (Hp <= 0)
        {
            slider.value = 0;
            int R = Random.Range(0, gameObjects.Count * 2);
            if (R < gameObjects.Count)
            {
                Instantiate(gameObjects[R], transform.position, Quaternion.identity);
            }
            GameObject.FindWithTag("Timer").GetComponent<Timer>().score += 1;
            Instantiate(Deathset, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        else
        {
            slider.value = Hp;
        }
    }

}
