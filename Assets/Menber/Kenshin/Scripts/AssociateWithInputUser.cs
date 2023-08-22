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



        // �V���O���g���̎�������
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
                Debug.Log("�f�o�C�X�̐ڑ������ɒB���܂����B�V�����f�o�C�X�̓y�A�����O����܂���B");
            }
        }
        // �V����InputUser���y�A�����O���ꂽ�ꍇ
        //if (change == InputUserChange.DevicePaired)
        //{
        //    Debug.Log("�R���g���[���̃{�^���������Ă�������");

        //    int availableDisplayIndex = FindAvailableDisplay();
        //    // ���p�\��Display������ꍇ�A�y�A�����O���s��

        //    // if (availableDisplayIndex != -1)
        //    {
        //        Vector3 spwanPosition = new Vector3(0,0,0);
        //        Quaternion spwanRotation = Quaternion.identity;
        //        GameObject pleasePressButton = ObjectPool.Instance.SpawnFromPool("DevicePairing", spwanPosition, spwanRotation);

        //        userMapping[user] = new UserData { display = Display.displays[availableDisplayIndex] };
        //        user.AssociateActionsWithUser(actionMap);
        //        Debug.Log("�y�A�����O�����I");
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
        return -1; // ���p�\��Display���Ȃ��ꍇ
    }

}