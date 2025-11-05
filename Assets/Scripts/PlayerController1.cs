
using System.Collections.Generic;
using UnityEngine;

public class PlayerController1 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Idle;
    public List<GameObject> GameObjectsList = new List<GameObject>();
    public float span;
    public float walkspeed;
    private Rigidbody2D rigidbody2D;
    public int Hp = 5;
    public List<Sprite> sprite;
    public List<GameObject> items;
    public List<GameObject> FirstBullet;
    public List<GameObject> lifes;
    public GameObject life;
    public GameObject GO;
    public GameObject Carsol;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        NewScore score = GameObject.FindWithTag("ScoreText").GetComponent<NewScore>();
        score.item = items[0];
        score.sprite = sprite[0];
        score.bulletList.bullet_L = FirstBullet[0];
        score.ItemL();
        score.bulletList.bullet_R = FirstBullet[1];
        score.ItemR();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var mousePos = Input.mousePosition;
        // スクリーン座標のZ値を5に変更  
        var screenPos = new Vector3(mousePos.x, mousePos.y, 0);
        // ワールド座標に変換  
        var worldPos = Camera.main.ScreenToWorldPoint(screenPos);
        if (worldPos != null)
        {
            Carsol.transform.position = worldPos + new Vector3(0, 0, 9);
            if (Carsol.activeSelf == false)
            {
                Carsol.SetActive(true);
            }
        }
        else
        {
            Carsol.SetActive(false);
        }
        Vector3 diff = worldPos - transform.position;
        float angle = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg; // 向きの角度を求める
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        // ワールド座標を3Dオブジェクトの座標に適用  
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        if (x == 0 && y == 0)
        {
            Iddle();
            rigidbody2D.velocity = Vector2.zero;
        }
        else
        {
            Walk();
            rigidbody2D.velocity = new Vector2(x, y).normalized * walkspeed;
        }
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
        span += Time.deltaTime * walkspeed;
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
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            if (lifes.Count >= 1)
            {
                GameObject l = lifes[lifes.Count - 1];
                lifes.Remove(lifes[lifes.Count - 1]);
                Destroy(l);
            }
            else
            {
                //Debug.Log("GameOver");
                GO.SetActive(true);
                Time.timeScale = 0;

            }
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Cure")
        {
            GameObject l = Instantiate(life, GameObject.FindWithTag("PlayerHP").transform);
            l.transform.localPosition = lifes[lifes.Count - 1].transform.localPosition + new Vector3(-25, 0, 0);
            lifes.Add(l);
            Destroy(collision.gameObject);
        }
    }
}
