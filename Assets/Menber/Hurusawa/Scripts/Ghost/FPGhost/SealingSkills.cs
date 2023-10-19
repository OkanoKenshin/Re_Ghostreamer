using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static CommonParam;

public class SealingSkills : MonoBehaviour
{
    [SerializeField] private LightHitDetection skillObject;
    [SerializeField] private Image skillicon;
    [SerializeField] private LightHitDetection Light;

    [SerializeField]
    private CommonParam.UnitType _unitType = CommonParam.UnitType.FPGhost;
    [SerializeField]
    InputManager _inputManager;
    private InputManager.InputParam _inputParam;

    private bool hasskillicon = false;
    public float skillCooldownTime = 5.0f;

    public float CoolTime = 0f;
    private float fillAmount = 1.0f;
    private bool counting = false;

    int Fpgcount;

    private void Start()
    {
        if (_inputManager == null)
        {
            _inputManager = GetComponent<InputManager>();
        }
        _inputParam = _inputManager.UnitInputParams[_unitType];
        CoolTime = 0;
        counting = true;

    }
    private void Update()
    {
        if (counting)
        {
            CoolTime += Time.deltaTime * fillAmount;
            Debug.Log("CoolTime: " + CoolTime);
        }

        if (CoolTime >= 40f)
        {
            if (_inputParam.Ability)
            {
                if(Fpgcount == 0)
                {
                    if (skillObject != null)
                    {
                        skillObject.enabled = false;
                        Debug.Log("押されました");
                        StartCoroutine(StartCooldown());
                    }
                    if (!hasskillicon) // 逆に変更：hasskilliconがfalseの場合に実行
                    {
                        skillicon.enabled = true; // 逆に変更：スキルアイコンを表示
                        Debug.Log("スキルアイコン表示");
                        hasskillicon = true;

                        StartCoroutine(StartCooldown());
                    }
                    CoolTime = 0f;

                }
            }
        }
    }

    private IEnumerator StartCooldown()
    {
        LightHitDetection.lightstop = false;
        skillicon.enabled = false;
        yield return new WaitForSeconds(skillCooldownTime);

        if (skillObject != null)
        {
            skillObject.enabled = true;
            Debug.Log("クールダウン終了");
            LightHitDetection.lightstop = true;
        }
        if (hasskillicon)
        {
            Fpgcount++;
            skillicon.enabled = true;
            Debug.Log("スキルアイコン非表示");
            hasskillicon = false;
        }

    }
}
