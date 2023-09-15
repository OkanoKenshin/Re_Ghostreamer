using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StreamerFadeIn : MonoBehaviour
{
    public GameObject Panelfade;   // フェードパネルの取得

    Image fadealpha;               // フェードパネルのイメージ取得変数

    private float alpha = 1f;      // パネルの初期alpha値を1に設定

    private bool fadein = true;    // フェードインのフラグ変数

    public int SceneNo;            // シーンの移動先ナンバー取得変数

    public float fadeSpeed = 0.01f; // フェードインの速度

    // Use this for initialization
    void Start()
    {
        fadealpha = Panelfade.GetComponent<Image>(); // パネルのイメージ取得

        // 初期状態を完全に不透明に設定
        fadealpha.color = new Color(0, 0, 0, alpha);
    }

    // Update is called once per frame
    void Update()
    {
        if (fadein)
        {
            FadeIn();
        }
    }

    void FadeIn()
    {
        alpha -= fadeSpeed; // 透明度を減少させてフェードイン
        fadealpha.color = new Color(0, 0, 0, alpha);

        if (alpha <= 0)
        {
            fadein = false;
        }
    }
}
