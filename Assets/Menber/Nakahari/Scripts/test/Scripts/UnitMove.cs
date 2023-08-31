using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMove : MonoBehaviour
{
    [SerializeField]
    private CommonParam.UnitType _unitType = CommonParam.UnitType.Streamer;

    [SerializeField]
    CenterDataOfStreamer _centerDataOfStreamer;

    [SerializeField]
    InputManager _inputManager;

    public GameObject Cam;

    bool cursorLock = true;

    private InputManager.InputParam _inputParam;

    private Animation _animation;

    float Speed;

    // Start is called before the first frame update
    void Start()
    {
        _centerDataOfStreamer.stSpeed = _centerDataOfStreamer.stBaseSpeed;//stSpeed�̏�����
        _centerDataOfStreamer.stStamina = _centerDataOfStreamer.stBaseStamina;//stStamina�̏�����
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
        UpdateCursorLock();
        //Dash��dash()���ĂԂ悤�ɕύX���肢���܂�.

        //Debug.Log(_inputParam.Ability);
        //Debug.Log(_inputParam.Attack);
        //Debug.Log(_inputParam.Select);
        //Debug.Log(_inputParam.Dash);
    }

    //�J�����̌����𐳖ʂɂ��ē���
    private void FixedUpdate()
    {
        Speed = _unitType == CommonParam.UnitType.Streamer ? _centerDataOfStreamer.stSpeed : _centerDataOfStreamer.stBaseSpeed;

        Vector3 camForward = Cam.transform.forward;
        camForward.y = 0;
        transform.position += (camForward * _inputParam.MoveZ + Cam.transform.right * _inputParam.MoveX) * Speed;
        _animation.MMoveAnima();
    }

    //�}�E�X�J�[�\�����Q�[���������Aesc�L�[���������Ń��b�N������
    public void UpdateCursorLock()
    {
        if (_inputParam.CursorLock)
        {
            cursorLock = false;
        }
        else if (Input.GetMouseButton(0))
        {
            cursorLock = true;

        }
        if (cursorLock)
        {
            Cursor.lockState = CursorLockMode.Locked;

        }
        else if (!cursorLock)
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}



