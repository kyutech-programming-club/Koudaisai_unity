using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

//現在とってる役をimageに表示する用
//imageは4つ用意しとく
[RequireComponent(typeof(Image))]
public class KigouImage : MonoBehaviour
{
    /// <summary>
    /// 記号と画像の組み合わせを保持するリスト
    /// </summary>
    [SerializeField] List<KigoundImage> kigouAndImages = new List<KigoundImage>();
    /// <summary>
    /// KigouListの何番目の役を表示するか
    //  0番目は一番左の役を表示する
    /// </summary>
    [SerializeField] int thisNumber = 0;

    [SerializeField] Score score;
     [SerializeField] NewScore newscore;

    private Image image;
    private TextMeshProUGUI textMeshProUGUI;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        textMeshProUGUI = transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        image.sprite = null; // 画像を初期化
        if (score.KigouList.Count > thisNumber)
        {
            foreach (var y in kigouAndImages)
            {
                String text = score.KigouList[thisNumber].kigou;
                if (y.Kigou.ToString() == text)
                {
                    image.sprite = y.Sprite;
                    textMeshProUGUI.text = text.Substring(text.Length - 1);
                    break; // 一致する記号が見つかったらループを抜ける
                }
            }
        }
    }

    /// <summary>
    /// 記号と画像の組み合わせを保持するクラス
    /// </summary>
    [Serializable]
    private class KigoundImage
    {
        public Score.Kigou Kigou;
        public Sprite Sprite;
    }
}
