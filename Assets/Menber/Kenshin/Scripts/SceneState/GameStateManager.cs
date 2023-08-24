using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    
    private IGameSceneState currentState;
    // Start is called before the first frame update
    void Start()
    {
        SetState(new DevicePairingState());
    }

   public void SetState(IGameSceneState newState)
    {
        currentState?.ExitState();
        // currentState�̌�ɂ��Ă�[?]�̓I�u�W�F�N�g(currentState)��Null�o�Ȃ��ꍇ�̂݌Ăяo�������ꍇ�ɕt������́B
        // �ڍׂ́unull�������Z�q�v�Ō����B
        currentState = newState;
        currentState.EnterState();
    }
}
