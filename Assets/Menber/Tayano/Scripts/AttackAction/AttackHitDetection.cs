using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHitDetection :MonoBehaviour
{
    public bool attackHitTheStreamer;

    [SerializeField]
    public float ghAttackPower;

    public bool heavyAttakActive;

    public GameObject AttachedCenterDataOfStreamer;
    CenterDataOfStreamer _centerDataOfStreamer;

    private void Awake()
    {
        #region "CenterDataOfStreamer"のNullチェック
        if (AttachedCenterDataOfStreamer != null)
        {
            _centerDataOfStreamer = GetComponent<CenterDataOfStreamer>();
            if (_centerDataOfStreamer != null)
            {
                Debug.Log("「CenterDataOfStreamer」は正常に取得されています。");
            }
            else
            {
                Debug.Log("「AttachedCenterDataOfStreamer」はアタッチされていますが、「CenterDataOfStreamer」の取得に失敗しています。");
            }
        }
        else
        {
            Debug.Log("「AttachedCenterDataOfStreamer」はアタッチされていません。");
        }
        #endregion

    }

    public void MAttackHitDetection()
    {
        if (attackHitTheStreamer == true)
        {
            if (heavyAttakActive)
            {
                float hADamage = (ghAttackPower);
                _centerDataOfStreamer.stHp -= hADamage;
                Debug.Log("StreamerのHPはstHpです");
            }
            else
            {
                _centerDataOfStreamer.stHp -= ghAttackPower;
            }
            attackHitTheStreamer = false;

        }
    }
}
