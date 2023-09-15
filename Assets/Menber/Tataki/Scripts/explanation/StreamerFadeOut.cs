using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StreamerFadeOut : MonoBehaviour
{
    public GameObject Panelfade;   // フェード用のパネルオブジェクト

    Image fadealpha;               // パネルのImageコンポーネント

    private float alpha;           // パネルのアルファ値

    private bool fadeout;          // フェードアウト中かどうかのフラグ

    public int SceneNo;            // 移動先シーンの番号

    public float delayBeforeFade = 5f; // フェード開始までの待機時間

    // 初期化
    void Start()
    {
         // パネルのImageコンポーネントを取得
        fadealpha = Panelfade.GetComponent<Image>();
        // アルファ値を初期化
        alpha = fadealpha.color.a;
        // 待機時間後にフェードを開始するコルーチンを開始
        StartCoroutine(StartFadeAfterDelay());
    }

    // 更新処理
    void Update()
    {
        if (fadeout == true)
        {
            // フェードアウト処理を実行
            FadeOut();
        }
    }

    // フェードアウト処理
    void FadeOut()
    {
        // アルファ値を少しずつ増やす
        alpha += 0.01f;
        // パネルのアルファ値を更新
        fadealpha.color = new Color(0, 0, 0, alpha);

        if (alpha >= 1)
        {
            // フェードアウト終了
            fadeout = false;
            // 指定のシーンに移動
            SceneManager.LoadScene("InGame"); 
        }
    }

    // フェードアウトを開始するための外部から呼び出すメソッド
    // フェードアウトを開始するフラグを設定
    public void StartFadeOut()
    {
        fadeout = true;
    }

    // 待機時間後にフェードを開始するコルーチン
    IEnumerator StartFadeAfterDelay()
    {
        // 待機時間
        yield return new WaitForSeconds(delayBeforeFade);
        // フェードを開始
        StartFadeOut();
    }
}

