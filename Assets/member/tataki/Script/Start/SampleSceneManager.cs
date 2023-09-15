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
        //Play=動画再生
        _videoPlayer.Play();
        //コルーチンを呼び出す
        StartCoroutine(NextSceneMove());
<<<<<<< HEAD
        //コルーチンを呼び出してもdebug.logも同時に処理される
=======
        //�R���[�`�����Ăяo���Ă�debug.log�������ɏ��������

>>>>>>> develop
    }

    private IEnumerator NextSceneMove()
    {
        //コルーチンは非同期で動いている
        //コールチン使用・動画を再生
        yield return new WaitUntil(() => !_videoPlayer.isPlaying);
        //動画オブジェクトを表示 SetActiveオブジェクトの表示・非表示をする
        _movieViewType.gameObject.SetActive(true);
        //動画が流れ終わったらフェードアウトクラスを読み込む
        _movieViewType.ShowMovie(FadeOutScene);

    }


    private void FadeOutScene()
    {
        //setactive=オブジェクトの表示・非表示
        //フェードオブジェクトを表示
        _fadeSystemType.gameObject.SetActive(true);
        //フェードアウトが終わったらNextSceneを読み込む
        //FadeOut
        _fadeSystemType.FadeOut(NextScene);

    }

    private void NextScene()
    {
        SceneManager.LoadScene("explanation");
    }
}