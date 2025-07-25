using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Enemymasa : MonoBehaviour
{
    public GameObject cicle;
    private GameObject enemy;
    public GameObject shima;
    private float _repeatSpan;
    private float _timeElapsed;
    private float rnd1;
    
    // Start is called before the first frame update
    void Start()
    {
        _repeatSpan = 1;
        _timeElapsed = 0;
        
    }


    // Update is called once per frame
    void Update()
    {
        _timeElapsed += Time.deltaTime*2;
        int Enemyrnd = Random.Range(0, 2);
        if (Enemyrnd == 0)
        {
            enemy = cicle;
        }
        if (Enemyrnd == 1)
        {
            enemy = shima;
        }
        if (_timeElapsed >= _repeatSpan)
            {

                int rnd = Random.Range(-12, 5);
                if (rnd < -9)
                {
                    rnd1 = Random.Range(-4, 5);
                    Instantiate(enemy, new Vector3(-10, rnd1, 0.0f), Quaternion.identity);
                }
                else if (rnd >= -9 && rnd <= 0)
                {
                    rnd = Random.Range(-7, -1);
                    rnd1 = Random.Range(-1, 2);
                    if (rnd1 == -1)
                    {
                        Instantiate(enemy, new Vector3(rnd, -10, 0.0f), Quaternion.identity);
                    }
                    else if (rnd1 == 0)
                    {
                        Instantiate(enemy, new Vector3(rnd, 10, 0.0f), Quaternion.identity);
                    }
                }
                else if (rnd > 0)
                {
                    rnd1 = Random.Range(-4, 5);
                    Instantiate(enemy, new Vector3(5, rnd1, 0.0f), Quaternion.identity);
                }
                _timeElapsed = 0;
            }
        
    }
}

 