using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyAttack : MonoBehaviour
{
    [SerializeField] private GameObject firstHitStage;
    [SerializeField] private GameObject secondHitStage;
    [SerializeField] private GameObject thirdHitStage;


    // UXe[WΜξκNX
    public abstract class AttackStage
    {
        public abstract float DamageMultiplier { get; }

        // Uπΐs·ι\bh
        public virtual void ExecuteAttack(float baseDamage)
        {
            float finalDamage = baseDamage * DamageMultiplier;
            Debug.Log($"Damage dealt: {finalDamage}");
        }
    }

    // iUΜUXe[W
    public class FirstAttackStage : AttackStage
    {
        public override float DamageMultiplier => 1.0f; // iUΜ_[Wζ
    }

    // 2iΪUΜUXe[W
    public class SecondAttackStage : AttackStage
    {
        public override float DamageMultiplier => 1.2f; // 2iΪUΜ_[Wζ
    }

    // 3iΪUΜUXe[W
    public class ThirdAttackStage : AttackStage
    {
        public override float DamageMultiplier => 1.5f; // 3iΪUΜ_[Wζ
    }

    // UπΗ·ιNX
    public class AttackManager : MonoBehaviour
    {
        //Aj[VΜΤπΟΦ
        private float animationTime;

        // UΜΐs\bh
        public void MAbilityOfHeavyAttack(float baseDamage)
        {

            AttackStage _attackStage = null;

            if (IsInFirstAttackFrame())
            {
                Debug.Log("1");
                _attackStage = new FirstAttackStage();
            }
            else if (IsInSecondAttackFrame())
            {
                Debug.Log("2");
                _attackStage = new SecondAttackStage();
            }
            else if (IsInThirdAttackFrame())
            {
                Debug.Log("3");
                _attackStage = new ThirdAttackStage();
            }
            // UXe[Wπΐs
            _attackStage.ExecuteAttack(baseDamage);
        }

        //UͺeΜUt[©»θ
        private bool IsInFirstAttackFrame()
        {
            return animationTime >= 1.22f && animationTime <= 1.33f;
        }

        //2iΪΜUt[»θ
        private bool IsInSecondAttackFrame()
        {
            return animationTime >= 1.35f && animationTime <= 1.50f;
        }

        //3iΪΜUt[»θ
        private bool IsInThirdAttackFrame()
        {
            return animationTime >= 2.25 && animationTime <= 2.54;
        }
        ////U½θ»θ
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Streamer"))
            {
                Destroy(other.gameObject);
            }
        }
    }
}

//1:22~1:33ͺfirst
//1:35~1:50 second
//2:25~2:54 third