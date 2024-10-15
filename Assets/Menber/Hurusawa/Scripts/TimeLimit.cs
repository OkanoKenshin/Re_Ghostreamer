using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeLimit : MonoBehaviour
{
    public static float CountDownTime;
    public static float deltaTime; // カウントダウンの速度
    public Text TextCountDown; // 表示用のテキストUI

    // Use this for initialization
    void Start()
    {
        deltaTime = 0.005f;
        CountDownTime = 180.0F; // カウントダウン開始時間を設定
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        int minutes = Mathf.FloorToInt(CountDownTime / 60);
        int seconds = Mathf.FloorToInt(CountDownTime % 60);

        // カウントダウンタイムを計算して表示
        TextCountDown.text = String.Format("{0:00}:{1:00}", minutes, seconds);
        // 残り時間を減らしていく
        CountDownTime -= deltaTime;
        // 0.0秒以下になったらカウントダウンタイムを0.0で固定（マイナスにならないように）
        if (CountDownTime <= 0.0F)
        {
            CountDownTime = 0.0F;
            // タイマーが0になったら勝利シーンに移行
            SceneManager.LoadScene("GhVictoryScene");
        }
    }
}
