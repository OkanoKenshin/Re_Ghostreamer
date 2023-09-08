using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityAction : MonoBehaviour
{
   
    [SerializeField]
    private float ghAbilityMaxCharge;  //アビリティ最大チャージ

    [SerializeField]
    private float ghAbilityChargeAmount; //チャージ量

    [SerializeField]
    private bool inputOn = false;

    public float ghAbilityCharge; //現在のチャージ値

    public bool abilityAvailable = false; //アビリティが使用可能かどうか

    // Start is called before the first frame update
  
    
    void Awake()
    {

        ghAbilityCharge = ghAbilityMaxCharge;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MAbilityStateControl();
    }
    #region MAbilityStateControl
    void MAbilityStateControl()
    {
        if(ghAbilityMaxCharge > ghAbilityCharge)
        {
            abilityAvailable = false;
            MChargeValue();
        }
        else
        {
            Debug.Log("チャージ完了");
            abilityAvailable=true;
            MAbilityInputReception();
        }
    }
    #endregion

    #region MChargeValue
    void MChargeValue()
    {
        Debug.Log("チャージ中");
        //アビリティをチャージ
        ghAbilityCharge += ghAbilityChargeAmount;
    }
    #endregion

    #region MAbilityInputReception
    void MAbilityInputReception()
    {
        if(inputOn == true && abilityAvailable == true)
        {
            Debug.Log("アビリティ実行！！");
            //アビリティの実行
            if(ghAbilityCharge >= ghAbilityMaxCharge)
            {
                abilityAvailable = false;//アビリティを使用後abilityAvailableをfalseにする
                ghAbilityCharge = 0; //アビリティ使用後にチャージ量を０にする
            }
            
        }

   
    }
    #endregion
}
