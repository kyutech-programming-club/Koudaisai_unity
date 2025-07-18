using System;
using System.Collections;
using System.Collections.Generic;
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

    private Image image;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        image.sprite = null; // 画像を初期化
        if (score.KigouList.Count > thisNumber)
        {
            foreach (var y in kigouAndImages)
            {
                if (y.Kigou == score.KigouList[thisNumber])
                {
                    image.sprite = y.Sprite;
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
