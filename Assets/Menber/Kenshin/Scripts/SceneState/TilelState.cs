using UnityEngine;
using UnityEngine.InputSystem;

public class TilelState : IGameSceneState
{
    public string objectTag = "Title";
    public Vector3 spawnPosition = Vector3.zero;
    public Quaternion spawnRotation = Quaternion.identity;
    private GameObject titlePrefab;
    public void HandleInput(InputAction.CallbackContext context)
    {

    }
    public void EnterState()
    {
        titlePrefab = ObjectPool.Instance.SpawnFromPool(objectTag, spawnPosition, spawnRotation);

    }

    public void ExitState()
    {
        if(titlePrefab != null)
        {
            titlePrefab.SetActive(false); 
        }
    }
}
