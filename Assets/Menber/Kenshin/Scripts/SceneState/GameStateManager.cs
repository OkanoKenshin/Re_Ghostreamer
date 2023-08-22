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
        // currentStateの後についてる[?]はオブジェクト(currentState)がNull出ない場合のみ呼び出したい場合に付けるもの。
        // 詳細は「null条件演算子」で検索。
        currentState = newState;
        currentState.EnterState();
    }
}
