using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using System;
using System.IO.Compression;
using UnityEngine.UI;
using Unity.VisualScripting;

public class Score : MonoBehaviour
{
    //スコア表示用
    [SerializeField] private TMP_Text ScoreText;
    // [SerializeField] private TMP_Text YakuText;
    //インスペクター上で役と得点の組み合わせを設定するためのリスト
    // [SerializeField] private List<YakuandPoint> YakuandPoints;
    [SerializeField] private List<GameObject> CanonObj;
    [SerializeField] private List<GameObject> RocketObj;
    [SerializeField] private List<GameObject> BladeObj;
    public GameObject FrontObj;
    private ItemEvent itemEvent;
    public GameObject CanonPoj1;
    public GameObject CanonPoj2;
    public GameObject LazerPoj;
    public GameObject player;
    public GameObject Lazer;
    public GameObject Body;
    public GameObject BodyArmer;



    private int score;
    /// <summary>
    /// 役の種類
    /// </summary>
    public enum Kigou
    {
        Star,
        Round,
        Sqare,
        OneLv1,
        TwoLv1,
        ThreeLv1,
        FourLv1,
        FiveLv1,
        Item1,
        Item2,
        Item3,
        Item4,
        Item5

    }
    public List<KList> KigouList = new List<KList>();
    private const int Kigounum = 4;
    // Start is called before the first frame update
    void Start()
    {
        //テスト用
        //AddYaku(Yaku.Star);
        //AddYaku(Yaku.Star);
        itemEvent = GameObject.FindWithTag("ItemEventer").GetComponent<ItemEvent>();
        player = GameObject.FindWithTag("Player");
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
        string text = kigou.ToString();
        string lastChar = text.Substring(text.Length - 1); // 最後の1文字を取得
        int lv  = int.Parse(lastChar);
        Debug.Log(text);
        GameObject targetObj = null;
        // 4個以上入るとリセットして1から入る
        if (KigouList.Count != 0)
        {
            String k_text = KigouList[KigouList.Count - 1].kigou;
            if (k_text.Substring(0, 3) == text.Substring(0, 3))
            {
                lv = KigouList[KigouList.Count - 1].lv + lv;
                Debug.Log(lv);
                DeleteGameObj(k_text);
                KigouList.RemoveAt(KigouList.Count - 1);
                text = k_text.Substring(0, 3) + lv.ToString();
            }
        }
            KList klist = new KList();
            klist.kigou = text;
            klist.lv = lv;
            KigouList.Add(klist);
        if (text.Substring(0, 3) == "One")
            {
            // if (lv > 5)
            // {
            //     lv = 5;   
            //     }
                targetObj = CanonObj[0];
                GameObject weapon = Instantiate(targetObj, CanonPoj1.transform);
                // weapon.GetComponent<CanonScript>().lv = lv;
                weapon.transform.parent = CanonPoj1.transform;
                weapon.transform.localPosition = Vector3.zero;
                weapon.name = text;
            }
        if (text.Substring(0, 3) == "Fou")
        {
            if (lv > 3)
            {
                lv = 3;
            }
            targetObj = BladeObj[lv - 1];
            GameObject weapon = Instantiate(targetObj, FrontObj.transform);
            weapon.transform.parent = FrontObj.transform;
            weapon.transform.localPosition = Vector3.zero;
            weapon.name = text;
        }
        if (text.Substring(0, 3) == "Two")
        {
            if (lv > 3)
            {
                lv = 3;
            }
            targetObj = RocketObj[lv - 1];
            GameObject weapon = Instantiate(targetObj, CanonPoj2.transform);
            weapon.GetComponent<CanonScript>().lv = lv;
            weapon.transform.parent = CanonPoj2.transform;
            weapon.transform.localPosition = Vector3.zero;
            weapon.name = text;
        }

    }

    /// <summary>
    /// 役の組み合わせとその得点のクラス
    /// </summary>
    [Serializable]
    public class YakuandPoint
    {
        public String content;
        public Kigou targetKugou;
        public List<Kigou> kigous = new List<Kigou>();
    }
    public void DeleteGameObj(string text)
    {
        Debug.Log("Delete");
        Debug.Log(text.Substring(0, 3));
        if (text.Substring(0, 3) == "One")
        {
            Destroy(CanonPoj1.transform.GetChild(0).gameObject);
        }
        if (text.Substring(0, 3) == "Two")
        {
            Destroy(CanonPoj2.transform.GetChild(0).gameObject);
        }
        if (text.Substring(0, 3) == "Thr")
        {
            Destroy(LazerPoj.transform.GetChild(0).gameObject);
        }
    }
}

public class KList
{
    public int lv;
    public String kigou;
}