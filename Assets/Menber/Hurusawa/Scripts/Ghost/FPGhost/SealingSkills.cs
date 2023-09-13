using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SealingSkills : MonoBehaviour
{
    [SerializeField] private LightHitDetection skillObject;
    [SerializeField] private Image skillicon;
    [SerializeField] InputManager _inputManager;

    private InputManager.InputParam _inputParam;
    private bool hasskillicon = false;
    private bool hasActivatedSkill = false;
    public float skillCooldownTime = 5.0f;

    private void Update()
    {
        if (!hasActivatedSkill && _inputManager == null)
        {
            if (skillObject != null)
            {
                skillObject.enabled = false;
                Debug.Log("������܂���");
                hasActivatedSkill = true;

                StartCoroutine(StartCooldown());
            }

            if (!hasskillicon) // �t�ɕύX�Fhasskillicon��false�̏ꍇ�Ɏ��s
            {
                skillicon.enabled = true; // �t�ɕύX�F�X�L���A�C�R����\��
                Debug.Log("�X�L���A�C�R���\��");
                hasskillicon = true;

                StartCoroutine(StartCooldown());
            }
        }
    }

    private IEnumerator StartCooldown()
    {
        yield return new WaitForSeconds(skillCooldownTime);

        if (skillObject != null)
        {
            skillObject.enabled = true;
            Debug.Log("�N�[���_�E���I��");
        }

        if (hasskillicon)
        {
            skillicon.enabled = false; 
            Debug.Log("�X�L���A�C�R����\��");
            hasskillicon = false;
        }
    }
}
