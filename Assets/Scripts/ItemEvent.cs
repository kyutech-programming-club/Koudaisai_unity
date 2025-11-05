using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemEvent : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> Weapon;
    // Update is called once per frame
    public GameObject Canon;
    
    public void Event(String eventName)
    {
        Debug.Log(eventName);
        if (eventName == "Item0")
        {
            for (int i = Canon.transform.childCount - 1; i >= 0; i--)
            {
                Destroy(Canon.transform.GetChild(i).gameObject);
            }
            GameObject weapon = Instantiate(Weapon[0], Canon.transform);
            weapon.transform.parent = Canon.transform;
            weapon.transform.localPosition = Vector3.zero;
        }
    }
}
