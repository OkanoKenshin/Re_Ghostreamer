using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeatGaugeControl : MonoBehaviour
{
    [SerializeField] public float heatGaugeDecrease;
    [SerializeField] public float heatGaugeIncrease;
    [SerializeField] private float maxHeatGauge;
    // "CenterOfLightData"の参照の取得
    [SerializeField]
    GameObject AttachedCenterOfLightData;
    CenterOfLightData _centerOfLightData;

    // "LightStateControl"の参照の取得
    [SerializeField]
    GameObject AttachedLightStateControl;
    LightStateControl _lightStateControl;

    public bool _Mouseclick = true;

    void Awake()
    {
        #region CenterOfLightDataのNullチェック
        if (AttachedCenterOfLightData != null)
        {
            _centerOfLightData = GetComponent<CenterOfLightData>();
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
        #endregion

        #region "LightStateControl"のNullチェック
        if (AttachedLightStateControl != null)
        {
            _lightStateControl = GetComponent<LightStateControl>();
            if (_lightStateControl != null)
            {
                Debug.Log("「LightStateControl」は正常に取得されています。");
            }
            else
            {
                Debug.Log("「AttachedLightStateControl」はアタッチされていますが、「LightStateControl」の取得に失敗しています。");
            }
        }
        else
        {
            Debug.Log("「AttachedLightStateControl」はアタッチされていません。");
        }
        #endregion
    }
    void FixedUpdate()
    {

        #region ヒートゲージ減少処理
        if (_centerOfLightData.heatGauge > 0 && _centerOfLightData.lightInputOn == false)
        {
            if(_centerOfLightData.overHeat == true)
            {
                _centerOfLightData.heatGauge -= heatGaugeDecrease / 2;
            }
            else
            {
                _centerOfLightData.heatGauge -= heatGaugeDecrease;
                if(_Mouseclick == true)
                {
                    _lightStateControl.MSub2Basic();
                    _lightStateControl.MLaserActive2Disabeled();
                }
            }
            // ヒートゲージを毎処理指定された減少量でデクリメント
        }
        #endregion
        if (_centerOfLightData.overHeat == false)
        {
            #region ヒートゲージ増加処理
            if (_centerOfLightData.heatGauge != _centerOfLightData.maxHeatGauge && _centerOfLightData.lightInputOn == true)

            {
                _centerOfLightData.heatGauge += heatGaugeIncrease;
                if(_Mouseclick == true)
                {
                    _lightStateControl.MBasic2Sub();
                    _lightStateControl.MLaserDisabeled2Active();
                }
                // ヒートゲージを毎処理指定された減少量でインクリメント
            }
        }
        #endregion

        #region overHeat有効化処理
        if (_centerOfLightData.heatGauge == _centerOfLightData.maxHeatGauge && _centerOfLightData.lightInputOn == true)
        {
            _centerOfLightData.overHeat = true;
            // overHeat状態に変更
            _lightStateControl.MSub2Week();
            // Light光量をオバヒ状態にするメソッドを呼び出し
        }
        #endregion

        else if (_centerOfLightData.overHeat == true)
        {
            if (_centerOfLightData.heatGauge == 0)
            // overHeatの解除処理
            {
                // オバヒ状態は一度heatGaugeが冷め切らないと解除されない。
                _centerOfLightData.overHeat = false;
                _lightStateControl.MWeek2Basic();
            }
        }
    }
}
