using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Animation : MonoBehaviour
{
    Vector2 move;

    private Animator animator;

    private CharMove _charMove;

    [SerializeField]
    private int animationNow = 0;

    void Start()
    {

        if(_charMove == null)
        {
            _charMove = GetComponent<CharMove>();
        }
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
    }
    void Update()
    {
        move = _charMove.move;
    }

    public void MMoveAnima()
    {
        if (move.x != 0 || move.y != 0)
        {
            animator.SetFloat("X", move.x);
            animator.SetFloat("Z", move.y);
            if (animationNow != 1)
            {
                animationNow = 1;
                animator.SetTrigger("Move");
            }
        }
        /*else
        {
            if (animationNow != 0)
            {
                _charMove.Speed = 0.1f;
                animationNow = 0;
                animator.SetTrigger("Idol");
            }
        }*/
    }

    #region Streamerのアニメーション
    public void MStSprintAnima()
    {
        if (animationNow != 2)
        {
            animationNow = 2;
            animator.SetTrigger("Sprint");
        }
    }

    public void MStStaminaAnima()
    {
        if (animationNow != 3)
        {
            animationNow = 3;
            animator.SetTrigger("Stamina");
        }

    }

    public void MStHoldAnima()
    {
        if (animationNow != 4)
        {
            animationNow = 4;
            animator.SetTrigger("Hold");
        }

    }

    #endregion

    #region Ghostのアニメーション
    public void MGhAttackAnima()
    {
        if (animationNow != 5)
        {
            animationNow = 5;
            animator.SetTrigger("Attack");
        }
    }
    public void MGhFogAnima()
    {
        if (animationNow != 6)
        {
            animationNow = 6;
            animator.SetTrigger("Fog");
        }
    }

    public void MGhSearchAnima()
    {
        if (animationNow != 7)
        {
            animationNow = 7;
            animator.SetTrigger("Search");
        }
    }

    public void MGhHeavyAttackAnima()
    {
        if(animationNow != 8)
        {
            animationNow = 8;
            animator.SetTrigger("HeavyAttack");
        }
    }
    #endregion

}








