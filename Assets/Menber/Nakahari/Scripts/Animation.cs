using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Animation : MonoBehaviour
{
    [SerializeField]
    private Type.CharacterType _type = Type.CharacterType.Ghost1;

    Re_Ghostreamer re_Ghostreamer;
    Vector2 move;
    private Animator animator;
    [SerializeField]
    private int animationNow = 0;

    CharMove _charMove;

    [SerializeField]
    CamCon _camCon;

    [SerializeField]
    private bool inputon = false;

    [SerializeField]
    private float _ct = 120;

    // Start is called before the first frame update
    void Start()
    {
        re_Ghostreamer = new Re_Ghostreamer();
        re_Ghostreamer.Enable();
        if (_charMove == null)
        {
            _charMove = GetComponent<CharMove>();
        }
        if(animator == null)
        {
            animator = GetComponent<Animator>();
        }
        if(_camCon == null)
        {
            _camCon = GetComponent<CamCon>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        move = _charMove.MGetMoveValueForPlayer(_type.ToString());
        MMoveAnima();
        MGhAttackAnima();
    }



    public void MMoveAnima()
    {
        if(move.x != 0 || move.y != 0)
        {
            animator.SetFloat("X",move.x);
            animator.SetFloat("Z", move.y);
            if(animationNow != 1)
            {
                animationNow = 1;
                animator.SetTrigger("Move");
            }
        }
        /*else
        {
            if(animationNow != 0)
            {
                animationNow = 0;
                animator.SetTrigger("Idol");
            }
        }*/
    }
    #region Streamerのアニメーション
    public void MStSprintAnima()
    {
        if(animationNow != 2)
        {
            animationNow = 2;
            animator.SetTrigger("Sprint");
        }
    }

    public void MStStaminaAnima()
    {
        if(animationNow != 3)
        {
            animationNow = 3;
            animator.SetTrigger("Stamina");
        }
        
    }

    public void MStHoldAnima()
    {
        if(animationNow != 4)
        {
            animationNow = 4;
            animator.SetTrigger("Hold");
        }
       
    }

    #endregion


    #region Ghostのアニメーション
    public void MGhAttackAnima()
    {
        if (animationNow != 5 && inputon == true)
        {
            _camCon.SetIsAnimation(true);
            animationNow = 5;
            animator.SetTrigger("Attack");
            StartCoroutine(Ct());
            StartCoroutine(AttackCT());
        }
        else if(_ct == 120)
        {
            _camCon.SetIsAnimation(false);
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
        if( animationNow != 7)
        {
            animationNow = 7;
            animator.SetTrigger("Search");
        }
    }
    #endregion

    IEnumerator Ct()
    {
        while (_ct <= 120)
        {
            yield return null;
            _ct++;
        }
        _ct = 0;
    }

    IEnumerator AttackCT()
    {
        yield return new WaitForSeconds(_ct);
    }

}
