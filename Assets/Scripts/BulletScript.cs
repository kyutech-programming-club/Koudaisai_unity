using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 100;
    private Rigidbody rigidbody;
    public int damage = 10;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.AddForce(transform.forward * speed, ForceMode.Impulse);
        Destroy(gameObject, 5f);
    }
    // void OnCollisionEnter(Collision collision)
    // {
    //     if (collision.gameObject.tag == "Enemy")
    //     {
    //         // Destroy(collision.gameObject);
    //         collision.gameObject.GetComponent<EnemyMoveScript>().GetDamage(damage);
    //         Destroy(gameObject);
    //     }
    // }
    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyMoveScript>().GetDamage(damage);
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
}
