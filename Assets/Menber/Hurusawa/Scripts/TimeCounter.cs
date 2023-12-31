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

    public Image fillImage; // 塗りつぶしを表示するImage
    public float totalTime = 40f;
    public float fillSpeed = 1f; // 塗りつぶしの速さ
    private float currentTime;
    private float fillAmount;

    private void Start()
    {
        if (_inputManager == null)
        {
            _inputManager = GetComponent<InputManager>();
        }
        _inputParam = _inputManager.UnitInputParams[_unitType];

        currentTime = 0; // 初期値を0に設定
    }

    private void Update()
    {
        if (currentTime < totalTime)
        {
            currentTime += Time.deltaTime * fillSpeed;
            fillAmount = currentTime / totalTime;
            fillAmount = Mathf.Clamp01(fillAmount); // 塗りつぶし量を0から1の範囲に制限
            fillImage.fillAmount = fillAmount;
        }

        if (fillAmount >= 1f)
        {
            if (_inputParam.Ability)
            {
                Debug.Log("Bが押されました");
                Destroy(fillImage.gameObject);
            }
        }
    }
}
