using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhAttackActionIntervalContorol : MonoBehaviour
{
    [SerializeField]
    private float ghAttackInterval;

    [SerializeField]
    AttackHitDetection _attackHitDetection;

    private bool ghCanAttack = true;

    [SerializeField]
    private bool InputOn = true;

    [SerializeField]
    private CommonParam.UnitType _unitType = CommonParam.UnitType.Streamer;
    [SerializeField]
    InputManager _inputManager;

    private Animation _animation;

    private InputManager.InputParam _inputParam;
    // Start is called before the first frame update
    void Start()
    {
        if (_attackHitDetection == null)
        {
            _attackHitDetection = GetComponent<AttackHitDetection>();
        }
        if (_inputManager == null)
        {
            _inputManager = GetComponent<InputManager>();
        }
        if(_animation == null)
        {
            _animation = GetComponent<Animation>();
        }
        _inputParam = _inputManager.UnitInputParams[_unitType];
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(_inputParam.Attack && ghCanAttack)
        {
            StartCoroutine(AttackCooldown());
            _attackHitDetection.MAttackHitDetection();
            _animation.MGhAttackAnima();
            
        }
        //Debug.Log(ghCanAttack);
    }
    #region attackのクールダウン
    IEnumerator AttackCooldown()
    {
        ghCanAttack = false;
        yield return new WaitForSeconds(ghAttackInterval);

        ghCanAttack = true;
    }
    #endregion
}
