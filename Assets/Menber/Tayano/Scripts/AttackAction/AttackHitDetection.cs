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
            //Ç±Ç±Ç…Debug.LogÇ≈"StreamerÇÃHPÇÕstHpÇ≈Ç∑"Ç∆ï\é¶Ç∑ÇÈÇÊÇ§Ç…Ç∑ÇÈÅB
            Debug.Log("StreamerÇÃHPÇÕstHpÇ≈Ç∑");
            stHp -= ghAttackPower;
        }
    }
}
