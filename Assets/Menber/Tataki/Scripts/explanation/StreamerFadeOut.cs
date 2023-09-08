using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StreamerFadeOut : MonoBehaviour
{
    public GameObject Panelfade;   //�t�F�[�h�p�l���̎擾

    Image fadealpha;               //�t�F�[�h�p�l���̃C���[�W�擾�ϐ�

    private float alpha;           //�p�l����alpha�l�擾�ϐ�

    private bool fadeout;          //�t�F�[�h�A�E�g�̃t���O�ϐ�

    public int SceneNo;            //�V�[���̈ړ���i���o�[�擾�ϐ�

    public float delayBeforeFade = 5f;//�t�F�[�h�A�E�g�O�̑ҋ@����

    // Use this for initialization
    void Start()
    {
        fadealpha = Panelfade.GetComponent<Image>(); //�p�l���̃C���[�W�擾
        alpha = fadealpha.color.a;                 //�p�l����alpha�l���擾
        StartCoroutine(StartFadeAfterDelay());
    }

    // Update is called once per frame
    void Update()
    {
        if (fadeout == true)
        {
            FadeOut();
        }
    }

    void FadeOut()
    {
        alpha += 0.01f;
        fadealpha.color = new Color(0, 0, 0, alpha);
        if (alpha >= 1)
        {
            fadeout = false;
            SceneManager.LoadScene("InGame");
        }
    }

    public void fadeOut()
    {
        fadeout = true;
    }

    IEnumerator StartFadeAfterDelay()
    {
        yield return new WaitForSeconds(delayBeforeFade);
        fadeOut(); // �t�F�[�h�A�E�g���J�n
    }
}
