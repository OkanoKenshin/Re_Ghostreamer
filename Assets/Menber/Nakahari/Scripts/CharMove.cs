using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharMove : MonoBehaviour
{
    [SerializeField]
    private Type.CharacterType _type = Type.CharacterType.Ghost1;

    private Re_Ghostreamer _ghostReamer;

    [SerializeField]
    float Speed = 5.0f;

    CharaSelect charaSelect;

    bool cursorLock = true;

    [SerializeField]
    private GameObject Camera;

    // Start is called before the first frame update
    void Start()
    {
        _ghostReamer = new Re_Ghostreamer();
        _ghostReamer.Enable();

        if(charaSelect == null)
        {
            charaSelect = GetComponent<CharaSelect>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        MUpdateCursorLock();
    }


    //ÉJÉÅÉâÇÃå¸Ç´Çê≥ñ Ç…ÇµÇƒìÆÇ≠
    private void FixedUpdate()
    {
        Vector2 move = MGetMoveValueForPlayer(_type.ToString());
        Vector3 camForward = Camera.transform.forward;
        camForward.y = 0;
        transform.position += (camForward * move.y + Camera.transform.right * move.x) * Speed;
    }

    public Vector2 MGetMoveValueForPlayer(string playerName)
    {
        InputActionMap actionMap = _ghostReamer.asset.FindActionMap(playerName);
        if (actionMap != null)
        {
            InputAction moveAction = actionMap.FindAction("Move");
            if (moveAction != null)
            {
                return moveAction.ReadValue<Vector2>();
            }
        }
        return Vector2.zero; // Default value
    }
    public void MUpdateCursorLock()
    {
        if (MGetCursorLockValueForPlayer(_type.ToString()))
        {
            cursorLock = false;
        }
        else
        {
            cursorLock = true;
        }
        if (cursorLock)
        {
            Cursor.lockState = CursorLockMode.Locked;

        }
        else if (!cursorLock)
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
    public bool MGetCursorLockValueForPlayer(string playerName)
    {
        InputActionMap actionMap = _ghostReamer.asset.FindActionMap(playerName);
        if (actionMap != null)
        {
            InputAction LockAction = actionMap.FindAction("CursorLock");
            if (LockAction != null)
            {
                return LockAction.ReadValue<bool>();
            }
        }
        return false; // Default value
    }

    /*public void SetIsAnimation(bool value)
    {
        isAnimation = value;
    }*/
}
