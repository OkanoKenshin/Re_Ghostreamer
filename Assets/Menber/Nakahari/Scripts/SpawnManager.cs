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
        // PlayerInputManager�̃R���|�[�l���g���擾
        PlayerInputManager playerInputManager = GetComponent<PlayerInputManager>();

        // ScriptableObject����SpawnDate���X�g���擾
        List<SpawnDate> spawnDateList = spawnManagerScriptableObject.spawnDateList;

        // �eSpawnDate�̏����g�p���ăv���t�@�u���C���X�^���X������PlayerInput���쐬
        foreach (SpawnDate spawnDate in spawnDateList)
        {
            GameObject prefabToInstantiate = Resources.Load<GameObject>(spawnDate.prefabName);

            // PlayerInput���쐬���ăv���t�@�u���C���X�^���X��
            PlayerInput.Instantiate(prefabToInstantiate, controlScheme: "Gamepad", pairWithDevice: null);
        }
    }
}
