using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterDataOfStreamer : MonoBehaviour //ストリーマーに関わる変数のデータを管理するクラス
{
    [SerializeField]
    public float stHp;

    [SerializeField]
    public float stBaseSpeed = 5.0f; //ストリーマースピードのベース量

    public float stSpeed;//ストリーマーのスピード

    [SerializeField]
    public float stDashSpeed = 1.5f; //ストリーマーのダッシュ倍率

    [SerializeField]
    public float stBaseStamina;//ストリーマースタミナのベース量

    public float stStamina;//ストリーマーのスタミナ

    [SerializeField]
    public float stStaminaDecrease;//ストリーマーのスタミナの減少量

    [SerializeField]
    public float stStaminaIncrease;//ストリーマーのスタミナ増加量


}
