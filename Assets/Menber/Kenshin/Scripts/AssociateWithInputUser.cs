using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.Users;


public class AssociateWithInputUser : MonoBehaviour
{
    [SerializeField]
    private int maxDevices;
    public InputActionAsset actionAsset;
    InputActionMap actionMap;
  

    Dictionary<InputUser, UserData> userMapping = new Dictionary<InputUser, UserData>();
    public static AssociateWithInputUser Instance { get; private set; }
    private void Awake()
    {
        foreach (var device in InputSystem.devices)
        {
            Debug.Log(device.name);
        }

        foreach (var user in InputUser.all)
        {
            Debug.Log("User: " + user.index);
            foreach (var device in user.pairedDevices)
            {
                Debug.Log("  Device: " + device.name);
            }
        }



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

        InputSystem.onEvent += OnInputEvent;
        actionMap = actionAsset.FindActionMap("Player");
    }

    void OnInputEvent(InputEventPtr eventPtr, InputDevice device)
    {
        if (eventPtr.IsA<StateEvent>() || eventPtr.IsA<DeltaStateEvent>())
        {
            int currentPaieredDevices = InputUser.all.Count;

            if(currentPaieredDevices < maxDevices)
            {
                InputUser.PerformPairingWithDevice(device);

            }
            else
            {
                Debug.Log("デバイスの接続制限に達しました。新しいデバイスはペアリングされません。");
            }
        }
        // 新しいInputUserがペアリングされた場合
        //if (change == InputUserChange.DevicePaired)
        //{
        //    Debug.Log("コントローラのボタンを押してください");

        //    int availableDisplayIndex = FindAvailableDisplay();
        //    // 利用可能なDisplayがある場合、ペアリングを行う

        //    // if (availableDisplayIndex != -1)
        //    {
        //        Vector3 spwanPosition = new Vector3(0,0,0);
        //        Quaternion spwanRotation = Quaternion.identity;
        //        GameObject pleasePressButton = ObjectPool.Instance.SpawnFromPool("DevicePairing", spwanPosition, spwanRotation);

        //        userMapping[user] = new UserData { display = Display.displays[availableDisplayIndex] };
        //        user.AssociateActionsWithUser(actionMap);
        //        Debug.Log("ペアリング完了！");
        //    }
        //}
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