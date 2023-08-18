using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeatGaugeControl : MonoBehaviour
{
    [SerializeField] public float heatGaugeDecrease;
    [SerializeField] public float heatGaugeIncrease;
    [SerializeField] private float maxHeatGauge;
    // "CenterOfLightData"�̎Q�Ƃ̎擾
    [SerializeField]
    GameObject AttachedCenterOfLightData;
    CenterOfLightData _centerOfLightData;

    // "LightStateControl"�̎Q�Ƃ̎擾
    [SerializeField]
    GameObject AttachedLightStateControl;
    LightStateControl _lightStateControl;

    void Awake()
    {
        #region CenterOfLightData��Null�`�F�b�N
        if (AttachedCenterOfLightData != null)
        {
            _centerOfLightData = GetComponent<CenterOfLightData>();
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
        #endregion

        #region "LightStateControl"��Null�`�F�b�N
        if (AttachedLightStateControl != null)
        {
            _lightStateControl = GetComponent<LightStateControl>();
            if (_lightStateControl != null)
            {
                Debug.Log("�uLightStateControl�v�͐���Ɏ擾����Ă��܂��B");
            }
            else
            {
                Debug.Log("�uAttachedLightStateControl�v�̓A�^�b�`����Ă��܂����A�uLightStateControl�v�̎擾�Ɏ��s���Ă��܂��B");
            }
        }
        else
        {
            Debug.Log("�uAttachedLightStateControl�v�̓A�^�b�`����Ă��܂���B");
        }
        #endregion
    }
    void FixedUpdate()
    {
        if (_centerOfLightData.overHeat == false)
        {
            #region �q�[�g�Q�[�W��������
            if (_centerOfLightData.heatGauge > 0 && _centerOfLightData.lightInputOn == false)
            {
                _centerOfLightData.heatGauge -= heatGaugeDecrease;
                // �q�[�g�Q�[�W�𖈏����w�肳�ꂽ�����ʂŃf�N�������g
            }
            #endregion

            #region �q�[�g�Q�[�W��������
            if (_centerOfLightData.heatGauge != _centerOfLightData.maxHeatGauge && _centerOfLightData.lightInputOn == true)

            {
                _centerOfLightData.heatGauge += heatGaugeIncrease;
                // �q�[�g�Q�[�W�𖈏����w�肳�ꂽ�����ʂŃC���N�������g
            }
        }
        #endregion

        #region overHeat�L��������
        if (_centerOfLightData.heatGauge == _centerOfLightData.maxHeatGauge && _centerOfLightData.lightInputOn == true)
        {
            _centerOfLightData.overHeat = true;
            // overHeat��ԂɕύX
            _lightStateControl.MSub2Week();
            // Light���ʂ��I�o�q��Ԃɂ��郁�\�b�h���Ăяo��
        }
        #endregion

        else if (_centerOfLightData.overHeat == true)
        {
            if (_centerOfLightData.heatGauge == 0)
            // overHeat�̉�������
            {
                // �I�o�q��Ԃ͈�xheatGauge����ߐ؂�Ȃ��Ɖ�������Ȃ��B
                _centerOfLightData.overHeat = false;
                _lightStateControl.MBasic2Week();
            }
        }
    }
}