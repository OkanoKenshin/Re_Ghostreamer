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

        InputUser.onChange += OnUserChange;
        actionMap = actionAsset.FindActionMap("Player");
    }

    void OnUserChange(InputUser user, InputUserChange change, InputDevice device)
    {
        // �V����InputUser���y�A�����O���ꂽ�ꍇ
        if (change == InputUserChange.DevicePaired)
        {
            Debug.Log("�R���g���[���̃{�^���������Ă�������");
            // �{���͂����ŏ�L�����������ꂽ�摜��\������B

            // ���p�\��Display������ꍇ�A�y�A�����O���s��
            int availableDisplayIndex = FindAvailableDisplay();
            if (availableDisplayIndex != -1)
            {
                userMapping[user] = new UserData { display = Display.displays[availableDisplayIndex] };
                Debug.Log("�y�A�����O�����I");
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
        return -1; // ���p�\��Display���Ȃ��ꍇ
    }

}