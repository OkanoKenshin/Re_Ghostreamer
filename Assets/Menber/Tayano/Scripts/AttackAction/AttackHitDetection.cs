using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHitDetection :MonoBehaviour
{
    public bool attackHitTheStreamer;

    [SerializeField]
    public float ghAttackPower;

    public GameObject _streamerhp;
    private Streamerhp streamerhp;

    private void Start()
    {
            streamerhp = _streamerhp.GetComponent<Streamerhp>();
    }

    public void MAttackHitDetection()
    {
        if (attackHitTheStreamer == true)
        {
            //Ç±Ç±Ç…Debug.LogÇ≈"StreamerÇÃHPÇÕstHpÇ≈Ç∑"Ç∆ï\é¶Ç∑ÇÈÇÊÇ§Ç…Ç∑ÇÈÅB
            Debug.Log("StreamerÇÃHPÇÕstHpÇ≈Ç∑");
            streamerhp.SThp -= ghAttackPower;
        }
    }
}
