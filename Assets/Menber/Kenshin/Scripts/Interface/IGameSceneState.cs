using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public interface IGameSceneState 
{
    public void  EnterState();
    public void HandleInput(InputAction.CallbackContext context);
    public void ExitState();
}
