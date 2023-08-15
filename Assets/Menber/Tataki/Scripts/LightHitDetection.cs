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
                        Debug.Log("��ł���");
                    }
                    else
                    {
                        MDmageApplyToGhost(ghostTagHit);
                    }
                }
            }
        }
    }

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
            //�\�����Ȃ������ɓ���������ȉ��R�[�h�����s
            Debug.Log("�\�����Ȃ��q�b�g", gameObject);
        }
    }
}