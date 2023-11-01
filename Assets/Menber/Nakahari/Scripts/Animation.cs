using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Animation : MonoBehaviour
{

    [SerializeField]
    private CommonParam.UnitType _unitType = CommonParam.UnitType.Streamer;

    private Animator animator;

    private InputManager.InputParam _inputParam;

    [SerializeField]
    InputManager _inputManager;

    [SerializeField]
    public int animationNow = 0;

    void Start()
    {
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
        if (_inputManager == null)
        {
            _inputManager = GetComponent<InputManager>();
        }
        _inputParam = _inputManager.UnitInputParams[_unitType];
    }
    void Update()
    {

    }

    public void MMoveAnima()
    {
        if (_inputParam.MoveX != 0 || _inputParam.MoveZ != 0)
        {
            animator.SetFloat("X", _inputParam.MoveX);
            animator.SetFloat("Z", _inputParam.MoveZ);
            if (animationNow != 1 && animationNow != 2)
            {
                animationNow = 1;
                animator.SetTrigger("Move");
            }
        }
        else
        {
            if (animationNow != 0 && animationNow != 5 && animationNow != 6 && animationNow != 7 && animationNow != 8 &&animationNow != 9)
            {
                animationNow = 0;
                animator.SetTrigger("Idol");
            }
        }
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

    #endregion

    #region Ghostのアニメーション

    public void MGhAttackAnima()
    {
        if (animationNow != 5)
        {
            animator.SetTrigger("Attack");
            StartCoroutine(tarn(90));
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
        if (animationNow != 8)
        {
            animationNow = 8;
            animator.SetTrigger("HeavyAttack");
        }
    }

    public void MGhDeathAnima()
    {
        if (animationNow != 9)
        {
            animationNow = 9;
            animator.SetTrigger("Death");
        }
    }

    #endregion

    IEnumerator tarn(float anime)
    {
        yield return new WaitForSeconds(anime);
        animationNow = 5;
    }

}