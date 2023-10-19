using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class TimeCounterFPG : MonoBehaviour
{
    [SerializeField]
    private CommonParam.UnitType _unitType = CommonParam.UnitType.Streamer;

    [SerializeField]
    InputManager _inputManager;

    private InputManager.InputParam _inputParam;

    public Image fillImage; // �h��Ԃ���\������Image
    public float totalTime = 40f;
    public float fillSpeed = 1f; // �h��Ԃ��̑���
    public float currentTime;
    private float fillAmount;

    private void Start()
    {
        if (_inputManager == null)
        {
            _inputManager = GetComponent<InputManager>();
        }
        _inputParam = _inputManager.UnitInputParams[_unitType];

        currentTime = 0; // �����l��0�ɐݒ�
    }

    private void Update()
    {
        if (currentTime < totalTime)
        {
            currentTime += Time.deltaTime * fillSpeed;
            fillAmount = currentTime / totalTime;
            fillAmount = Mathf.Clamp01(fillAmount); // �h��Ԃ��ʂ�0����1�͈̔͂ɐ���
            fillImage.fillAmount = fillAmount;
        }

        if (fillAmount >= 1f)
        {
            if (_inputParam.Ability)
            {
                Debug.Log("B��������܂���");
                Destroy(fillImage.gameObject);
            }
        }
    }
}
