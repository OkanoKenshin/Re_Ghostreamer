using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogAction : MonoBehaviour
{
    // �A�j���[�V�������Đ������ǂ����������t���O
    private bool animationPlaying = false;

    // �A�j���[�V���������s���ꂽ��֐����Ăяo��
    public void FogActionFrames()
    {
        if (!animationPlaying)
        {
            // �R���[�`���̌Ăяo���@�A�j���[�V�����Đ����t���O��ݒ�
            StartCoroutine(FogActionControl(235));
        }
    }

    // �R���[�`���J�n
    IEnumerator FogActionControl(float duration)
    {
        // �A�j���[�V�����Đ����t���O��true
        animationPlaying = true;

        // �A�j���[�V�����̍Đ��ҋ@
        yield return new WaitForSeconds(duration);

        // �A�j���[�V�������I��������Đ����t���O��false
        animationPlaying = false;
    }
}
