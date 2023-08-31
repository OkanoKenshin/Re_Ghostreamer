using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightHitDetection : MonoBehaviour
{
    [SerializeField] GameObject AttachedCenterOfLightData;
    CenterOfLightData _centerOfLightData;

    [SerializeField]
    GameObject AttachedCenterDataOfHAGhost;
    CenterDataOfHAGhost _centerDataOfHAGhost;

    [SerializeField]
    GameObject AttachedCenterDataOfFPGhost;
    CenterDataOfFPGhost _centerDataOfFPGhost;

    [SerializeField]
    GameObject AttachedCenterDataOfFGGhost;
    CenterDataOfFGGhost _centerDataOfFGGhost;

    public string ghostTagHit;
    [SerializeField] public float lightDamage;

    #region CenterOfLightDataのNullチェック

    void Awake()
    {
        // CenterOfLightData オブジェクトの有無をチェック
        if (AttachedCenterOfLightData != null)
        {
            _centerOfLightData = AttachedCenterOfLightData.GetComponent<CenterOfLightData>();

            if (_centerOfLightData != null)
            {
                Debug.Log("「CenterOfLightData」は正常に取得されています。");
            }
            else
            {
                Debug.Log("「AttachedCenterOfLightData」はアタッチされていますが、「CenterOfLightData」の取得に失敗しています。");
            }
        }
        else
        {
            Debug.Log("「AttachedCenterOfLightData」はアタッチされていません。");
        }
    }
    #endregion

    public void MLightHitDetection()
    {
        if (_centerOfLightData.overHeat == false)
        {
            if (_centerOfLightData.lightInputOn == true)
            {
                if (ghostTagHit != null)
                {
                    MDmageApplyToGhost(ghostTagHit);
                }
            }
        }
    }

    public void MDmageApplyToGhost(string ghostTagHit)
    {
        if (ghostTagHit == "Ghost1")
        {
            _centerDataOfFGGhost.fgGhHp -= lightDamage;
        }
        else if (ghostTagHit == "Ghost2")
        {
            _centerDataOfFPGhost.fpGhHp -= lightDamage;
        }
        else if (ghostTagHit == "Ghost3")
        {
            _centerDataOfHAGhost.haGhHp -= lightDamage;
        }
        else
        {
            //予期しない何かに当たったら以下コードを実行
            Debug.Log("予期しないヒット", gameObject);
        }
    }
}