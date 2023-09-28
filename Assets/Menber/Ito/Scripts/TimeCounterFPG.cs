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

    public Image fillImage; // “h‚è‚Â‚Ô‚µ‚ğ•\¦‚·‚éImage
    public float totalTime = 40f;
    public float fillSpeed = 1f; // “h‚è‚Â‚Ô‚µ‚Ì‘¬‚³
    public float currentTime;
    private float fillAmount;

    private void Start()
    {
        if (_inputManager == null)
        {
            _inputManager = GetComponent<InputManager>();
        }
        _inputParam = _inputManager.UnitInputParams[_unitType];

        currentTime = 0; // ‰Šú’l‚ğ0‚Éİ’è
    }

    private void Update()
    {
        if (currentTime < totalTime)
        {
            currentTime += Time.deltaTime * fillSpeed;
            fillAmount = currentTime / totalTime;
            fillAmount = Mathf.Clamp01(fillAmount); // “h‚è‚Â‚Ô‚µ—Ê‚ğ0‚©‚ç1‚Ì”ÍˆÍ‚É§ŒÀ
            fillImage.fillAmount = fillAmount;
        }

        if (fillAmount >= 1f)
        {
            if (_inputParam.Ability)
            {
                Debug.Log("B‚ª‰Ÿ‚³‚ê‚Ü‚µ‚½");
                Destroy(fillImage.gameObject);
            }
        }
    }
}
