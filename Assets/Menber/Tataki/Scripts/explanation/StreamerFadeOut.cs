using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StreamerFadeOut : MonoBehaviour
{
    public GameObject Panelfade;   //フェードパネルの取得

    Image fadealpha;               //フェードパネルのイメージ取得変数

    private float alpha;           //パネルのalpha値取得変数

    private bool fadeout;          //フェードアウトのフラグ変数

    public int SceneNo;            //シーンの移動先ナンバー取得変数

    public float delayBeforeFade = 5f;//フェードアウト前の待機時間

    // Use this for initialization
    void Start()
    {
        fadealpha = Panelfade.GetComponent<Image>(); //パネルのイメージ取得
        alpha = fadealpha.color.a;                 //パネルのalpha値を取得
        StartCoroutine(StartFadeAfterDelay());
    }

    // Update is called once per frame
    void Update()
    {
        if (fadeout == true)
        {
            FadeOut();
        }
    }

    void FadeOut()
    {
        alpha += 0.01f;
        fadealpha.color = new Color(0, 0, 0, alpha);
        if (alpha >= 1)
        {
            fadeout = false;
            SceneManager.LoadScene("InGame");
        }
    }

    public void fadeOut()
    {
        fadeout = true;
    }

    IEnumerator StartFadeAfterDelay()
    {
        yield return new WaitForSeconds(delayBeforeFade);
        fadeOut(); // フェードアウトを開始
    }
}
