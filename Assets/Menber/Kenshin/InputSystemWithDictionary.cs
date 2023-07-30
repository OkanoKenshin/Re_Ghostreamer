using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;
using static InputSystemWithDictionary;
using UnityEngine.InputSystem;

public class InputSystemWithDictionary : MonoBehaviour
{
    public InputActionAsset actionAsset;

    public enum CharacterType
    {
        None,
        //•sŠm’è
        Ghost,
        Streamer
    }

    public CharacterType currentCharacterType = CharacterType.None;


    Dictionary<String, System.Action> inputActionMap;

    private void Awake()
    {
        inputActionMap = new Dictionary<string, Action>
            {
                {"Attack",AttackAction},
                {"Move",MoveAction},
                {"Look",LookAction},
                {"Slect",SelectAction}
            };
    }

    public void SetCharacterType(CharacterType type)
    {
        currentCharacterType = type;

        switch (currentCharacterType)
        {
            case CharacterType.Ghost:
                inputActionMap.Add("Ability", AbilityAction);
                break;

            case CharacterType.Streamer:
                inputActionMap.Add("Dash", DashAction);
                break;
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

    private void AttackAction()
    {
        Debug.Log("Attack");
    }

    private void MoveAction()

    {
        Debug.Log("Move");
    }

    private void LookAction()
    {
        Debug.Log("Look");
    }

    private void SelectAction()
    {
        Debug.Log("Slect");
    }

    private void AbilityAction()
    {
        Debug.Log("Ability");
    }

    private void DashAction()

    {
        Debug.Log("Dash");
    }
}



