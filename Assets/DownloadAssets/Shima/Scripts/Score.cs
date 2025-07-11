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
    [SerializeField] private TMP_Text YakuText;
    //インスペクター上で役と得点の組み合わせを設定するためのリスト
    [SerializeField] private List<YakuandPoint> YakuandPoints;
    private int score;
    /// <summary>
    /// 役の種類
    /// </summary>
    public enum Yaku
    {
        Star,
        Round,
        Sqare
    }
    public List<Yaku> YakuList = new List<Yaku>();
    private const int Yakunum = 4;
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
    /// <param name="yaku"></param>
    public void AddYaku(Yaku yaku)
    {
        YakuList.Add(yaku);
        // 4個以上入るとリセットして1から入る
        if (YakuList.Count > Yakunum)
        {
            YakuList.Clear();
            YakuList.Add(yaku);
        }
        // 役を比較してポイントを入れる
        foreach (YakuandPoint x in YakuandPoints)
        {
            if (YakuList.Count != 0)
            {
                if (YakuList.SequenceEqual(x.yakus))
                {
                    YakuList.Clear();
                    score += x.Point;
                }
            }
        }
        List<string> _list = new List<string>();
        foreach (var item in YakuList)
            _list.Add(item.ToString());
        YakuText.text = string.Join(", ", _list);
    }
    /// <summary>
    /// 役の組み合わせとその得点のクラス
    /// </summary>
    [Serializable]
    public class YakuandPoint
    {
        public int Point;
        public List<Yaku> yakus = new List<Yaku>();
    }
}





















