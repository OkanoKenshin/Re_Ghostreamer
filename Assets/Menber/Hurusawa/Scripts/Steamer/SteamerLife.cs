using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SteamerLife : MonoBehaviour
{
    int previousFrameHp;

    [SerializeField]
    GameObject CenterDataOfStreamer;
    CenterDataOfStreamer _centerDataOfStreamer;
    public float maxHP;
    private Image _image;

  

    private void Awake()
    {
        if (CenterDataOfStreamer != null)
        {
            _centerDataOfStreamer = CenterDataOfStreamer.GetComponent<CenterDataOfStreamer>();

            if (_centerDataOfStreamer == null)
            {
                Debug.LogError("CenterDataOfFGGhostコンポーネントが見つかりません。");
            }
        }
    }

    void Start()
    {
        _image = this.GetComponent<Image>();
        maxHP = _centerDataOfStreamer.stHp;
    }

    private void FixedUpdate()
    {
        if (previousFrameHp != _centerDataOfStreamer.stHp)
        {
            _image.fillAmount = (float)_centerDataOfStreamer.stHp / maxHP;
        }
    }
}
