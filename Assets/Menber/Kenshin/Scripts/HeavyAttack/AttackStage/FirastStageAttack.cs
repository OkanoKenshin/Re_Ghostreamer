using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirastStageAttack : AttackStage
{
    float firstStage = 0.25f;
    public override float DamageMultiplier => firstStage;
}
