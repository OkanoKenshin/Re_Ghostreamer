using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HAttack : MonoBehaviour
{
    [SerializeField]
    private CommonParam.UnitType _unitType = CommonParam.UnitType.Streamer;

    [SerializeField]
    InputManager _inputManager;

    private InputManager.InputParam _inputParam;

    private Animation _animation;

    private int count = 0;

    private bool _stayjudgement = false;

    [SerializeField]
    public float _hastay;

    [SerializeField]
    CenterDataOfStreamer _centerDataOfStreamer;

    [SerializeField]
    private AttackHitDetection _attackHitDetection;

    [SerializeField]
    float ghAttackPower1 = 0f;
    [SerializeField]
    float ghAttackPower2 = 0f;
    [SerializeField]
    float ghAttackPower3 = 0f;

    private bool _haAnimation = false;

    [SerializeField]
    bool InputOn = false;
    // Start is called before the first frame update
    void Start()
    {
        if (_inputManager == null)
        {
            _inputManager = GetComponent<InputManager>();
        }
        if (_animation == null)
        {
            _animation = GetComponent<Animation>();
        }
        if (_centerDataOfStreamer == null)
        {
            _centerDataOfStreamer = GetComponent<CenterDataOfStreamer>();
        }
        _inputParam = _inputManager.UnitInputParams[_unitType];

        StartCoroutine(HAstay());
    }

    private void Update()
    {
        MHAttack();
        Debug.Log(_stayjudgement);
    }

    private void MHAttack()
    {
        if (_stayjudgement)
        {
            if (_inputParam.Select)
            {
                _stayjudgement = false;
                _animation.MGhHeavyAttackAnima();
                if (_attackHitDetection.attackHitTheStreamer)
                {
                    Damege();
                    count++;
                }
                //StartCoroutine(HAstay());
                count = 0;

                //Debug.Log(count);
                //Debug.Log(_attackHitDetection.attackHitTheStreamer);
            }
        }
    }
    void Damege()
    {
        if (count == 1)
        {
            //Debug.Log("1");
            _centerDataOfStreamer.stHp -= _attackHitDetection.ghAttackPower * ghAttackPower1;
        }
        else if(count == 2)
        {
            //Debug.Log("2");
            _centerDataOfStreamer.stHp -= _attackHitDetection.ghAttackPower * ghAttackPower2;
        }
        else if(count == 3)
        {
            //Debug.Log("3");
            _centerDataOfStreamer.stHp -= _attackHitDetection.ghAttackPower * ghAttackPower3;
        }
    }

    IEnumerator HAstay()
    {
        yield return new WaitForSeconds(_hastay);
        Debug.Log("stayƒJƒEƒ“ƒg‚Í"+_hastay);
        _stayjudgement = true;
        //_haAnimation = true;
    }
}
