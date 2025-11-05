using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Gamesystemscript : MonoBehaviour
{
    public GameObject enemy;
    public float _repeatSpan;
    private float _timeElapsed;
    private float rnd1;
    private float span;
    public List<GameObject> mobs;

    // Start is called before the first frame update
    void Start()
    {
        _timeElapsed = 0;
    }


    // Update is called once per frame
    private float max = 3;
    void Update()
    {
        _timeElapsed += Time.deltaTime;
        if (_timeElapsed >= _repeatSpan)
        {

            _timeElapsed = 0;
            int rnd = Random.Range(-12, 5);
            if (rnd < -9)
            {
                rnd1 = Random.Range(-6, 6);
                Instantiate(enemy, transform.position + new Vector3(-10, rnd1, 0), Quaternion.identity);
            }
            else if (rnd >= -9 && rnd <= 0)
            {
                int R = Random.Range(0, 2);
                if (R == 0)
                {
                    rnd1 = Random.Range(-6, 6);
                    Instantiate(enemy, transform.position + new Vector3(-10, rnd1, 0), Quaternion.identity);
                }
                else
                {
                    rnd1 = Random.Range(-10, 10);
                    Instantiate(enemy, transform.position + new Vector3(rnd1, 6, 0), Quaternion.identity);
                }
            }
            else if (rnd > 0)
            {
                rnd1 = Random.Range(-10, 10);
                Instantiate(enemy, transform.position + new Vector3(rnd1, -6, 0), Quaternion.identity);
            }
            if (_repeatSpan >= 4)
            {
                _repeatSpan *= 0.9f;
                max += 1;
            }
        }

    }
}
