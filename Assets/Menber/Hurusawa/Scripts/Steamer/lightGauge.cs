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
        #region "CenterOfLightData"のNullチェック
        if (AttachedCenterOfLightData != null)
        {
            _centerOfLightData = AttachedCenterOfLightData.GetComponent<CenterOfLightData>();
            if (_centerOfLightData != null)
            {
                Debug.Log("CenterOfLightDataは正常に取得されました。");
            }
            else
            {
                Debug.Log("AttachedCenterOfLightDataはアタッチされていますが、CenterOfLightDataの取得に失敗しました。");
            }
        }
        else
        {
            Debug.Log("AttachedCenterOfLightDataはアタッチされていません。");
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
