using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static CommonParam;

public class SealingSkills : MonoBehaviour
{
    [SerializeField] private HeatGaugeControl skillObject;
    [SerializeField] private Image skillicon; 
    [SerializeField] InputManager _inputManager;
    [SerializeField]
    private CommonParam.UnitType _unitType = CommonParam.UnitType.Streamer;

    private InputManager.InputParam _inputParam;

    private bool hasskillicon = false; 
    private bool hasActivatedSkill = false; 
    public float skillCooldownTime = 5.0f; 

    public float CoolTime = 0f;
    private float fillAmount = 1.0f; 
    private bool counting = false;

    private void Start()
    {
        _inputParam = _inputManager.UnitInputParams[_unitType];
        // クールダウンが開始される
        CoolTime = 0;
        counting = true; 
    }
    
    private void Update()
    {
        // クールタイムを増やす
        if (counting)
        {
            CoolTime += Time.deltaTime * fillAmount; 
        }

        if (CoolTime >= 40f) 
        {
            if (_inputParam.Ability) 
            {
                // スキルオブジェクトを無効にする
                if (skillObject != null)
                {
                    skillObject.enabled = false; 
                    Debug.Log("押されました");
                    hasActivatedSkill = true;
                    CoolTime = 0f;
                    StartCoroutine(StartCooldown()); 
                }
                // スキルアイコンを表示
                if (!hasskillicon) 
                {
                    skillicon.enabled = true; 
                    Debug.Log("スキルアイコン表示");
                    hasskillicon = true;
                    CoolTime = 0f;
                    StartCoroutine(StartCooldown()); 
                }
            }
        }
    }

    private IEnumerator StartCooldown()
    {
        yield return new WaitForSeconds(skillCooldownTime); 
        // クールダウン終了時にスキルオブジェクトを有効にする
        if (skillObject != null)
        {
            skillObject.enabled = true; 
            Debug.Log("クールダウン終了");
        }
        // クールダウン終了時にスキルアイコンを非表示にする
        if (hasskillicon)
        {
            skillicon.enabled = false; 
            Debug.Log("スキルアイコン非表示");
            hasskillicon = false; 
        }
    }
}
