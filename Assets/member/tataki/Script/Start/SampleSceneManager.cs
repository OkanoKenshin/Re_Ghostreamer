using System.Collections;

using System.Collections.Generic;

using UnityEngine;

using UnityEngine.SceneManagement;

using UnityEngine.Video;

 

public class SampleSceneManager : MonoBehaviour

{

    [SerializeField] private MovieViewType _movieViewType;

    [SerializeField] private FadeSystem _fadeSystemType;

    [SerializeField] private VideoPlayer _videoPlayer;

    public void OnNextSceneButton()

    {

        //Play=����Đ�

        _videoPlayer.Play();

        //�R���[�`�����Ăяo��

        StartCoroutine(NextSceneMove());

        //�R���[�`�����Ăяo���Ă�debug.log�������ɏ��������



    }



    private IEnumerator NextSceneMove()

    {

        //�R���[�`���͔񓯊��œ����Ă���

        //�R�[���`���g�p�E������Đ�

        yield return new WaitUntil(() => !_videoPlayer.isPlaying);

        //����I�u�W�F�N�g��\�� SetActive�I�u�W�F�N�g�̕\���E��\��������

        _movieViewType.gameObject.SetActive(true);

        //���悪����I�������t�F�[�h�A�E�g�N���X��ǂݍ���

        _movieViewType.ShowMovie(FadeOutScene);



    }





    private void FadeOutScene()

    {

        //setactive=�I�u�W�F�N�g�̕\���E��\��

        //�t�F�[�h�I�u�W�F�N�g��\��

        _fadeSystemType.gameObject.SetActive(true);

        //�t�F�[�h�A�E�g���I�������NextScene��ǂݍ���

        //FadeOut

        _fadeSystemType.FadeOut(NextScene);



    }



    private void NextScene()

    {

        SceneManager.LoadScene("explanation");

    }

}