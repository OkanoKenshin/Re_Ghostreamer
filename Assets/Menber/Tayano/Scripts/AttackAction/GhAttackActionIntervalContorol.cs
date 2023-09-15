using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhAttackActionIntervalContorol : MonoBehaviour //ゴーストの攻撃を呼び出し、クールタイムの管理を行うクラス
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
            _attackHitDetection = GetComponent<AttackHitDetection>();//AttackHitDetectionのnullチェック
        }
        if (_inputManager == null)
        {
            _inputManager = GetComponent<InputManager>();//InputManagerのnullチェック
        }
        if(_animation == null)
        {
            _animation = GetComponent<Animation>();//Animationのnullチェック
        }
        _inputParam = _inputManager.UnitInputParams[_unitType];
    }

    // Update is called once per frame
    void FixedUpdate()//入力を受け取った際に攻撃が可能であれば、攻撃の処理を行う
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
