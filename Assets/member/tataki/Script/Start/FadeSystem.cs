using System.Collections;
using UnityEngine;

public class FadeSystem : MonoBehaviour
{
    //inspector�ŏ������݁@�ϐ��ݒ�
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private float _fadeSpeed = 2f;
    �@//�ϐ��쐬
    private System.Action _fadeEndCallback;

    public void FadeOut(System.Action fadeEndCallback)
    {
        _fadeEndCallback = fadeEndCallback;
        StartCoroutine(FadeOutCo());
    }

    private IEnumerator FadeOutCo()
    {
        //�L�����o�X�O���[�v��alpha�l��0�ɐݒ�
        _canvasGroup.alpha = 0;
        //�L�����o�X�O���[�v��alpha�l��1�ȉ��̏ꍇ����
        while (1f > _canvasGroup.alpha)
        {
            //Time.delotaTime=�O���Update���牽�b�o�߂�����
            //�L�����o�X�O���[�v��alpha�l�𑝉������Ă���
            _canvasGroup.alpha += Time.deltaTime * _fadeSpeed;
            //�L�����o�X�O���[�v�̒l��1�ȏ�������́A1�ɂȂ�����
            if (1f < _canvasGroup.alpha) _canvasGroup.alpha = 1f;
            //�������I�������R���[�`������O���
            yield return null;
        }
        //
        if (_fadeEndCallback != null)
            _fadeEndCallback();
    }
}