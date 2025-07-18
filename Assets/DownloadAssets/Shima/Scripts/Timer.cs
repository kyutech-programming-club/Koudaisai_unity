using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class a : MonoBehaviour
{
    private float timer = 0f;
private TextMeshProUGUI textMeshProUGUI;
    // Start is called before the first frame update
    void Start()
    {
		textMeshProUGUI = GetComponent<TextMeshProUGUI>();
    }
    void Update()
    {
        timer += Time.deltaTime;
        textMeshProUGUI.text = (60 - timer).ToString("F0") + "s";
    }
}
