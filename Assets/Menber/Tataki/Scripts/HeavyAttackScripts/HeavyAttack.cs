using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyAttack : MonoBehaviour
{
    [SerializeField] private GameObject firstHitStage;
    [SerializeField] private GameObject secondHitStage;
    [SerializeField] private GameObject thirdHitStage;


    // 攻撃ステージの基底クラス
    public abstract class AttackStage
    {
        public abstract float DamageMultiplier { get; }

        // 攻撃を実行するメソッド
        public virtual void ExecuteAttack(float baseDamage)
        {
            float finalDamage = baseDamage * DamageMultiplier;
            Debug.Log($"Damage dealt: {finalDamage}");
        }
    }

    // 初段攻撃の攻撃ステージ
    public class FirstAttackStage : AttackStage
    {
        public override float DamageMultiplier => 1.0f; // 初段攻撃のダメージ乗数
    }

    // 2段目攻撃の攻撃ステージ
    public class SecondAttackStage : AttackStage
    {
        public override float DamageMultiplier => 1.2f; // 2段目攻撃のダメージ乗数
    }

    // 3段目攻撃の攻撃ステージ
    public class ThirdAttackStage : AttackStage
    {
        public override float DamageMultiplier => 1.5f; // 3段目攻撃のダメージ乗数
    }

    // 攻撃を管理するクラス
    public class AttackManager : MonoBehaviour
    {
        //アニメーションの時間を変数へ
        private float animationTime;

        // 攻撃の実行メソッド
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
            // 攻撃ステージを実行
            _attackStage.ExecuteAttack(baseDamage);
        }

        //攻撃が初弾の攻撃フレームか判定
        private bool IsInFirstAttackFrame()
        {
            return animationTime >= 1.22f && animationTime <= 1.33f;
        }

        //2段目の攻撃フレーム判定
        private bool IsInSecondAttackFrame()
        {
            return animationTime >= 1.35f && animationTime <= 1.50f;
        }

        //3段目の攻撃フレーム判定
        private bool IsInThirdAttackFrame()
        {
            return animationTime >= 2.25 && animationTime <= 2.54;
        }
        ////攻撃当たり判定
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Streamer"))
            {
                Destroy(other.gameObject);
            }
        }
    }
}