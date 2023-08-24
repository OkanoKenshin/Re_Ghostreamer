using UnityEngine.InputSystem;

public class DevicePairingState : IGameSceneState
{
    AssociateWithInputUser _associateWithInputUser = new AssociateWithInputUser();

    public void HandleInput(InputAction.CallbackContext context)
    {

    }
    public void EnterState()
    {
        _associateWithInputUser.MWaitPlease();
        InputSystem.onEvent += _associateWithInputUser.OnDevicePair2Display;
    }

    public void ExitState()
    {
        InputSystem.onEvent -= _associateWithInputUser.OnDevicePair2Display;

    }
}