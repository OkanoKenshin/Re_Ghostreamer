using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour //streamerのダッシュ仕様
{
    Animation _animation;

    [SerializeField]
    CenterDataOfStreamer _centerDataOfStreamer;

    [SerializeField]
    private CommonParam.UnitType _unitType = CommonParam.UnitType.Streamer;

    [SerializeField]
    InputManager _inputManager;

    private InputManager.InputParam _inputParam;

    // Start is called before the first frame update
    void Start()
    {
        if (_inputManager == null)
        {
            _inputManager = GetComponent<InputManager>();//InputManagerのnullチェック
        }
        if (_centerDataOfStreamer == null)
        {
            _centerDataOfStreamer = GetComponent<CenterDataOfStreamer>();//CenterDataOfStreamerのnullチェック
        }

        if (_animation == null)
        {
            _animation = GetComponent<Animation>();//Animationのnullチェック
        }
        _inputParam = _inputManager.UnitInputParams[_unitType];

        
    }
        // Update is called once per frame
    void Update()
    {
        MDash();
        //Debug.Log(_inputParam.Dash);
    }


    public void MDash()
    {
        if (_inputParam.Dash && _centerDataOfStreamer.stStamina > 0) //入力されている&ストリーマーのスタミナがstStaminaが0より有る状態で以下を行う
        {
            _centerDataOfStreamer.stSpeed = _centerDataOfStreamer.stDashSpeed;//ストリーマーのスピードにダッシュ倍率を掛ける

            _animation.MStSprintAnima();//ダッシュのアニメーションを流す

            _centerDataOfStreamer.stStamina -= _centerDataOfStreamer.stStaminaDecrease;//スタミナをstStaminaDecrease分減少させる

            if(_centerDataOfStreamer.stStamina <= 0)//スタミナが0になった時、BaseStamina分まで回復するまでダッシュできないようにする
            {
                StartCoroutine(MWaiteStamina());

            }

        }
        else if(_inputParam.Dash == false )
        {
            _centerDataOfStreamer.stSpeed = _centerDataOfStreamer.stBaseSpeed;//スピードのをベーススピードを代入(初期化)

            if (_centerDataOfStreamer.stStamina < _centerDataOfStreamer.stBaseStamina) //スタミナがベーススタミナより少ない場合以下を行う
            {
                _centerDataOfStreamer.stStamina += _centerDataOfStreamer.stStaminaIncrease;//スタミナをスタミナstStaminaIncrease分増加させる
            }
        }
    }

    #region スタミナが0以下なった時、BaseStaminaの値になるまで、ダッシュの入力をfalseで返す
    IEnumerator MWaiteStamina()
    {
       while(_centerDataOfStreamer.stStamina < _centerDataOfStreamer.stBaseStamina)
        {
            _inputParam.Dash = false;
            _centerDataOfStreamer.stSpeed = _centerDataOfStreamer.stBaseSpeed;//スピードを初期値に戻す
            _centerDataOfStreamer.stStamina += _centerDataOfStreamer.stStaminaIncrease;//スタミナをスタミナstStaminaIncrease分増加させる
            Debug.Log("スタミナ回復中");
            yield return null;
        }
        
    }
    #endregion
}
