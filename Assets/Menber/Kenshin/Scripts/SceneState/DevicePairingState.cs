using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DevicePairingState : IGameSceneState
{
    public string objectTag = "DevicePairing";
    public Vector3 spawnPosition = Vector3.zero;
    public Quaternion spawnRotation = Quaternion.identity;
    private GameObject devicePaiering;
    public void HandleInput(InputAction.CallbackContext context)
    {

    }
    public void EnterState()
    {
        devicePaiering = ObjectPool.Instance.SpawnFromPool(objectTag, spawnPosition, spawnRotation);

    }

    public void ExitState()
    {
        if (devicePaiering != null)
        {
            devicePaiering.SetActive(false);
        }
    }
}