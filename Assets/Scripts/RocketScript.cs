using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RocketScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject enemy;
    private Rigidbody rigidbody;
    private Quaternion enemyTra;
    private Quaternion thisTra;
    public GameObject bom;
    public int damage;
      float angularVelocity = 500f;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        Destroy(gameObject, 3f);
    }
    // Update is called once per frame
    void Update()
    {
        if (enemy != null)
        {
                Quaternion rotation = Quaternion.LookRotation(enemy.transform.position - transform.position);
        // 現在の方向と目標の方向がなす角度
        float angle = Quaternion.Angle(transform.rotation, rotation);

        if (angle > 0)
        {
            // 経過時間によって変化させる角度
            float deltaAngle = angularVelocity * Time.deltaTime;
            // オブジェクトの方向を変更
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, deltaAngle / angle);
        }
            rigidbody.AddForce(transform.forward * 0.005f, ForceMode.Impulse);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyMoveScript>().GetDamage(damage);
            Destroy(gameObject);
        }
    }
    void OnDestroy()
    {
        Instantiate(bom, transform.position, Quaternion.identity);
    }
}

