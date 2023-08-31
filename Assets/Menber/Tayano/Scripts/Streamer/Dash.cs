using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
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
            _inputManager = GetComponent<InputManager>();
        }
        if (_centerDataOfStreamer == null)
        {
            _centerDataOfStreamer = GetComponent<CenterDataOfStreamer>();
        }

        if (_animation == null)
        {
            _animation = GetComponent<Animation>();
        }
        _inputParam = _inputManager.UnitInputParams[_unitType];

        
    }
        // Update is called once per frame
    void Update()
    {
        dash();
        //Debug.Log(_inputParam.Dash);
    }


    public void dash()
    {
        if (_inputParam.Dash && _centerDataOfStreamer.stStamina > 0) //入力されている&ストリーマーのスタミナがstStaminaが0より有る状態で以下を行う
        {
            _centerDataOfStreamer.stSpeed = _centerDataOfStreamer.stDashSpeed;//ストリーマーのスピードにダッシュ倍率を掛ける

            _animation.MStSprintAnima();//ダッシュのアニメーションを流す

            _centerDataOfStreamer.stStamina -= _centerDataOfStreamer.stStaminaDecrease;//スタミナをstStaminaDecrease分減少させる

            if(_centerDataOfStreamer.stStamina <= 0)
            {
                _inputParam.Dash = false;
                _centerDataOfStreamer.stSpeed = _centerDataOfStreamer.stBaseSpeed;
            }

        }
        else if(_inputParam.Dash == false || _centerDataOfStreamer.stStamina <= 0)
        {
            if (_centerDataOfStreamer.stStamina <= 50)
            {
                _inputParam.Dash = false;
                _centerDataOfStreamer.stSpeed = _centerDataOfStreamer.stBaseSpeed;
            }
            _centerDataOfStreamer.stSpeed = _centerDataOfStreamer.stBaseSpeed;//スピードのをベーススピードを代入(初期化)

            if (_centerDataOfStreamer.stStamina < _centerDataOfStreamer.stBaseStamina) //スタミナがベーススタミナより少ない場合以下を行う
            {
                _centerDataOfStreamer.stStamina += _centerDataOfStreamer.stStaminaIncrease;//スタミナをスタミナstStaminaIncrease分増加させる

            }
        }
    }
}
