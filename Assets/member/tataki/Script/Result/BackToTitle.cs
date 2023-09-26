using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BackToTitle : MonoBehaviour
{


    public GameObject Panelfade;   //フェードパネルの取得

    Image fadealpha;               //フェードパネルのイメージ取得変数

    private float alpha;           //パネルのalpha値取得変数

    private bool fadeout;          //フェードアウトのフラグ変数

    public int SceneNo;            //シーンの移動先ナンバー取得変数

    [SerializeField] public float _speed = 0f;

    // Use this for initialization
    void Start()
    {
        fadealpha = Panelfade.GetComponent<Image>(); //パネルのイメージ取得
        alpha = fadealpha.color.a;                 //パネルのalpha値を取得
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
        alpha += _speed;
        fadealpha.color = new Color(0, 0, 0, alpha);
        if (alpha >= 1)
        {
            fadeout = false;
            SceneManager.LoadScene("testStart");
        }
    }

    public void fadeOut()
    {
        fadeout = true;
    }
}
