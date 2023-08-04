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
            //ここにDebug.Logで"StreamerのHPはstHpです"と表示するようにする。
            Debug.Log("StreamerのHPはstHpです");
            stHp -= ghAttackPower;
        }
    }
}
