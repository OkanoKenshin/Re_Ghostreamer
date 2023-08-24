using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharMove : MonoBehaviour
{
    private Re_Ghostreamer _ghostReamer;

    private Rigidbody rb;

    [SerializeField]
    float Speed = 5.0f;

    public Vector2 move, look;

    bool cursor,attack,ability;

    CharaSelect charaSelect;

    bool cursorLock = true;

    public bool isAnimation;

    [SerializeField]
    private GameObject headRig;

    private Animation _animation;

    void Start()
    {
        _ghostReamer = new Re_Ghostreamer();
        _ghostReamer.Enable();

        if (charaSelect == null)
        {
            charaSelect = GetComponent<CharaSelect>();
        }
        if(_animation == null)
        {
            _animation = GetComponent<Animation>();
        }
    }

    void Update()
    {
        MUpdateCursorLock();
        Attack();
        Ability();
        
    }

    public void OnMove(InputAction.CallbackContext ctx) => move = ctx.ReadValue<Vector2>();
    public void OnCamera(InputAction.CallbackContext ctx) => look = ctx.ReadValue<Vector2>();
    public void OnAttack(InputAction.CallbackContext ctx) => attack = ctx.ReadValue<bool>();
    public void OnAbility(InputAction.CallbackContext ctx) => ability = ctx.ReadValue<bool>();
    public void OnCursor(InputAction.CallbackContext ctx) => cursor = ctx.ReadValue<bool>();


    // ÉJÉÅÉâÇÃå¸Ç´Çê≥ñ Ç…ÇµÇƒìÆÇ≠
    private void FixedUpdate()
    {
        Vector3 camForward = headRig.transform.forward;
        camForward.y = 0;
        transform.position += (camForward * move.y + headRig.transform.right * move.x) * Speed;
        _animation.MMoveAnima();
    }
    
    public void MUpdateCursorLock()
    {
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

    public void Attack()
    {
        if(attack)
        {
            _animation.MGhAttackAnima();
        }
    }

    public void Ability()
    {
        if (ability)
        {
            _animation.MGhHeavyAttackAnima();
        }
    }
    
}
