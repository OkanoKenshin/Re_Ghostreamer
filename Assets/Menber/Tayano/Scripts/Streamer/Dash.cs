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
        if (_inputParam.Dash && _centerDataOfStreamer.stStamina > 0) //���͂���Ă���&�X�g���[�}�[�̃X�^�~�i��stStamina��0���L���Ԃňȉ����s��
        {
            _centerDataOfStreamer.stSpeed = _centerDataOfStreamer.stDashSpeed;//�X�g���[�}�[�̃X�s�[�h�Ƀ_�b�V���{�����|����

            _animation.MStSprintAnima();//�_�b�V���̃A�j���[�V�����𗬂�

            _centerDataOfStreamer.stStamina -= _centerDataOfStreamer.stStaminaDecrease;//�X�^�~�i��stStaminaDecrease������������

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
            _centerDataOfStreamer.stSpeed = _centerDataOfStreamer.stBaseSpeed;//�X�s�[�h�̂��x�[�X�X�s�[�h����(������)

            if (_centerDataOfStreamer.stStamina < _centerDataOfStreamer.stBaseStamina) //�X�^�~�i���x�[�X�X�^�~�i��菭�Ȃ��ꍇ�ȉ����s��
            {
                _centerDataOfStreamer.stStamina += _centerDataOfStreamer.stStaminaIncrease;//�X�^�~�i���X�^�~�istStaminaIncrease������������

            }
        }
    }
}
