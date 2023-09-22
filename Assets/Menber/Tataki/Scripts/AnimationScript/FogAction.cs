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

    public MonoBehaviour _unityMove;

    public MonoBehaviour _fogAction;


    // アニメーションが再生中かどうかを示すフラグ
    private bool animationPlaying = false;

    //[SerializeField]
    private bool _isPlaying = false;

    [SerializeField]
    private Transform _transform;

    [SerializeField]
    private float _timeLeft;

    [SerializeField]
    private float _staytime;

    [SerializeField]
    private float _timeanima;

    private bool _stayjudgement;

    [SerializeField]
    VolumetricFogAndMist.VolumetricFog VolumetricFog;


    private void Start()
    {
        _stayjudgement = false;
        if (_inputManager == null)
        {
            _inputManager = GetComponent<InputManager>();
        }
        if (_animation == null)
        {
            _animation = this.GetComponent<Animation>();
        }
        _inputParam = _inputManager.UnitInputParams[_unitType];

        StartCoroutine(FogStay());
    }

    private void Update()
    {
        MFogAction();
        Debug.Log("_unityMove.enabled is now: " + _unityMove.enabled);
    }

    private void MFogAction()
    {
        _unityMove = GetComponent<UnitMove>();
        _fogAction = GetComponent<FogAction>();
        //var ThisRotation = this.transform.forward;

            if (_inputParam.Select)
            {
            if (_stayjudgement)
            {
                _stayjudgement = false;
                FogActionFrames();
                StartCoroutine(FogDisable());
                Debug.Log("Condition is true.");
                //Instantiate(FogPrefab, this.transform.position, this.transform.rotation);
                Fog.SetActive(true);
                Fog.transform.position = this.transform.position;
                Quaternion quaternion = Quaternion.Euler(this.transform.forward);
                Fog.transform.localScale = _transform.localScale;
                _animation.MGhFogAnima();

                if (animationPlaying == true)
                {
                    _unityMove.enabled = false;
                    _fogAction.enabled = false;
                }
                FogActionFrames();
                StartCoroutine(FogDisable());
                // アニメーションの完了を確認するデバッグログを出力
                Debug.Log("Animation is playing: " + animationPlaying);

            }
        }
    }

    // アニメーションが実行されたら関数を呼び出す
    public void FogActionFrames()
    {
        if (animationPlaying == false)
        {
            animationPlaying = true;
            // コルーチンの呼び出し　アニメーション再生中フラグを設定
            StartCoroutine(FogActionControl());
        }
    }

    // コルーチン開始
    IEnumerator FogActionControl()
    {
        // アニメーション再生中フラグをtrue
        animationPlaying = true;

        // アニメーションの再生待機
        yield return new WaitForSeconds(_timeanima);

        _inputParam.MoveX = 0;
        _inputParam.MoveZ = 0;

        // アニメーションが終了したら再生中フラグをfalse
        animationPlaying = false;
        if (animationPlaying == false)
        {
            _unityMove.enabled = true;
        }
    }

    IEnumerator FogDisable()
    {
        yield return new WaitForSeconds(_timeLeft);
        Fog.SetActive(false);
    }

    //スキル発動中は移動不可・スキルを使ったらその後は使えない
    IEnumerator FogStay()
    {
        yield return new WaitForSeconds(_staytime);
        Debug.Log("スキルは使えません");
        Fog.SetActive(false);
        _stayjudgement = true;
    }
}