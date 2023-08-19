using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameplayState : IGameSceneState
{
    private CharacterController characterController;
    private CharacterAssingnmentFunction characterAssingnmentFunction;
    
    public GameplayState(CharacterController controller,CharacterAssingnmentFunction charaFunction)
    {
        this.characterController = controller;
        this.characterAssingnmentFunction = charaFunction;
    }
    public void EnterState()
    {
        characterAssingnmentFunction.MCharacterAssingnmentFunction();
    }
    public void HandleInput(InputAction.CallbackContext context)
    {
        characterController.HandleInput(context);
    }
   
    public void ExitState()
    {

    }
}
