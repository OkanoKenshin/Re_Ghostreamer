using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StreamerFadeOut : MonoBehaviour
{
    public GameObject Panelfade;   // �t�F�[�h�p�̃p�l���I�u�W�F�N�g

    Image fadealpha;               // �p�l����Image�R���|�[�l���g

    private float alpha;           // �p�l���̃A���t�@�l

    private bool fadeout;          // �t�F�[�h�A�E�g�����ǂ����̃t���O

    public int SceneNo;            // �ړ���V�[���̔ԍ�

    public float delayBeforeFade = 5f; // �t�F�[�h�J�n�܂ł̑ҋ@����

    // ������
    void Start()
    {
         // �p�l����Image�R���|�[�l���g���擾
        fadealpha = Panelfade.GetComponent<Image>();
        // �A���t�@�l��������
        alpha = fadealpha.color.a;
        // �ҋ@���Ԍ�Ƀt�F�[�h���J�n����R���[�`�����J�n
        StartCoroutine(StartFadeAfterDelay());
    }

    // �X�V����
    void Update()
    {
        if (fadeout == true)
        {
            // �t�F�[�h�A�E�g���������s
            FadeOut();
        }
    }

    // �t�F�[�h�A�E�g����
    void FadeOut()
    {
        // �A���t�@�l�����������₷
        alpha += 0.01f;
        // �p�l���̃A���t�@�l���X�V
        fadealpha.color = new Color(0, 0, 0, alpha);

        if (alpha >= 1)
        {
            // �t�F�[�h�A�E�g�I��
            fadeout = false;
            // �w��̃V�[���Ɉړ�
            SceneManager.LoadScene("InGame"); 
        }
    }

    // �t�F�[�h�A�E�g���J�n���邽�߂̊O������Ăяo�����\�b�h
    // �t�F�[�h�A�E�g���J�n����t���O��ݒ�
    public void StartFadeOut()
    {
        fadeout = true;
    }

    // �ҋ@���Ԍ�Ƀt�F�[�h���J�n����R���[�`��
    IEnumerator StartFadeAfterDelay()
    {
        // �ҋ@����
        yield return new WaitForSeconds(delayBeforeFade);
        // �t�F�[�h���J�n
        StartFadeOut();
    }
}

