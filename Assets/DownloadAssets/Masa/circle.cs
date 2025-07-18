using System.Linq.Expressions;
using UnityEngine;

public class circle : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private GameObject player;
    private Vector2 direct;
    private Rigidbody2D rigidbody2D;
    public GameObject cicle;

    private float _repeatSpan;
    private float _timeElapsed;
    public float speed = 2f;
    void Start()
    {
        _camera = Camera.main;
        player = GameObject.FindWithTag("Player");
        direct = player.transform.position - transform.position;
        rigidbody2D = GetComponent<Rigidbody2D>();
        _repeatSpan = 3;
        _timeElapsed = 0;
    }

    // Update is called once per frame
    void Update()
    {
       
         rigidbody2D.MovePosition(rigidbody2D.position + direct.normalized * speed * Time.fixedDeltaTime);
        if (IsOutOfBounds())
        {
            Destroy(gameObject);
            transform.position = new Vector3(0, 4, 0);
        }

    }
    
    private Camera _camera;

    bool IsOutOfBounds()
    {
        // 画面の左上と右下の座標を取得
        Vector3 viewportPoint = _camera.WorldToViewportPoint(transform.position);

        // 画面の範囲外にいるか判定
        if (viewportPoint.x < 0 || viewportPoint.x > 1 || viewportPoint.y < 0 || viewportPoint.y > 1)
        {
            return true;
        }

        return false;
    }

}
