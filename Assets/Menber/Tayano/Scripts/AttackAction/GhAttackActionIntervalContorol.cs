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
    // Start is called before the first frame update
    void Start()
    {
        if (_attackHitDetection == null)
        {
            _attackHitDetection = GetComponent<AttackHitDetection>();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(InputOn && ghCanAttack)
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
