using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightHitDetection : MonoBehaviour
{
    [SerializeField] GameObject AttachedCenterOfLightData;
    CenterOfLightData _centerOfLightData;
    public string ghostTagHit;
    [SerializeField] public float lightDamage;
    [SerializeField] public float firstGhHp;
    [SerializeField] public float secondGhHp;
    [SerializeField] public float thirdGhHp;
    private bool lightInputOn;
    [SerializeField] private float ghHp;

    public void MLightHitDetection()
    {
        if (_centerOfLightData.overHeat == false)
        {
            if (lightInputOn == true && ghostTagHit != null)
            {
                if (_centerOfLightData.lightInputOn == true)
                {
                    if (ghostTagHit != "")
                    {
                        Debug.Log("空である");
                    }
                    else
                    {
                        MDmageApplyToGhost(ghostTagHit);
                    }
                }
            }
        }
    }

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

    public void MDmageApplyToGhost(string ghostTagHit)
    {
        if (ghostTagHit == "Ghost1")
        {
            firstGhHp -= lightDamage;
        }
        else if (ghostTagHit == "Ghost2")
        {
            secondGhHp -= lightDamage;
        }
        else if (ghostTagHit == "Ghost3")
        {
            thirdGhHp -= lightDamage;
        }
        else
        {
            //予期しない何かに当たったら以下コードを実行
            Debug.Log("予期しないヒット", gameObject);
        }
    }
}