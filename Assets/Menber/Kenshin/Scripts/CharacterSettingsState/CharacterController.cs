using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR.Haptics;

public class CharacterController 
{
    private ICharacterSettingsState curentState;
    
    public void SetCharacterState(ICharacterSettingsState newState)
    {
        curentState?.ExitState();
        curentState = newState;
        curentState.EnterState();
    }

    public void HandleInput(InputAction.CallbackContext context)
    {
        curentState.HandleInput(context);
    }
}
