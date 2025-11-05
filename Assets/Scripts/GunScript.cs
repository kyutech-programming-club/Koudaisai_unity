using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bullet;
    public GameObject muzzle;
    public float fireSpan;
    private float span;
    void FixedUpdate()
    {
        span += Time.deltaTime;
        if (bullet.transform.name != "flashA1")
        {
            fireSpan = 2;
        }
        if (Input.GetMouseButton(0) && span >= fireSpan)
        {
            span = 0;
            Fire();
        }
    }
    public float damage =1f;
    void Fire()
    {
        GameObject bul = Instantiate(bullet, muzzle.transform.position, muzzle.transform.rotation);
        var bulletScript = bul.GetComponent<Bullet2Dscript>();
if (bulletScript == null)
{
    bulletScript = bul.GetComponentInChildren<Bullet2Dscript>();
}
        bulletScript.damage = damage;
        Destroy(bul, 2f);
    }
}
