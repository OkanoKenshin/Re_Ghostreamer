using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static GetValueInterface;

public class InputSystemWithDictionary : MonoBehaviour
{
    IGetValue getValue;


    public static InputSystemWithDictionary Instance { get; private set; }
    //�V���O���g���̒�`

    public InputActionAsset actionAsset;

    public enum CharacterType
    {
        None,
        //�s�m��
        Ghost,
        Streamer
    }

    public CharacterType currentCharacterType = CharacterType.None;


    Dictionary<String, Action<InputAction.CallbackContext>> inputActionMap;
    //Dictionary�쐬

    private void Awake()
    {
        getValue = GetComponentInChildren<IGetValue>();

        #region �V���O���g���C���X�^���X��������
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        #endregion

        InitializeInputActions();

        foreach(var actionName in inputActionMap.Keys)
        {
            var action = actionAsset.FindAction(actionName);
            if (action != null)
            {
                action.performed += context => inputActionMap[actionName].Invoke(context);
            }
        }
    }
    #region ���ʓ���̃��[�h�p���\�b�h
    private void InitializeInputActions()
    {
        inputActionMap = new Dictionary<string, Action<InputAction.CallbackContext>>
            {
                {"Look",LookAction},
                {"Move", context =>
                    {
                        if(getValue != null)
                        {
                            getValue.GetValue(context.ReadValue<Vector2>());
                        }
                        else
                        {
                            Debug.LogError("getValue is null!");
                        }
                    }
                },

                {"Select",SelectAction}
            };
    }
    #endregion

    public void SetCharacterType(CharacterType type)
    //������������Streamer��Ghost���ɂ���ď���������A�K�؂ȓ��͎�t�ƑΉ������������Ăяo���\�ɂȂ�B
    {
        currentCharacterType = type;

        List<string> newAction = new List<string>();

        switch (currentCharacterType)
        {
            case CharacterType.Ghost:
//                inputActionMap.Add("Move", context => movable.Move(context.ReadValue<Vector2>()));
                inputActionMap.Add("GhAttack", GhAttackAction);
                inputActionMap.Add("Ability", AbilityAction);
                newAction.Add("GhAttack");
                newAction.Add("Ability");
                break;

            case CharacterType.Streamer:
                inputActionMap.Add("StMove", StMoveAction);
                inputActionMap.Add("Dash", DashAction);
                inputActionMap.Add("ShAttack", StAttackAction);
                newAction.Add("Dash");
                newAction.Add("StAttack");
                break;
        }

        foreach(var actionName in newAction)
        {
            var action = actionAsset.FindAction(actionName);
            if(action != null)
            {
                action.performed += context => inputActionMap[actionName].Invoke(context);
            }
        }

    }

    private void OnEnable()
    {
        actionAsset.Enable();
    }

    private void OnDisable()
    {
        actionAsset.Disable();
    }

        #region ���s�p���\�b�h�̋L�q��(�ŏI�I�ɃR�R�͒u�������č폜) 
        private void GhAttackAction(InputAction.CallbackContext context)
        {
            Debug.Log("GhAttack");
        }
        private void StAttackAction(InputAction.CallbackContext context)
        {
            Debug.Log("StAttack");
        }

        private void StMoveAction(InputAction.CallbackContext context)

        {
            Debug.Log("StMove");
        
        }

        private void LookAction(InputAction.CallbackContext context)
        {
            Debug.Log("Look");
        }

        private void SelectAction(InputAction.CallbackContext context)
        {
            Debug.Log("Select");
        }

        private void AbilityAction(InputAction.CallbackContext context)
        {
            Debug.Log("Ability");
        }

        private void DashAction(InputAction.CallbackContext context)

        {
            Debug.Log("Dash");
        }
        #endregion

}



