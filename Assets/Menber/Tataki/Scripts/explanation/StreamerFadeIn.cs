using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StreamerFadeIn : MonoBehaviour
{
    public GameObject Panelfade;   // �t�F�[�h�p�l���̎擾

    Image fadealpha;               // �t�F�[�h�p�l���̃C���[�W�擾�ϐ�

    private float alpha = 1f;      // �p�l���̏���alpha�l��1�ɐݒ�

    private bool fadein = true;    // �t�F�[�h�C���̃t���O�ϐ�

    public int SceneNo;            // �V�[���̈ړ���i���o�[�擾�ϐ�

    public float fadeSpeed = 0.01f; // �t�F�[�h�C���̑��x

    // Use this for initialization
    void Start()
    {
        fadealpha = Panelfade.GetComponent<Image>(); // �p�l���̃C���[�W�擾

        // ������Ԃ����S�ɕs�����ɐݒ�
        fadealpha.color = new Color(0, 0, 0, alpha);
    }

    // Update is called once per frame
    void Update()
    {
        if (fadein)
        {
            FadeIn();
        }
    }

    void FadeIn()
    {
        alpha -= fadeSpeed; // �����x�����������ăt�F�[�h�C��
        fadealpha.color = new Color(0, 0, 0, alpha);

        if (alpha <= 0)
        {
            fadein = false;
        }
    }
}
