using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogAction : MonoBehaviour
{
    //アニメーションが実行されあたら関数を呼び出す
    public void FogActionFrames()
    {
        //コルーチンを呼び出す235秒間
        StartCoroutine(FogActioncontrol(235));
    }
    //コルーチン開始
    IEnumerator FogActioncontrol()
    {

    }
}

//コルーチン使っても他のプログラム実行されるくね？