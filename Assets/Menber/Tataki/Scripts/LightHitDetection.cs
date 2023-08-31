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

    #region CenterOfLightData��Null�`�F�b�N

    void Awake()
    {
        // CenterOfLightData �I�u�W�F�N�g�̗L�����`�F�b�N
        if (AttachedCenterOfLightData != null)
        {
            _centerOfLightData = AttachedCenterOfLightData.GetComponent<CenterOfLightData>();

            if (_centerOfLightData != null)
            {
                Debug.Log("�uCenterOfLightData�v�͐���Ɏ擾����Ă��܂��B");
            }
            else
            {
                Debug.Log("�uAttachedCenterOfLightData�v�̓A�^�b�`����Ă��܂����A�uCenterOfLightData�v�̎擾�Ɏ��s���Ă��܂��B");
            }
        }
        else
        {
            Debug.Log("�uAttachedCenterOfLightData�v�̓A�^�b�`����Ă��܂���B");
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
            //�\�����Ȃ������ɓ���������ȉ��R�[�h�����s
            Debug.Log("�\�����Ȃ��q�b�g", gameObject);
        }
    }
}