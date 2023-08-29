using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.InputSystem;

public class StMove : MonoBehaviour
{
    private Re_Ghostreamer _ghostReamer;

    private Rigidbody rb;

    [SerializeField]
    CenterDataOfStreamer _centerDataOfStreamer;

    [SerializeField]
    public float baseSpeed = 5.0f;//→CenterDataOfStreamerのstBaseSpeedに変更お願いします。

    [SerializeField]
    public float Speed;//→CenterDataOfStreamerのstSpeedに変更お願いします。



    public Vector2 move, look;
    bool cursor;
    bool cursorLock = true;

    public bool isAnimation;

    [SerializeField]
    private GameObject headRig;

    private Animation _animation;

    void Start()
    {
        _centerDataOfStreamer.stSpeed = _centerDataOfStreamer.stBaseSpeed;//stSpeedの初期化
        _centerDataOfStreamer.stStamina = _centerDataOfStreamer.stBaseStamina;//stStaminaの初期化

        _ghostReamer = new Re_Ghostreamer();
        _ghostReamer.Enable();

        if(_animation == null)
        {
            _animation = GetComponent<Animation>();
        }

        if (_centerDataOfStreamer == null)
        {
            _centerDataOfStreamer = GetComponent<CenterDataOfStreamer>();
        }
    }

    void Update()
    {
        MUpdateCursorLock();
        //Dashのdash()を呼ぶように変更お願いします.
        
    }
    public void OnCamera(InputAction.CallbackContext ctx) => look = ctx.ReadValue<Vector2>();


    // カメラの向きを正面にして動く
    private void FixedUpdate()
    {
        move = _ghostReamer.Streamer.Move.ReadValue<Vector2>();
        Vector3 camForward = headRig.transform.forward;
        camForward.y = 0;
        transform.position += (camForward * move.y + headRig.transform.right * move.x) * Speed;
        //_animation.MStMoveAnima();
    }
    
    public void MUpdateCursorLock()
    {

        cursor = _ghostReamer.Streamer.CursorLock.IsPressed();

        if (cursor)
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
}
