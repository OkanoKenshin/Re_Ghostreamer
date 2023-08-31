using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogAction : MonoBehaviour
{
    // アニメーションが再生中かどうかを示すフラグ
    private bool animationPlaying = false;

    // アニメーションが実行されたら関数を呼び出す
    public void FogActionFrames()
    {
        if (!animationPlaying)
        {
            // コルーチンの呼び出し　アニメーション再生中フラグを設定
            StartCoroutine(FogActionControl(235));
        }
    }

    // コルーチン開始
    IEnumerator FogActionControl(float duration)
    {
        // アニメーション再生中フラグをtrue
        animationPlaying = true;

        // アニメーションの再生待機
        yield return new WaitForSeconds(duration);

        // アニメーションが終了したら再生中フラグをfalse
        animationPlaying = false;
    }
}
