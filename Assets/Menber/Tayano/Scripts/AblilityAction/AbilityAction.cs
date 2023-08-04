using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityAction : MonoBehaviour
{
   
    [SerializeField]
    private float ghAbilityMaxCharge;  //�A�r���e�B�ő�`���[�W

    [SerializeField]
    private float ghAbilityChargeAmount; //�`���[�W��

    [SerializeField]
    private bool inputOn = false;

    public float ghAbilityCharge; //���݂̃`���[�W�l

    public bool abilityAvailable = false; //�A�r���e�B���g�p�\���ǂ���

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
            Debug.Log("�`���[�W����");
            abilityAvailable=true;
            MAbilityInputReception();
        }
    }
    #endregion

    #region MChargeValue
    void MChargeValue()
    {
        Debug.Log("�`���[�W��");
        //�A�r���e�B���`���[�W
        ghAbilityCharge += ghAbilityChargeAmount;
    }
    #endregion

    #region MAbilityInputReception
    void MAbilityInputReception()
    {
        if(inputOn == true && abilityAvailable == true)
        {
            Debug.Log("�A�r���e�B���s�I�I");
            //�A�r���e�B�̎��s
            if(ghAbilityCharge >= ghAbilityMaxCharge)
            {
                abilityAvailable = false;//�A�r���e�B���g�p��abilityAvailable��false�ɂ���
                ghAbilityCharge = 0; //�A�r���e�B�g�p��Ƀ`���[�W�ʂ��O�ɂ���
            }
            
        }

   
    }
    #endregion
}
