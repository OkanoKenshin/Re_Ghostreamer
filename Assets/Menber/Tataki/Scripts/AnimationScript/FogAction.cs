using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;
//using VolumetricFogAndMist;

public class FogAction : MonoBehaviour
{
    public GameObject Fog;

    [SerializeField]
    private CommonParam.UnitType _unitType = CommonParam.UnitType.Streamer;

    [SerializeField]
    InputManager _inputManager;

    private InputManager.InputParam _inputParam;

    private Animation _animation;

    // アニメーションが再生中かどうかを示すフラグ
    private bool animationPlaying = false;

    //[SerializeField]
    //private bool _isPlaying = false;

    [SerializeField]
    private Transform _transform;

    [SerializeField]
    private float _timeLeft;

    //[SerializeField]
    //VolumetricFogAndMist.VolumetricFog VolumetricFog;


    private void Start()
    {
        if (_inputManager == null)
        {
            _inputManager = GetComponent<InputManager>();
        }
        if(_animation == null)
        {
            _animation = this.GetComponent<Animation>();
        }
        _inputParam = _inputManager.UnitInputParams[_unitType];
    }

    private void Update()
    {
        MFogAction();
    }

    private void MFogAction()
    {
        //var ThisRotation = this.transform.forward;
        if (_inputParam.Ability)
        {
            //Instantiate(FogPrefab, this.transform.position, this.transform.rotation);
            Fog.SetActive(true);
            Fog.transform.position = this.transform.position;
            Quaternion quaternion = Quaternion.Euler(this.transform.forward);
            Fog.transform.localScale = _transform.localScale;
            _animation.MGhFogAnima();
            animationPlaying = true;
            FogActionFrames();
            StartCoroutine(FogDisable());
        }
    }



    // アニメーションが実行されたら関数を呼び出す
    public void FogActionFrames()
    {
        if (!animationPlaying)
        {
            // コルーチンの呼び出し　アニメーション再生中フラグを設定
            StartCoroutine(FogActionControl(235));
        }
    }

    // コルーチン開始
    IEnumerator FogActionControl(float duration)
    {
        // アニメーション再生中フラグをtrue
        //animationPlaying = true;

        // アニメーションの再生待機
        yield return new WaitForSeconds(duration);

        _inputParam.MoveX = 0;
        _inputParam.MoveZ = 0;

        // アニメーションが終了したら再生中フラグをfalse
        animationPlaying = false;
    }

    IEnumerator FogDisable()
    {
        yield return new WaitForSeconds(_timeLeft);
        Fog.SetActive(false);
    }
}
