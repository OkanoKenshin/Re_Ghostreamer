using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LoadState : IGameSceneState
{
    public string objectTag = "Load";
    public Vector3 spawnPosition = Vector3.zero;
    public Quaternion spawnRotation = Quaternion.identity;
    private GameObject loadPrefab;
    public void HandleInput(InputAction.CallbackContext context)
    {

    }
    public void EnterState()
    {
        loadPrefab = ObjectPool.Instance.SpawnFromPool(objectTag, spawnPosition, spawnRotation);

    }

    public void ExitState()
    {
        if (loadPrefab != null)
        {
            loadPrefab.SetActive(false);
        }
    }
}