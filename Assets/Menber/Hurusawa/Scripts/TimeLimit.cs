using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class TimeLimit : MonoBehaviour
{
    public static float CountDownTime;
    public static float deltaTime; // カウントダウンタイム
    public Text TextCountDown; // 表示用テキストUI

    // Use this for initialization
    void Start()
    {
        deltaTime = 0.02f;
        CountDownTime = 300.0F; // カウントダウン開始秒数をセット
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        int minutes = Mathf.FloorToInt(CountDownTime / 60);
        int seconds = Mathf.FloorToInt(CountDownTime % 60);

        // カウントダウンタイムを整形して表示
        TextCountDown.text = String.Format("{0:00}:{1:00}", minutes, seconds);
        // 経過時刻を引いていく
        CountDownTime -= deltaTime;
        // 0.0秒以下になったらカウントダウンタイムを0.0で固定（止まったように見せる）
        if (CountDownTime <= 0.0F)
        {
            CountDownTime = 0.0F;
        }
    }
}
