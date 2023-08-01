using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static GetValueInterface;

public class InputSystemWithDictionary : MonoBehaviour
{
    IGetValue getValue;


    public static InputSystemWithDictionary Instance { get; private set; }
    //シングルトンの定義

    public InputActionAsset actionAsset;

    public enum CharacterType
    {
        None,
        //不確定
        Ghost,
        Streamer
    }

    public CharacterType currentCharacterType = CharacterType.None;


    Dictionary<String, Action<InputAction.CallbackContext>> inputActionMap;
    //Dictionary作成

    private void Awake()
    {
        getValue = GetComponentInChildren<IGetValue>();

        #region シングルトンインスタンスを初期化
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
    #region 共通動作のロード用メソッド
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
    //入った引数がStreamerかGhostかによって処理が分岐、適切な入力受付と対応した処理が呼び出し可能になる。
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

        #region 実行用メソッドの記述欄(最終的にココは置き換えて削除) 
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



