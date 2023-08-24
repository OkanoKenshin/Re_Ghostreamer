using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;


public class UserDataVault : MonoBehaviour
{
    public Dictionary<InputUser, UserData> userMapping = new Dictionary<InputUser, UserData>();
    public static UserDataVault Instance { get; private set; }
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

        // ƒVƒ“ƒOƒ‹ƒgƒ“‚ÌŽÀ‘••”•ª
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

    }
}