using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using System;

public class Score : MonoBehaviour
{
    //スコア表示用
    [SerializeField] private TMP_Text ScoreText;
    // [SerializeField] private TMP_Text YakuText;
    //インスペクター上で役と得点の組み合わせを設定するためのリスト
    [SerializeField] private List<YakuandPoint> YakuandPoints;

    private int score;
    /// <summary>
    /// 役の種類
    /// </summary>
    public enum Kigou
    {
        Star,
        Round,
        Sqare
    }
    public List<Kigou> KigouList = new List<Kigou>();
    private const int Kigounum = 4;

    // Start is called before the first frame update
    void Start()
    {
        //テスト用
        //AddYaku(Yaku.Star);
        //AddYaku(Yaku.Star);
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = score.ToString();
    }

    /// <summary>
    /// 役を現在のリストに追加し、役一覧と比較
    /// </summary>
    /// <param name="kigou"></param>
    public void AddKigou(Kigou kigou)
    {
        KigouList.Add(kigou);

        // 4個以上入るとリセットして1から入る
        if (KigouList.Count > Kigounum)
        {
            KigouList.Clear();
            KigouList.Add(kigou);
        }

        // 役を比較してポイントを入れる
        foreach (YakuandPoint x in YakuandPoints)
        {
            if (KigouList.Count != 0)
            {
                if (KigouList.SequenceEqual(x.kigous))
                {
                    KigouList.Clear();
                    score += x.Point;
                }
            }
        }

        // List<string> _list = new List<string>();
        // foreach (var item in KigouList)
        //     _list.Add(item.ToString());
        // YakuText.text = string.Join(", ", _list);
    }

    /// <summary>
    /// 役の組み合わせとその得点のクラス
    /// </summary>
    [Serializable]
    public class YakuandPoint
    {
        public int Point;
        public List<Kigou> kigous = new List<Kigou>();
    }
}
