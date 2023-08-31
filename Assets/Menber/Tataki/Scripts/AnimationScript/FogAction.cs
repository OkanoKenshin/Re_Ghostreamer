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

    // �A�j���[�V�������Đ������ǂ����������t���O
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



    // �A�j���[�V���������s���ꂽ��֐����Ăяo��
    public void FogActionFrames()
    {
        if (!animationPlaying)
        {
            // �R���[�`���̌Ăяo���@�A�j���[�V�����Đ����t���O��ݒ�
            StartCoroutine(FogActionControl(235));
        }
    }

    // �R���[�`���J�n
    IEnumerator FogActionControl(float duration)
    {
        // �A�j���[�V�����Đ����t���O��true
        //animationPlaying = true;

        // �A�j���[�V�����̍Đ��ҋ@
        yield return new WaitForSeconds(duration);

        _inputParam.MoveX = 0;
        _inputParam.MoveZ = 0;

        // �A�j���[�V�������I��������Đ����t���O��false
        animationPlaying = false;
    }

    IEnumerator FogDisable()
    {
        yield return new WaitForSeconds(_timeLeft);
        Fog.SetActive(false);
    }
}
