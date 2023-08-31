using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lightGauge : MonoBehaviour
{
    private float heatGauge;
    private float maxHeatGauge;

    [SerializeField]
    GameObject AttachedCenterOfLightData;
    CenterOfLightData _centerOfLightData;
    private Image _image;
    private void Awake()
    {
        #region "CenterOfLightData"��Null�`�F�b�N
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
        #endregion

    }
    private void Start()
    {
        maxHeatGauge = _centerOfLightData.maxHeatGauge;
        _image = this.GetComponent<Image>();
    }

    private void Update()
    {
        heatGauge = _centerOfLightData.heatGauge;
        _image.fillAmount = heatGauge / maxHeatGauge;
    }
}
