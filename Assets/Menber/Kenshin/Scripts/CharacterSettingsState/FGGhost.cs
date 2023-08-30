using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FGGhost : ICharacterSettingsState
{
    public void HandleInput(InputAction.CallbackContext context) 
    {
        // �W���C�X�e�B�b�N�̓��͂��擾���ăL�����N�^�[���ړ� 
        if (context.action.name == "Move")
        {
            Vector2 inputVector = context.ReadValue<Vector2>();

            //MMove(inputVector);
        }
        if (context.action.name == "Look")
        {
            Vector2 lookVector = context.ReadValue<Vector2>();
        }
        if (context.action.name == "Select")
        {
            bool selectBool = context.ReadValueAsButton();
        }
        if (context.action.name == "Ability")
        {
            bool abilityBool = context.ReadValueAsButton();
        }
        if (context.action.name == "Attack")
        {
            bool attackBool = context.ReadValueAsButton();
        }
        if (context.action.name == "CursorLock")
        {
            bool cursorLockBool = context.ReadValueAsButton();
        }
    }
    public void EnterState() { }
    public void ExitState() { }
}
