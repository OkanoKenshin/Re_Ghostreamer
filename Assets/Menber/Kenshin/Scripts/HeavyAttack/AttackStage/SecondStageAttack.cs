using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondStageAttack : AttackStage
{
    float secondStage = 0.25f;
    public override float DamageMultiplier => secondStage;
}
