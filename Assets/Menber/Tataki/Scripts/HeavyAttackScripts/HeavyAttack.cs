using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyAttack : MonoBehaviour
{
    [SerializeField] private GameObject firstHitStage;
    [SerializeField] private GameObject secondHitStage;
    [SerializeField] private GameObject thirdHitStage;


    // �U���X�e�[�W�̊��N���X
    public abstract class AttackStage
    {
        public abstract float DamageMultiplier { get; }

        // �U�������s���郁�\�b�h
        public virtual void ExecuteAttack(float baseDamage)
        {
            float finalDamage = baseDamage * DamageMultiplier;
            Debug.Log($"Damage dealt: {finalDamage}");
        }
    }

    // ���i�U���̍U���X�e�[�W
    public class FirstAttackStage : AttackStage
    {
        public override float DamageMultiplier => 1.0f; // ���i�U���̃_���[�W�搔
    }

    // 2�i�ڍU���̍U���X�e�[�W
    public class SecondAttackStage : AttackStage
    {
        public override float DamageMultiplier => 1.2f; // 2�i�ڍU���̃_���[�W�搔
    }

    // 3�i�ڍU���̍U���X�e�[�W
    public class ThirdAttackStage : AttackStage
    {
        public override float DamageMultiplier => 1.5f; // 3�i�ڍU���̃_���[�W�搔
    }

    // �U�����Ǘ�����N���X
    public class AttackManager : MonoBehaviour
    {
        //�A�j���[�V�����̎��Ԃ�ϐ���
        private float animationTime;

        // �U���̎��s���\�b�h
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
            // �U���X�e�[�W�����s
            _attackStage.ExecuteAttack(baseDamage);
        }

        //�U�������e�̍U���t���[��������
        private bool IsInFirstAttackFrame()
        {
            return animationTime >= 1.22f && animationTime <= 1.33f;
        }

        //2�i�ڂ̍U���t���[������
        private bool IsInSecondAttackFrame()
        {
            return animationTime >= 1.35f && animationTime <= 1.50f;
        }

        //3�i�ڂ̍U���t���[������
        private bool IsInThirdAttackFrame()
        {
            return animationTime >= 2.25 && animationTime <= 2.54;
        }
        ////�U�������蔻��
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Streamer"))
            {
                Destroy(other.gameObject);
            }
        }
    }
}