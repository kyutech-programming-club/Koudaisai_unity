using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class CanonScript : MonoBehaviour
{
    public List<GameObject> enemyList;
    public GameObject bullet;
    public List<Transform> bulletTransformList;
    private float span;
    public float reloadTime = 1f;
    public bool isRotate;
    public int lv;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(lv);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        span += Time.deltaTime;
        if (enemyList.Count > 0)
        {
            GameObject TargetObj = enemyList[0];
            if (TargetObj != null)
            {
                if (isRotate == false)
                {
                    transform.LookAt(TargetObj.transform);
                }
                if (span >= reloadTime)
                {
                    span = 0;
                    Fire();
                }
            }
            else if(enemyList.Count > 0)
            {
                enemyList.RemoveAt(0);
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (isRotate == false)
        {
            if (other.transform.tag == "Enemy")
            {
                enemyList.Add(other.gameObject);
            }
        }
        else
        {
            if (other.transform.tag == "Enemy")
            {
                if (enemyList.Count > 0)
                {
                    enemyList.RemoveAt(0);
                }
                enemyList.Add(other.gameObject);
            }  
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (isRotate == false)
        {
            if (other.transform.tag == "Enemy")
            {
                enemyList.Remove(other.gameObject);
            }
        }
    }
    public void Fire()
    {
        foreach (Transform t in bulletTransformList)
        {
            if (isRotate == false)
            {
                Instantiate(bullet, t.position, transform.rotation);
            }
            else
            {
                if (enemyList[0] != null)
                {
                    GameObject rocket = Instantiate(bullet, t.position, transform.rotation);
                    RocketScript rocketScript = rocket.GetComponent<RocketScript>();
                    rocketScript.enemy = enemyList[0].gameObject;
                    rocketScript.damage = 10 + lv *10;
                }
            }
        }
    }
}
