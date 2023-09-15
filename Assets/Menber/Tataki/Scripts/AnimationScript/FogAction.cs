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


    // �A�j���[�V�������Đ������ǂ����������t���O
    private bool animationPlaying = false;

    //[SerializeField]
    //private bool _isPlaying = false;

    [SerializeField]
    private Transform _transform;

    [SerializeField]
    private float _timeLeft;

    [SerializeField]
    private float _timeanima;
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
        Debug.Log("_unityMove.enabled is now: " + _unityMove.enabled);
    }

    private void MFogAction()
    {
        _unityMove = GetComponent<UnitMove>();
        //var ThisRotation = this.transform.forward;
        if (_inputParam.Ability)
        {
            //Instantiate(FogPrefab, this.transform.position, this.transform.rotation);
            Fog.SetActive(true);
            Fog.transform.position = this.transform.position;
            Quaternion quaternion = Quaternion.Euler(this.transform.forward);
            Fog.transform.localScale = _transform.localScale;
            _animation.MGhFogAnima();
            
            if (animationPlaying == true)
            {
                _unityMove.enabled = false;
            }
            FogActionFrames();
            StartCoroutine(FogDisable());
            // �A�j���[�V�����̊������m�F����f�o�b�O���O���o��
            Debug.Log("Animation is playing: " + animationPlaying);
        }
    }



    // �A�j���[�V���������s���ꂽ��֐����Ăяo��
    public void FogActionFrames()
    {
        if (animationPlaying == false)
        {
            animationPlaying = true;
            // �R���[�`���̌Ăяo���@�A�j���[�V�����Đ����t���O��ݒ�
            StartCoroutine(FogActionControl());
        }
    }

    // �R���[�`���J�n
    IEnumerator FogActionControl()
    {
        // �A�j���[�V�����Đ����t���O��true
        //animationPlaying = true;

        // �A�j���[�V�����̍Đ��ҋ@
        yield return new WaitForSeconds(_timeanima);

        _inputParam.MoveX = 0;
        _inputParam.MoveZ = 0;

        // �A�j���[�V�������I��������Đ����t���O��false
        animationPlaying = false;
        if(animationPlaying == false)
        {
            _unityMove.enabled = true;
        }
    }

    IEnumerator FogDisable()
    {
        yield return new WaitForSeconds(_timeLeft);
        Fog.SetActive(false);
    }
}
