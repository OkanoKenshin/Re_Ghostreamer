using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHitDetection :MonoBehaviour //ゴーストの攻撃がヒットしたら処理を行うクラス
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
            _centerDataOfStreamer = AttachedCenterDataOfStreamer.GetComponent<CenterDataOfStreamer>();
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

    public void MAttackHitDetection()//攻撃がヒットしたのがストリーマーだった場合ストリーマーのHPを減らす処理
    {
        if (attackHitTheStreamer == true)//攻撃が当たった対象がストリーマーだった場合以下の処理を行う
        {
            if (heavyAttakActive)//スキルのheaveyAttackだった場合普通の攻撃よりHPを減らす量を多くする
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
