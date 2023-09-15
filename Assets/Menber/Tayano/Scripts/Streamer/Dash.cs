using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour //streamer�̃_�b�V���d�l
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
            _inputManager = GetComponent<InputManager>();//InputManager��null�`�F�b�N
        }
        if (_centerDataOfStreamer == null)
        {
            _centerDataOfStreamer = GetComponent<CenterDataOfStreamer>();//CenterDataOfStreamer��null�`�F�b�N
        }

        if (_animation == null)
        {
            _animation = GetComponent<Animation>();//Animation��null�`�F�b�N
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
        if (_inputParam.Dash && _centerDataOfStreamer.stStamina > 0) //���͂���Ă���&�X�g���[�}�[�̃X�^�~�i��stStamina��0���L���Ԃňȉ����s��
        {
            _centerDataOfStreamer.stSpeed = _centerDataOfStreamer.stDashSpeed;//�X�g���[�}�[�̃X�s�[�h�Ƀ_�b�V���{�����|����

            _animation.MStSprintAnima();//�_�b�V���̃A�j���[�V�����𗬂�

            _centerDataOfStreamer.stStamina -= _centerDataOfStreamer.stStaminaDecrease;//�X�^�~�i��stStaminaDecrease������������

            if(_centerDataOfStreamer.stStamina <= 0)//�X�^�~�i��0�ɂȂ������ABaseStamina���܂ŉ񕜂���܂Ń_�b�V���ł��Ȃ��悤�ɂ���
            {
                StartCoroutine(MWaiteStamina());

            }

        }
        else if(_inputParam.Dash == false )
        {
            _centerDataOfStreamer.stSpeed = _centerDataOfStreamer.stBaseSpeed;//�X�s�[�h�̂��x�[�X�X�s�[�h����(������)

            if (_centerDataOfStreamer.stStamina < _centerDataOfStreamer.stBaseStamina) //�X�^�~�i���x�[�X�X�^�~�i��菭�Ȃ��ꍇ�ȉ����s��
            {
                _centerDataOfStreamer.stStamina += _centerDataOfStreamer.stStaminaIncrease;//�X�^�~�i���X�^�~�istStaminaIncrease������������
            }
        }
    }

    #region �X�^�~�i��0�ȉ��Ȃ������ABaseStamina�̒l�ɂȂ�܂ŁA�_�b�V���̓��͂�false�ŕԂ�
    IEnumerator MWaiteStamina()
    {
       while(_centerDataOfStreamer.stStamina < _centerDataOfStreamer.stBaseStamina)
        {
            _inputParam.Dash = false;
            _centerDataOfStreamer.stSpeed = _centerDataOfStreamer.stBaseSpeed;//�X�s�[�h�������l�ɖ߂�
            _centerDataOfStreamer.stStamina += _centerDataOfStreamer.stStaminaIncrease;//�X�^�~�i���X�^�~�istStaminaIncrease������������
            Debug.Log("�X�^�~�i�񕜒�");
            yield return null;
        }
        
    }
    #endregion
}
