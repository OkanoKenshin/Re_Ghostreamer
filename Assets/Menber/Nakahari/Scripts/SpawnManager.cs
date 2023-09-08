using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnManager : MonoBehaviour
{
    public SpawnManagerScriptableObject spawnManagerScriptableObject;

    private void Awake()
    {
        // PlayerInputManagerのコンポーネントを取得
        PlayerInputManager playerInputManager = GetComponent<PlayerInputManager>();

        // ScriptableObjectからSpawnDateリストを取得
        List<SpawnDate> spawnDateList = spawnManagerScriptableObject.spawnDateList;

        // 各SpawnDateの情報を使用してプレファブをインスタンス化するPlayerInputを作成
        foreach (SpawnDate spawnDate in spawnDateList)
        {
            GameObject prefabToInstantiate = Resources.Load<GameObject>(spawnDate.prefabName);

            // PlayerInputを作成してプレファブをインスタンス化
            PlayerInput.Instantiate(prefabToInstantiate, controlScheme: "Gamepad", pairWithDevice: null);
        }
    }
}
