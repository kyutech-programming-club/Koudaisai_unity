using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class start : MonoBehaviour
{
    [SerializeField] GameObject Canvas;
    [SerializeField] GameObject Gamesystem;
    [SerializeField] GameObject EventSystem;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Canvas.SetActive(true);
            Gamesystem.SetActive(true);
            EventSystem.SetActive(true);
            gameObject.SetActive(false);
        }
        
    }
}
