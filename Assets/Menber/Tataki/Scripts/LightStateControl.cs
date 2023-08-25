using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LightStateControl : MonoBehaviour
{
    [SerializeField] private float base2LowTransitionTime;
    public Light lightSource;
    public Light laserLightSource;
    [SerializeField] private float lowLightAngle;
    [SerializeField] private float lowLightRange;
    [SerializeField] private float lowLightIntensity;
    [SerializeField] private float baseLightAngle;
    [SerializeField] private float baseLightIntensity;
    [SerializeField] private float baseLightRange;
    [SerializeField] private float subLightAngle;
    [SerializeField] private float subLightIntensity;
    [SerializeField] private float subLightRange;
    [SerializeField] private float laserLightAngle;
    [SerializeField] private float laserLightIntensity;
    [SerializeField] private float laserLightRange;
    [SerializeField] private float whenOffLaserLightAngle;
    [SerializeField] private float whenOffLaserLightIntensity;
    [SerializeField] private float whenOffLaserLightRange;
    public float laserAngle;
    public float laserIntensity;
    public float laserRange;
    public float lightAngle;
    public float lightIntensity;
    public float lightRange;

    public bool heatStart = false;

    // CenterOfLightData �̎Q�Ǝ擾
    [SerializeField]
    GameObject AttachedCenterOfLightData;
    CenterOfLightData _centerOfLightData;

    void Awake()
    {
        #region CenterOfLightData��Null�`�F�b�N
        if (AttachedCenterOfLightData != null)
        {
            _centerOfLightData = GetComponent<CenterOfLightData>();
            if (_centerOfLightData != null)
            {
                Debug.Log("�uCenterOfLightData�v�͐���Ɏ擾����Ă��܂��B");
            }
            else
            {
                Debug.Log("�uAttachedCenterOfLightData�v�̓A�^�b�`����Ă��܂����A�uCenterOfLightData�v�̎擾�Ɏ��s���Ă��܂��B");
            }
        }
        else
        {
            Debug.Log("�uAttachedCenterOfLightData�v�̓A�^�b�`����Ă��܂���B");
        }
        #endregion

        #region "lightSource"��Null�`�F�b�N
        if (lightSource != null)
        {
            Debug.Log("�ulightSource�v�͐���ɃA�^�b�`����Ă��܂��B");
        }
        else
        {
            Debug.Log("�ulightSource�v���A�^�b�`����Ă��܂���B");
        }
        #endregion

        #region "laserLightSource"��Null�`�F�b�N
        if (laserLightSource != null)
        {
            laserLightSource.enabled = false;
            Debug.Log("�ulaserLightSource�v�͐���ɃA�^�b�`����Ă��܂��BLaser�̏��������s���܂����B");
        }
        else
        {
            Debug.Log("�ulaserLightSource�v���A�^�b�`����Ă��܂���B");
        }
        #endregion
    }

    public IEnumerator MLightSettingTransition
    (
        
        float angleToChange, float angleBeforeChange, float angleAfterChange,
        float intensityToChange, float intensityBeforeChange, float intensityAfterChange,
        float rangeToChange, float rangeBeforeChange, float rangeAfterChange,
        float transitionTime
    )

    {
            float startPointOfLightSettingTransition = Time.time;
            // ����Coroutine���X�^�[�g�����Q�[�����o�ߎ��Ԃ̃^�C���X�^���v
            // Time.time�̓Q�[�����X�^�[�g����̌o�ߎ��Ԃ̃v���p�e�B

            while (Time.time - startPointOfLightSettingTransition < transitionTime)
            {
                float interpolationFactor = ((Time.time - startPointOfLightSettingTransition) / transitionTime);

                angleToChange = Mathf.Lerp(angleBeforeChange, angleAfterChange, interpolationFactor);
                intensityToChange = Mathf.Lerp(intensityBeforeChange, intensityAfterChange, interpolationFactor);
                rangeToChange = Mathf.Lerp(rangeBeforeChange, rangeAfterChange, interpolationFactor);
                yield return null;
            }

            angleToChange = angleAfterChange;
            intensityToChange = intensityAfterChange;
            rangeToChange = rangeAfterChange;
    }

    #region �I�o�q�������ɑ��郉�C�g�㉻���\�b�h
    public void MSub2Week()
    {
        StartCoroutine(MLightSettingTransition
        (
          lightAngle, subLightAngle, lowLightAngle,
          lightIntensity, subLightIntensity, lowLightIntensity,
          lightRange, subLightRange, lowLightRange,
          base2LowTransitionTime
        ));
    }
    #endregion

    #region �I�o�q����̉񕜎��ɑ��郉�C�g�㉻�������\�b�h
    public void MBasic2Week()
    {
        StartCoroutine(MLightSettingTransition
        (
          lightAngle, lowLightAngle, baseLightAngle,
          lightIntensity, lowLightIntensity, baseLightIntensity,
          lightRange, lowLightRange, baseLightRange,
          base2LowTransitionTime
        ));
    }
    #endregion

    #region Laser���[�h�g�p���̐ݒ�ύX���\�b�h
    public void MBasic2Sub()
    {
        StartCoroutine(MLightSettingTransition
        (
          lightAngle, baseLightAngle, subLightAngle,
          lightIntensity, baseLightIntensity, subLightIntensity,
          lightRange, baseLightRange, subLightRange,
          base2LowTransitionTime
        ));
        _centerOfLightData.valueOfLaserLightRange = lightSource.range;
    }
    #endregion

    #region Laser���[�h����ʏ탂�[�h�ւ̕��A���\�b�h
    public void MSub2Basic()
    {

        StartCoroutine(MLightSettingTransition
        (
          lightAngle, subLightAngle, baseLightAngle,
          lightIntensity, subLightIntensity, baseLightIntensity,
          lightRange, subLightRange, baseLightRange,
          base2LowTransitionTime
        )
        );
    }
    #endregion

    #region Laser�p���C�g�̗L���������C�g���t�F�[�h�C��������悤�ɋN��
    public void MLaserDisabeled2Active()
    {
        laserLightSource.enabled = true;
        StartCoroutine(MLightSettingTransition
        (
          laserAngle, whenOffLaserLightAngle, laserLightAngle,
          laserIntensity, whenOffLaserLightIntensity, laserLightIntensity,
          laserRange, whenOffLaserLightRange, laserLightRange,
          base2LowTransitionTime
        )
        );
    }
    #endregion

    #region ���C�g���t�F�[�h�A�E�g������悤�ɒ�~��Laser�p���C�g�̖�����
    public void MLaserActive2Disabeled()
    {
        StartCoroutine(MLightSettingTransition
        (
          laserAngle, laserLightAngle, whenOffLaserLightAngle,
          laserIntensity, laserLightIntensity, whenOffLaserLightIntensity,
          laserRange, laserLightRange, whenOffLaserLightRange,
          base2LowTransitionTime
        )
        );
        laserLightSource.enabled = false;
    }
    #endregion
}
