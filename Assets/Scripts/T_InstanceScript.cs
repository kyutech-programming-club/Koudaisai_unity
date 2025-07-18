
using UnityEngine;
using UnityEngine.UIElements;

public class T_InstanceScript : MonoBehaviour
{
      private float _repeatSpan;    //繰り返す間隔
    private float _timeElapsed;   //経過時間
 


    public GameObject Instance;
    private void Start()
    {
        _repeatSpan = 1;    //実行間隔を５に設定
        _timeElapsed = 0;   //経過時間をリセット
       
    }

    private void Update()
    {
        _timeElapsed += Time.deltaTime;     //時間をカウントする

        //経過時間が繰り返す間隔を経過したら
        if (_timeElapsed >= _repeatSpan)
        {
          Instantiate(Instance);   //ここで処理を実行
           
            _timeElapsed = 0;   //経過時間をリセットする
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    }