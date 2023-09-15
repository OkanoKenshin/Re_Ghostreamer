using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class stamina : MonoBehaviour
{
    int previousFrameHp;

    [SerializeField]
    GameObject CenterDataOfStreamer;
    CenterDataOfStreamer _centerDataOfStreamer;
    public float maxStamina;
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
        maxStamina = _centerDataOfStreamer.stBaseStamina;
    }

    private void FixedUpdate()
    {
        if (previousFrameHp != _centerDataOfStreamer.stBaseStamina)
        {
            _image.fillAmount = (float)_centerDataOfStreamer.stBaseStamina / maxStamina;
        }
    }
}
