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

    private bool InputOn = true;

    [SerializeField]
    private CommonParam.UnitType _unitType = CommonParam.UnitType.Streamer;
    [SerializeField]
    InputManager _inputManager;

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
        _inputParam = _inputManager.UnitInputParams[_unitType];
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(_inputParam.Attack && ghCanAttack)
        {
            StartCoroutine(AttackCooldown());
            _attackHitDetection.MAttackHitDetection();

        }
    }
    IEnumerator AttackCooldown()
    {
        ghCanAttack = false;
        yield return new WaitForSeconds(ghAttackInterval);
        ghCanAttack = true;
    }
}
