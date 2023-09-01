/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyAttack : MonoBehaviour
{
    [SerializeField]
    private firstHitStage;
	[SerializeField]
    private secondHitStage;
	[SerializeField]
    private thirdHitStage;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public float MHeavyAttack(float baseDamege)
    {
        float deltaTime = Time.time - _attackTImeStamp;
        AttackStage _attackStage;

        if (deltaTime <= firstHitStage)
        {
            _attackStage = new FirstStageAttack();
            return _attackStage;
        }
        else if (deltaTime > firstHitStage && deltaTime <= secondHitStage)
        {
            _attackStage = new SecondStageAttack();
        }
        else if (deltaTime > firstHitStage && deltaTime <= thierdHitStage)
        {
            _attackStage = new ThirdStageAttack();
        }
        else
        {
            continue;
        }
    }
}
*/