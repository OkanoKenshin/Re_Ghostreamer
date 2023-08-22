using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ResultState : IGameSceneState
{
    public string objectTag = "Result";
    public Vector3 spawnPosition = Vector3.zero;
    public Quaternion spawnRotation = Quaternion.identity;
    private GameObject resultPrefab;
    public void HandleInput(InputAction.CallbackContext context)
    {

    }
    public void EnterState()
    {
        resultPrefab = ObjectPool.Instance.SpawnFromPool(objectTag, spawnPosition, spawnRotation);
    }

    public void ExitState()
    {
        if (resultPrefab != null)
        {
            resultPrefab.SetActive(false);
        }
    }
}