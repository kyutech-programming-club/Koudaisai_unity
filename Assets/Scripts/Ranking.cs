using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;

public class Ranking : MonoBehaviour
{
    private Dictionary<string, int> scores;
    private char nextPlayerChar = 'D';
    [Header("UI設定")]
    public GameObject rankingEntryPrefab;
    public Transform rankingContainer;
    // Start is called before the first frame update
    void Start()
    {

        // Dictionary<int, string> dic = new Dictionary<int, string>()
        // {
        //     {150,"Apple"},
        //     {100,"Orange"},
        //     {250,"Peach"},
        // };

        // foreach (int key in dic.Keys.OrderByDescending(x => x))
        // {
        //     Debug.Log(dic[key]);
        // }

        scores = new Dictionary<string, int>()
        {
            {"Alice", 50},
            {"Bob", 70},
            {"Charlie", 60}
        };

        // Valueで昇順にソート
        // var sorted = scores.OrderBy(pair => pair.Value);
        // foreach (var kvp in sorted)
        // {
        // Debug.Log($"{kvp.Key} : {kvp.Value}");
        // }

        // Debug.Log("---ゲーム開始時のランキング---");
        UpdateAndDisplayRanking();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            // 1.プレイヤー名とランダムなスコアを生成
            string newPlayerName = "Player" + nextPlayerChar;
            int randomScore = Random.Range(1, 201);

            // 2.生成したプレイヤーの情報を辞書に追加
            scores.Add(newPlayerName, randomScore);

            // ランキングに追加された人のハイライト
            Debug.Log($"<color=yellow>{newPlayerName} (スコア: {randomScore})がランキングに参加しました！</color>");

            // 3.プレイヤーの文字を一つ進める
            nextPlayerChar++;

            // 4.更新されたランキングを表示
            UpdateAndDisplayRanking();
        }

    }

    void UpdateAndDisplayRanking()
    {
        // 1.古いランキング表示を一旦全て削除する
        foreach (Transform child in rankingContainer)
        {
            Destroy(child.gameObject);
        }
        // Debug.Log("---最新のランキング---");
            // スコアの高い順に並び替え
            var sortedScores = scores.OrderByDescending(pair => pair.Value);

        // 順位を数える変数
        int rank = 1;
        foreach (var scoreData in sortedScores)
        {
            // 順位、名前、スコアを表示
            // Debug.Log($"第{rank}位: {scoreData.Key} (スコア: {scoreData.Value})");
            // rank++;

            // プレハブをインスタンス化
            GameObject entryGO = Instantiate(rankingEntryPrefab, rankingContainer);

            // 生成したオブジェクトのテキストを取得
            TextMeshProUGUI entryText = entryGO.GetComponent<TextMeshProUGUI>();

            // テキストを書き換える
            entryText.text = $"{rank}: {scoreData.Key} (Score:{scoreData.Value})";

            rank++;
        }
    }
}