using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;


public class AssociateWithInputUser : MonoBehaviour
{
    public InputActionAsset actionAsset;
    InputActionMap actionMap;

    Dictionary<InputUser, UserData> userMapping = new Dictionary<InputUser, UserData>();

    public static AssociateWithInputUser Instance { get; private set; }

    void Awake()
    {
        // シングルトンの実装部分
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        InputUser.onChange += OnUserChange;
        actionMap = actionAsset.FindActionMap("Player");
    }

    void OnUserChange(InputUser user, InputUserChange change, InputDevice device)
    {
        // 新しいInputUserがペアリングされた場合
        if (change == InputUserChange.DevicePaired)
        {
            Debug.Log("コントローラのボタンを押してください");
            // 本来はここで上記文言が書かれた画像を表示する。

            // 利用可能なDisplayがある場合、ペアリングを行う
            int availableDisplayIndex = FindAvailableDisplay();
            if (availableDisplayIndex != -1)
            {
                userMapping[user] = new UserData { display = Display.displays[availableDisplayIndex] };
                Debug.Log("ペアリング完了！");
            }
        }
    }

    int FindAvailableDisplay()
    {
        for (int i = 0; i < Display.displays.Length; i++)
        {
            if (!userMapping.Values.Any(data => data.display == Display.displays[i]))
            {
                return i;
            }
        }
        return -1; // 利用可能なDisplayがない場合
    }

}