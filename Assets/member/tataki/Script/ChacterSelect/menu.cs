using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class menu : MonoBehaviour
{
    //各ボタンの情報を他のスクリプトから共有
     private Button _streamer;
     private Button _ghost1;
     private Button _ghost2;
     private Button _ghost3;

    private void Start()
    {
        //ボタンのコンポーネントの取得
        _streamer = GameObject.Find("/Canvas/Streamer").GetComponent<Button>();
        _ghost1 = GameObject.Find("/Canvas/Ghost1").GetComponent<Button> ();
        _ghost2 = GameObject.Find("Canvas/Ghost2").GetComponent<Button>();
        _ghost3 = GameObject.Find("Canvas/Ghost3").GetComponent<Button>();
        
        //最初に選択状態にしたいボタンの設定
        _streamer.Select();
    }
}
