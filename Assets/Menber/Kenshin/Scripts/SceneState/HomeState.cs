using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HomeState : IGameSceneState
{
    public string objectTag = "Home";
    public Vector3 spawnPosition = Vector3.zero;
    public Quaternion spawnRotation = Quaternion.identity;
    private GameObject homePrefab;
    public void HandleInput(InputAction.CallbackContext context)
    {

    }
    public void EnterState()
    {
        homePrefab = ObjectPool.Instance.SpawnFromPool(objectTag, spawnPosition, spawnRotation);

    }

    public void ExitState()
    {
        if (homePrefab != null)
        {
            homePrefab.SetActive(false);
        }
    }
}