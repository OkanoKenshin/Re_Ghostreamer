//using System.Collections;
//using System.Collections.Generic;
//using Unity.VisualScripting;
//using UnityEngine;
//using UnityEngine.InputSystem;

//public class CharMove : MonoBehaviour
//{
//    [SerializeField]
//    private Type.CharacterType _type = Type.CharacterType.Ghost1;

<<<<<<< HEAD
//    [SerializeField]
//    private float camSens = 5;

//    private Re_Ghostreamer _ghostReamer;

//    private Rigidbody rb;

//    [SerializeField]
//    float Speed = 5.0f;

//    Quaternion cameraRot, characterRot;

//    public GameObject Camera;

//    [SerializeField]
//    float minX = -45f, maxX = 45f;

//    CharaSelect charaSelect;
=======
    private Re_Ghostreamer _ghostReamer;

    [SerializeField]
    float Speed = 5.0f;

    CharaSelect charaSelect;
>>>>>>> feature/Nakahari

//    bool cursorLock = true;

<<<<<<< HEAD
//    private test.IStomachState testState;

//    private test.Human _human;

//    public bool isAnimation;

//    [SerializeField]
//    private GameObject headRig;

//    // Start is called before the first frame update
//    void Start()
//    {
//        _ghostReamer = new Re_Ghostreamer();
//        _ghostReamer.Enable();
//        rb = GetComponent<Rigidbody>();
//        characterRot = transform.localRotation;
//        cameraRot = Camera.transform.localRotation;

//        if(charaSelect == null)
//        {
//            charaSelect = GetComponent<CharaSelect>();
//        }
//        /*testState = new test.Player();
//        _human = new test.Human(testState);*/
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        MUpdateCursorLock();
//        if (!isAnimation)
//        {
//            MCameraControl();
//        }
//        //_human = new test.Human(Type.CharacterType.Player);
//    }


//    //カメラの向きを正面にして動く
//    private void FixedUpdate()
//    {
//        Vector2 move = MGetMoveValueForPlayer(_type.ToString());
//        Vector3 camForward = headRig.transform.forward;
//        camForward.y = 0;
//        transform.position += (camForward * move.y + headRig.transform.right * move.x) * Speed;
//    }

//    public Vector2 MGetMoveValueForPlayer(string playerName)
//    {
//        InputActionMap actionMap = _ghostReamer.asset.FindActionMap(playerName);
//        if (actionMap != null)
//        {
//            InputAction moveAction = actionMap.FindAction("Move");
//            if (moveAction != null)
//            {
//                return moveAction.ReadValue<Vector2>();
//            }
//        }
//        return Vector2.zero; // Default value
//    }
//    //カメラのコントロール
//    private void MCameraControl()
//    {
//        Vector2 look = MGetLookValueForPlayer(_type.ToString());
//        float camX = look.x * camSens;
//        float camY = look.y * camSens;

//        cameraRot *= Quaternion.Euler(-camY, 0, 0);
//        characterRot *= Quaternion.Euler(0, camX, 0);

//        cameraRot = MClampRotation(cameraRot);

//        Camera.transform.localRotation = cameraRot;
//        transform.localRotation = characterRot;
//    }

//    public Vector2 MGetLookValueForPlayer(string playerName)
//    {
//        InputActionMap actionMap = _ghostReamer.asset.FindActionMap(playerName);
//        if (actionMap != null)
//        {
//            InputAction LookAction = actionMap.FindAction("Look");
//            if (LookAction != null)
//            {
//                return LookAction.ReadValue<Vector2>();
//            }
//        }
//        return Vector2.zero; // Default value
//    }

//    //カメラの感度
//    public Quaternion MClampRotation(Quaternion q)
//    {
//        q.x /= q.w;
//        q.y /= q.w;
//        q.z /= q.w;
//        q.w = 1f;

//        float angleX = (Mathf.Atan(q.x) * Mathf.Rad2Deg);
//        angleX = Mathf.Clamp(angleX, minX, maxX);
//        //感度調整
//        q.x = Mathf.Tan(angleX * Mathf.Deg2Rad * 0.5f);

//        return q;
//    }
//    public void MUpdateCursorLock()
//    {
//        if (MGetCursorLockValueForPlayer(_type.ToString()))
//        {
//            cursorLock = false;
//        }
//        else
//        {
//            cursorLock = true;
//        }
//        if (cursorLock)
//        {
//            Cursor.lockState = CursorLockMode.Locked;
=======
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


    //カメラの向きを正面にして動く
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
>>>>>>> feature/Nakahari

//        }
//        else if (!cursorLock)
//        {
//            Cursor.lockState = CursorLockMode.None;
//        }
//    }
//    public bool MGetCursorLockValueForPlayer(string playerName)
//    {
//        InputActionMap actionMap = _ghostReamer.asset.FindActionMap(playerName);
//        if (actionMap != null)
//        {
//            InputAction LockAction = actionMap.FindAction("CursorLock");
//            if (LockAction != null)
//            {
//                return LockAction.ReadValue<bool>();
//            }
//        }
//        return false; // Default value
//    }

<<<<<<< HEAD
//    public void SetIsAnimation(bool value)
//    {
//        isAnimation = value;
//    }
//}
=======
    /*public void SetIsAnimation(bool value)
    {
        isAnimation = value;
    }*/
}
>>>>>>> feature/Nakahari
