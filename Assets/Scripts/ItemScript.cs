using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Score.Kigou kigou;
    // public List<GameObject> targetObj = new List<GameObject>();
    // public int lv =1;
    public Sprite sprite;
    public List<GameObject> items;
    void Start()
    {
        // textMeshProUGUI.text = lv.ToString();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Player")
        {
            NewScore score = GameObject.FindWithTag("ScoreText").GetComponent<NewScore>();
            score.ItemGet(items[0],items[1],kigou,sprite);
            Destroy(gameObject);
        }
    }
}
