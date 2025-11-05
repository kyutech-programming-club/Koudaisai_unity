using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public GameObject watch;
    private float timer = 0f;
    private TextMeshProUGUI textMeshProUGUI;
    public TextMeshProUGUI score_text;
    public GameObject score_obj;
    public int score;
    // Start is called before the first frame update
    void Start()
    {
        textMeshProUGUI = GetComponent<TextMeshProUGUI>();
    }
    void FixedUpdate()
    {
        timer += Time.deltaTime;
        textMeshProUGUI.text = (60 - timer).ToString("F0") + "s";
        if (timer >= 150)
        {
            Time.timeScale = 0;
            score_obj.SetActive(true);
            score_text.text = score.ToString();
        }
        float rotationSpeed = 360f / 150;
        watch.transform.Rotate(0f, 0f, -1 * rotationSpeed * Time.deltaTime);
    }
}
