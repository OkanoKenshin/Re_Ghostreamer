using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHitDetection :MonoBehaviour
{
    public bool attackHitTheStreamer;

    [SerializeField]
    public float ghAttackPower;

    [SerializeField]
    private float stHp;
    public void MAttackHitDetection()
    {
        if (attackHitTheStreamer == true)
        {
            //������Debug.Log��"Streamer��HP��stHp�ł�"�ƕ\������悤�ɂ���B
            Debug.Log("Streamer��HP��stHp�ł�");
            stHp -= ghAttackPower;
        }
    }
}
