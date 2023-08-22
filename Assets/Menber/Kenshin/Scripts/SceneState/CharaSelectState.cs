using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharaSelectState : IGameSceneState
{
    public string objectTag = "CharacterSelect";
    public Vector3 spawnPosition = Vector3.zero;
    public Quaternion spawnRotation = Quaternion.identity;
    private GameObject characterSelectPrefab;
    public void HandleInput(InputAction.CallbackContext context)
    {

    }
    public void EnterState()
    {
        characterSelectPrefab = ObjectPool.Instance.SpawnFromPool(objectTag, spawnPosition, spawnRotation);
    }

    public void ExitState()
    {
        if (characterSelectPrefab != null)
        {
            characterSelectPrefab.SetActive(false);
        }
    }
}