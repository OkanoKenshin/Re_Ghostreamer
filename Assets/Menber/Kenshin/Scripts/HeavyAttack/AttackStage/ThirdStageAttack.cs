using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdStageAttack : AttackStage
{
    float thirdStage = 2.0f;
    public override float DamageMultiplier => thirdStage;
}
