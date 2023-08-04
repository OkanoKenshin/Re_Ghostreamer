using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharMove : MonoBehaviour
{
    [SerializeField]
    private Type.CharacterType type = Type.CharacterType.Ghost1;

    [SerializeField]
    private float camSens = 5;

    private Re_Ghostreamer ghostReamer;

    private Rigidbody rb;

    [SerializeField]
    float Speed = 5.0f;

    Quaternion cameraRot, characterRot;

    public GameObject Camera;

    [SerializeField]
    float minX = -45f, maxX = 45f;

    CharaSelect charaSelect;

    bool cursorLock = true;

    // Start is called before the first frame update
    void Start()
    {
        ghostReamer = new Re_Ghostreamer();
        ghostReamer.Enable();
        rb = GetComponent<Rigidbody>();
        characterRot = transform.localRotation;
        cameraRot = Camera.transform.localRotation;

        if(charaSelect == null)
        {
            charaSelect = GetComponent<CharaSelect>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCursorLock();
        CameraControl();
    }

    //�J�����̌����𐳖ʂɂ��ē���
    private void FixedUpdate()
    {
        Vector2 move = GetMoveValueForPlayer(type.ToString());
        Vector3 camForward = Camera.transform.forward;
        camForward.y = 0;
        transform.position += (camForward * move.y + Camera.transform.right * move.x) * Speed;
    }

    public Vector2 GetMoveValueForPlayer(string playerName)
    {
        InputActionMap actionMap = ghostReamer.asset.FindActionMap(playerName);
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
    //�J�����̃R���g���[��
    private void CameraControl()
    {
        Vector2 look = GetLookValueForPlayer(type.ToString());
        float camX = look.x * camSens;
        float camY = look.y * camSens;

        cameraRot *= Quaternion.Euler(-camY, 0, 0);
        characterRot *= Quaternion.Euler(0, camX, 0);

        cameraRot = ClampRotation(cameraRot);

        Camera.transform.localRotation = cameraRot;
        transform.localRotation = characterRot;
    }

    public Vector2 GetLookValueForPlayer(string playerName)
    {
        InputActionMap actionMap = ghostReamer.asset.FindActionMap(playerName);
        if (actionMap != null)
        {
            InputAction LookAction = actionMap.FindAction("Look");
            if (LookAction != null)
            {
                return LookAction.ReadValue<Vector2>();
            }
        }
        return Vector2.zero; // Default value
    }

    //�J�����̊��x
    public Quaternion ClampRotation(Quaternion q)
    {
        q.x /= q.w;
        q.y /= q.w;
        q.z /= q.w;
        q.w = 1f;

        float angleX = (Mathf.Atan(q.x) * Mathf.Rad2Deg);
        angleX = Mathf.Clamp(angleX, minX, maxX);
        //���x����
        q.x = Mathf.Tan(angleX * Mathf.Deg2Rad * 0.5f);

        return q;
    }
    public void UpdateCursorLock()
    {
        if (GetCursorLockValueForPlayer(type.ToString()))
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
    public bool GetCursorLockValueForPlayer(string playerName)
    {
        InputActionMap actionMap = ghostReamer.asset.FindActionMap(playerName);
        if (actionMap != null)
        {
            InputAction LookAction = actionMap.FindAction("CursorLock");
            if (LookAction != null)
            {
                return LookAction.ReadValue<bool>();
            }
        }
        return false; // Default value
    }
}
