using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LightStateControl : MonoBehaviour
{
    [SerializeField] private float base2LowTransitionTime;
    public Light lightSource;
    public Light laserLightSource;
    [SerializeField] private float lowLightAngle;
    [SerializeField] private float lowLightRange;
    [SerializeField] private float lowLightIntensity;
    [SerializeField] private float baseLightAngle;
    [SerializeField] private float baseLightIntensity;
    [SerializeField] private float baseLightRange;
    [SerializeField] private float subLightAngle;
    [SerializeField] private float subLightIntensity;
    [SerializeField] private float subLightRange;
    [SerializeField] private float laserLightAngle;
    [SerializeField] private float laserLightIntensity;
    [SerializeField] private float laserLightRange;
    [SerializeField] private float whenOffLaserLightAngle;
    [SerializeField] private float whenOffLaserLightIntensity;
    [SerializeField] private float whenOffLaserLightRange;
    public float laserAngle;
    public float laserIntensity;
    public float laserRange;
    public float lightAngle;
    public float lightIntensity;
    public float lightRange;

    public bool heatStart = false;

    // CenterOfLightData の参照取得
    [SerializeField]
    GameObject AttachedCenterOfLightData;
    CenterOfLightData _centerOfLightData;

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

        #region "lightSource"のNullチェック
        if (lightSource != null)
        {
            Debug.Log("「lightSource」は正常にアタッチされています。");
        }
        else
        {
            Debug.Log("「lightSource」がアタッチされていません。");
        }
        #endregion

        #region "laserLightSource"のNullチェック
        if (laserLightSource != null)
        {
            laserLightSource.enabled = false;
            Debug.Log("「laserLightSource」は正常にアタッチされています。Laserの初期化が行われました。");
        }
        else
        {
            Debug.Log("「laserLightSource」がアタッチされていません。");
        }
        #endregion
    }

    public IEnumerator MLightSettingTransition
    (
        
        float angleToChange, float angleBeforeChange, float angleAfterChange,
        float intensityToChange, float intensityBeforeChange, float intensityAfterChange,
        float rangeToChange, float rangeBeforeChange, float rangeAfterChange,
        float transitionTime
    )

    {
            float startPointOfLightSettingTransition = Time.time;
            // このCoroutineがスタートしたゲーム内経過時間のタイムスタンプ
            // Time.timeはゲームがスタートからの経過時間のプロパティ

            while (Time.time - startPointOfLightSettingTransition < transitionTime)
            {
                float interpolationFactor = ((Time.time - startPointOfLightSettingTransition) / transitionTime);

                angleToChange = Mathf.Lerp(angleBeforeChange, angleAfterChange, interpolationFactor);
                intensityToChange = Mathf.Lerp(intensityBeforeChange, intensityAfterChange, interpolationFactor);
                rangeToChange = Mathf.Lerp(rangeBeforeChange, rangeAfterChange, interpolationFactor);
                yield return null;
            }

            angleToChange = angleAfterChange;
            intensityToChange = intensityAfterChange;
            rangeToChange = rangeAfterChange;
    }

    #region オバヒ発生時に走るライト弱化メソッド
    public void MSub2Week()
    {
        StartCoroutine(MLightSettingTransition
        (
          lightAngle, subLightAngle, lowLightAngle,
          lightIntensity, subLightIntensity, lowLightIntensity,
          lightRange, subLightRange, lowLightRange,
          base2LowTransitionTime
        ));
    }
    #endregion

    #region オバヒからの回復時に走るライト弱化解除メソッド
    public void MBasic2Week()
    {
        StartCoroutine(MLightSettingTransition
        (
          lightAngle, lowLightAngle, baseLightAngle,
          lightIntensity, lowLightIntensity, baseLightIntensity,
          lightRange, lowLightRange, baseLightRange,
          base2LowTransitionTime
        ));
    }
    #endregion

    #region Laserモード使用時の設定変更メソッド
    public void MBasic2Sub()
    {
        StartCoroutine(MLightSettingTransition
        (
          lightAngle, baseLightAngle, subLightAngle,
          lightIntensity, baseLightIntensity, subLightIntensity,
          lightRange, baseLightRange, subLightRange,
          base2LowTransitionTime
        ));
        _centerOfLightData.valueOfLaserLightRange = lightSource.range;
    }
    #endregion

    #region Laserモードから通常モードへの復帰メソッド
    public void MSub2Basic()
    {

        StartCoroutine(MLightSettingTransition
        (
          lightAngle, subLightAngle, baseLightAngle,
          lightIntensity, subLightIntensity, baseLightIntensity,
          lightRange, subLightRange, baseLightRange,
          base2LowTransitionTime
        )
        );
    }
    #endregion

    #region Laser用ライトの有効化＆ライトをフェードインさせるように起動
    public void MLaserDisabeled2Active()
    {
        laserLightSource.enabled = true;
        StartCoroutine(MLightSettingTransition
        (
          laserAngle, whenOffLaserLightAngle, laserLightAngle,
          laserIntensity, whenOffLaserLightIntensity, laserLightIntensity,
          laserRange, whenOffLaserLightRange, laserLightRange,
          base2LowTransitionTime
        )
        );
    }
    #endregion

    #region ライトをフェードアウトさせるように停止＆Laser用ライトの無効化
    public void MLaserActive2Disabeled()
    {
        StartCoroutine(MLightSettingTransition
        (
          laserAngle, laserLightAngle, whenOffLaserLightAngle,
          laserIntensity, laserLightIntensity, whenOffLaserLightIntensity,
          laserRange, laserLightRange, whenOffLaserLightRange,
          base2LowTransitionTime
        )
        );
        laserLightSource.enabled = false;
    }
    #endregion
}
