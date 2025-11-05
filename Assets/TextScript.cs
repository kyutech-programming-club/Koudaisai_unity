using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //TextMeshProを扱う際に必要

public class TextScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI gameOverText;

    void Start()
    {
        gameOverText.color = new Color(1, 0, 0, 1);
        StartCoroutine("FadeIn");
        Destroy(gameObject, 4f);
    }

    IEnumerator FadeIn()
    {
        while (true)
        {
            for (int i = 0; i < 255; i++)
            {
                gameOverText.color = gameOverText.color - new Color32(1, 0, 0, 1);
                yield return new WaitForSeconds(0.01f);
            }
        }
    }
}