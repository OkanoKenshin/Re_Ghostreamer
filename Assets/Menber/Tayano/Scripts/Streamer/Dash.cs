using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    Animation _animation;

    [SerializeField]
    CenterDataOfStreamer _centerDataOfStreamer;

    [SerializeField]
    private bool InputOn = false; //テスト用の入力代替変数


    // Start is called before the first frame update
    void Start()
    {
        if (_centerDataOfStreamer == null)
        {
            _centerDataOfStreamer = GetComponent<CenterDataOfStreamer>();
        }

        if (_animation == null)
        {
            _animation = GetComponent<Animation>();
        }
    }
        // Update is called once per frame
    void Update()
    {
        dash();
    }


    public void dash()
    {
        if (InputOn && _centerDataOfStreamer.stStamina > 0) //入力されている&ストリーマーのスタミナがstStaminaが0より有る状態で以下を行う
        {
            _centerDataOfStreamer.stSpeed *= _centerDataOfStreamer.stDashSpeed;//ストリーマーのスピードにダッシュ倍率を掛ける

            _animation.MStSprintAnima();//ダッシュのアニメーションを流す

            _centerDataOfStreamer.stStamina -= _centerDataOfStreamer.stStaminaDecrease;//スタミナをstStaminaDecrease分減少させる
        }
        else if(InputOn == false)
        {
            _centerDataOfStreamer.stSpeed = _centerDataOfStreamer.stBaseSpeed;//スピードのをベーススピードを代入(初期化)

            if (_centerDataOfStreamer.stStamina < _centerDataOfStreamer.stBaseStamina) //スタミナがベーススタミナより少ない場合以下を行う
            {
                _centerDataOfStreamer.stStamina += _centerDataOfStreamer.stStaminaIncrease;//スタミナをスタミナstStaminaIncrease分増加させる

            }
        }
    }
}
