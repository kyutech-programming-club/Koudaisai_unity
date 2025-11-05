using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFoward : MonoBehaviour
{
    // Start is called before the first frame update
    // Update is called once per frame
    private Rigidbody rd;
    public Vector3 dict;
    private bool isPlayer = true;
    void Start()
    {
        rd = GetComponent<Rigidbody>();
        transform.LookAt(transform.position - dict);
        Destroy(gameObject, 6f);
    }
    void FixedUpdate()
    {
        if (isPlayer)
        {
            rd.velocity = -dict * 2f;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Bullet")
        {

        }
        if (other.transform.tag == "Blade")
        {

        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            isPlayer = false;
            rd.AddForce(collision.gameObject.GetComponent<Rigidbody>().velocity + new Vector3(0, 10, 0), ForceMode.Impulse);
                    Destroy(gameObject, 1f); 
        }
        if (collision.transform.tag == "Enemy")
        {
            isPlayer = false;
            rd.AddForce(collision.gameObject.GetComponent<Rigidbody>().velocity + new Vector3(0, 10, 0), ForceMode.Impulse);
            Destroy(gameObject, 1f); 
        }
    }
}
