using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySimpleMove : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private SpriteRenderer spriteRenderer;

    [Header("Sprite Settings")]
    public Sprite right;
    public Sprite left;
    public Sprite up;
    public Sprite down;

    [Header("References")]
    public Score score;
    public Score.Kigou kigou;
    public Transform player;

    private Vector2 direction;
    private float x;
    private float y;
    private float firstX;
    private float firstY;
    private int muki; // 向き

    void Start()
    {
        // コンポーネント取得
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        score = GameObject.Find("ScoreText").GetComponent<Score>();
        player = GameObject.FindWithTag("Player").transform;

        // 初期位置の記録
        x = transform.position.x;
        y = transform.position.y;
        firstX = x - player.position.x;
        firstY = y - player.position.y;

        // 初期進行方向を決定
        if (transform.position.x <= player.position.x - 10)
        {
            direction = Vector2.right;
            muki = 1;
            transform.rotation = Quaternion.Euler(0, 0, 90f);
        }
        else if (transform.position.y >= player.position.y + 6)
        {
            direction = Vector2.down;
            muki = -2;

        }
        else if (transform.position.y <= player.position.y - 6)
        {
            direction = Vector2.up;
            muki = 2;
            transform.rotation = Quaternion.Euler(0, 0, 180);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 270);
            direction = Vector2.left;
            muki = -1;
        }
    }

    void FixedUpdate()
    {
        // transform.position = new Vector2(x + player.position.x, Mathf.Sin((x - player.position.x) * 2) * 3/2 + first_y);
        // プレイヤーの近くにいる場合のみ移動
        if (IsNearPlayer(12f))
        {
            rb2d.velocity = transform.up * -1 * 1f;
        }

        // // 動き方（軌道の種類）
        // if (Mathf.Abs(firstY) >= 5)
        // {
        //     MoveHorizontalWave();
        // }
        else if (Mathf.Abs(firstX) >= 9)
        {
            MoveVerticalWave();
        }

        // 一定距離離れたら削除
        if (!IsNearPlayer(15f))
        {
            Destroy(gameObject);
        }
    }

    // private void MoveHorizontalWave()
    // {
    //     transform.position = new Vector2(
    //         Mathf.Sin((y - player.position.y) * 2) * 1.5f + firstX,
    //         y + player.position.y
    //     );

    //     if (muki == 1) spriteRenderer.sprite = right;
    //     else if (muki == -1) spriteRenderer.sprite = left;
    // }

    private void MoveVerticalWave()
    {
        transform.position = new Vector2(
            x + player.position.x,
            Mathf.Sin((x - player.position.x) * 2) * 1.5f + firstY
        );

        // if (muki == 2) spriteRenderer.sprite = up;
        // else if (muki == -2) spriteRenderer.sprite = down;
    }

    private bool IsNearPlayer(float range)
    {
        return Mathf.Abs(transform.position.x - player.position.x) < range &&
               Mathf.Abs(transform.position.y - player.position.y) < range;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Fire" || other.gameObject.tag == "Fire" || other.gameObject.tag == "Ice" || other.gameObject.tag == "Bullet")
        {
            GameObject.FindWithTag("Timer").GetComponent<Timer>().score += 1;
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Player")
        {
            Destroy(gameObject);
        }

    }
}
