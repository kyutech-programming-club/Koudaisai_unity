using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

//ボタン押したら役が追加される　デバッグ用
//記号の種類だけボタンを作成しとく
[RequireComponent(typeof(Button))]
public class KigouButton : MonoBehaviour
{
    private Button mButton;
    private TMP_Text _Text;

    //ボタン押したらどの役が追加されるか決めれる
    [SerializeField] private Score.Kigou kigou;
    [SerializeField] private Score score;

    // Start is called before the first frame update
    void Start()
    {
        mButton = GetComponent<Button>();
        mButton.onClick.AddListener(OnClick);
        _Text = this.GetComponentInChildren<TMP_Text>();
        _Text.text = kigou.ToString();
    }

    private void OnClick()
    {
        score.AddKigou(kigou);
    }
}
