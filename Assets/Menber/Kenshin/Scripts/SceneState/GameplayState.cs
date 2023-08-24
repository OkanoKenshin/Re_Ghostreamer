using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameplayState : IGameSceneState
{
    private CharacterController characterController;
    private CharacterAssingnmentFunction characterAssingnmentFunction;

    public string objectTag = "GamePlay";
    public Vector3 spawnPosition = Vector3.zero;
    public Quaternion spawnRotation = Quaternion.identity;
    private GameObject gamePlayPrefab;

    public GameplayState(CharacterController controller,CharacterAssingnmentFunction charaFunction)
    {
        this.characterController = controller;
        this.characterAssingnmentFunction = charaFunction;
    }
    public void EnterState()
    {
        gamePlayPrefab = ObjectPool.Instance.SpawnFromPool(objectTag, spawnPosition, spawnRotation);
        characterAssingnmentFunction.MCharacterAssingnmentFunction();
    }
    public void HandleInput(InputAction.CallbackContext context)
    {
        characterController.HandleInput(context);
    }
   
    public void ExitState()
    {
        if (gamePlayPrefab != null)
        {
            gamePlayPrefab.SetActive(false);
        }
    }
}
