using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject player;
    void Start()
    {
        player = GameObject.FindWithTag("Player").gameObject;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector3(player.transform.position.x +2,player.transform.position.y,-10);
    }
}
