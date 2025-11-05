using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class LazerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> enmeys;
    private bool isbool;
    private EnemyMoveScript enemyScript;
    public LineRenderer lineRenderer;
    public int lv;
    public GameObject lazer;
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (enmeys.Count > 0)
        {
            if (enmeys[0] != null)
            {
                lazer.SetActive(true);
                transform.LookAt(enmeys[0].transform);
                if (isbool == false)
                {
                    enemyScript = enmeys[0].GetComponent<EnemyMoveScript>();
                    isbool = true;
                }
                if (enemyScript != null)
                {
                    enemyScript.GetDamage(lv);
                }
            }
                else
                {
                    lazer.SetActive(false);
                    enmeys.RemoveAt(0);
                }
        }
        else
        {
            lazer.SetActive(false);
            isbool = false;
        }
    }
        void OnTriggerEnter(Collider other)
    {

            if (other.transform.tag == "Enemy")
            {
                // if (enmeys.Count > 0)
                // {
                //     enmeys.RemoveAt(0);
                // }
                enmeys.Add(other.gameObject);
            }  
    }
    void OnTriggerExit(Collider other)
    {
            if (other.transform.tag == "Enemy")
            {
                enmeys.Remove(other.gameObject);
            }
    }
}
