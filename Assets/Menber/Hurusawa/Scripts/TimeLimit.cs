using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class TimeLimit : MonoBehaviour
{
    public static float CountDownTime;
    public static float deltaTime; // �J�E���g�_�E���^�C��
    public Text TextCountDown; // �\���p�e�L�X�gUI

    // Use this for initialization
    void Start()
    {
        deltaTime = 0.02f;
        CountDownTime = 300.0F; // �J�E���g�_�E���J�n�b�����Z�b�g
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        int minutes = Mathf.FloorToInt(CountDownTime / 60);
        int seconds = Mathf.FloorToInt(CountDownTime % 60);

        // �J�E���g�_�E���^�C���𐮌`���ĕ\��
        TextCountDown.text = String.Format("{0:00}:{1:00}", minutes, seconds);
        // �o�ߎ����������Ă���
        CountDownTime -= deltaTime;
        // 0.0�b�ȉ��ɂȂ�����J�E���g�_�E���^�C����0.0�ŌŒ�i�~�܂����悤�Ɍ�����j
        if (CountDownTime <= 0.0F)
        {
            CountDownTime = 0.0F;
        }
    }
}
