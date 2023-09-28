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

    [SerializeField]
    CenterDataOfStreamer _centerDataOfStreamer;

    [SerializeField]
    private AttackHitDetection _attackHitDetection;

    public GameObject timecon;
    private TimeCounterHAG timeCounterhag;

    [SerializeField]
    float ghAttackPower1 = 0f;
    [SerializeField]
    float ghAttackPower2 = 0f;
    [SerializeField]
    float ghAttackPower3 = 0f;

    [SerializeField]
    bool InputOn = false;

    int hagcount;

    // Start is called before the first frame update
    void Start()
    {
        timeCounterhag = timecon.GetComponent<TimeCounterHAG>();
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
    }

    private void Update()
    {
        if (_inputParam.Ability)
        {
            if (hagcount == 0)
            {
                if (timeCounterhag.currentTime >= timeCounterhag.totalTime)
                {
                    _animation.MGhHeavyAttackAnima();
                    if (_attackHitDetection.attackHitTheStreamer)
                    {
                        //Debug.Log("baka");
                        Damege();
                        count++;
                    }
                }
            }
        }
        //Debug.Log(count);
        //Debug.Log(_attackHitDetection.attackHitTheStreamer);
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
            hagcount++;
        }
    }
}
