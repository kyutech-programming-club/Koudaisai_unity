using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet2Dscript : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rigidbody2D;
    public GameObject bom;
    public float damage = 1f;
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.AddForce(transform.right * 100, ForceMode2D.Impulse);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            ZonbiScript zonbiScript = collision.gameObject.GetComponent<ZonbiScript>();
            if (zonbiScript != null)
            {
                zonbiScript.GetDamage(damage);
            }
            if (bom != null)
            {
                Instantiate(bom, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);

        }
    }

    // Update is called once per frame
}
