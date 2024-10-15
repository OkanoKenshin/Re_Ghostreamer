using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class TimeCounter : MonoBehaviour
{
    [SerializeField]
    private CommonParam.UnitType _unitType = CommonParam.UnitType.Streamer;

    [SerializeField]
    InputManager _inputManager;

    private InputManager.InputParam _inputParam;

    public Image fillImage; // 時間を表す円形のImage
    public float totalTime = 40f;
    public float fillSpeed = 1f; // 時間の進行速度
    public float currentTime;
    private float fillAmount;

    private void Start()
    {
        if (_inputManager == null)
        {
            _inputManager = GetComponent<InputManager>();
        }
        _inputParam = _inputManager.UnitInputParams[_unitType];

        currentTime = 0; // 現在の時間を0に設定
    }

    private void Update()
    {
        if (currentTime < totalTime)
        {
            currentTime += Time.deltaTime * fillSpeed;
            fillAmount = currentTime / totalTime;
            fillAmount = Mathf.Clamp01(fillAmount); // 時間の進行を0から1の範囲に制限
            fillImage.fillAmount = fillAmount;
        }

        if (fillAmount >= 1f)
        {
            if (_inputParam.Ability)
            {
                Debug.Log("ボタンが押されました");
                Destroy(fillImage.gameObject);
            }
        }
    }
}
