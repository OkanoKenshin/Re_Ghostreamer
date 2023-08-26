using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharMove : MonoBehaviour
{
    private Re_Ghostreamer _ghostReamer;

    private Rigidbody rb;

    [SerializeField]
    CenterDataOfStreamer _centerDataOfStreamer;

    [SerializeField]
    public float baseSpeed = 5.0f;//��CenterDataOfStreamer��stBaseSpeed�ɕύX���肢���܂��B

    [SerializeField]
    public float Speed;//��CenterDataOfStreamer��stSpeed�ɕύX���肢���܂��B



    public Vector2 move, look;

    float cursor,attack,ability,dash;

    bool _attack, _ability, _dash;
    bool cursorLock = true;

    public bool isAnimation;

    [SerializeField]
    private GameObject headRig;

    private Animation _animation;

    void Start()
    {
        _centerDataOfStreamer.stSpeed = _centerDataOfStreamer.stBaseSpeed;//stSpeed�̏�����
        _centerDataOfStreamer.stStamina = _centerDataOfStreamer.stBaseStamina;//stStamina�̏�����

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
        Attack();
        Ability();
        //Dash��dash()���ĂԂ悤�ɕύX���肢���܂�.
        
    }

    public void OnMove(InputAction.CallbackContext ctx) => move = ctx.ReadValue<Vector2>();
    public void OnCamera(InputAction.CallbackContext ctx) => look = ctx.ReadValue<Vector2>();
    public void OnAttack(InputAction.CallbackContext ctx) => attack = ctx.ReadValue<float>();
    public void OnAbility(InputAction.CallbackContext ctx) => ability = ctx.ReadValue<float>();
    public void OnCursor(InputAction.CallbackContext ctx) => cursor = ctx.ReadValue<float>();
    public void OnDash(InputAction.CallbackContext ctx) => dash = ctx.ReadValue<float>();


    // �J�����̌����𐳖ʂɂ��ē���
    private void FixedUpdate()
    {
        Vector3 camForward = headRig.transform.forward;
        camForward.y = 0;
        transform.position += (camForward * move.y + headRig.transform.right * move.x) * Speed;
        _animation.MMoveAnima();
    }
    
    public void MUpdateCursorLock()
    {
        if (cursor == 1)
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
        if(attack == 1)
        {
            _attack = true;
        }
        else
        {
            _attack = false;
        }

        if (_attack)
        {
            _animation.MGhAttackAnima();
        }
    }

    public void Ability()
    {
        if (ability == 1)
        {
            _ability = true;
        }
        else
        {
            _ability = false;
        }

        if (_ability)
        {
            _animation.MGhHeavyAttackAnima();
        }
    }


    
}
