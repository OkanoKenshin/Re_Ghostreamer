using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FPGhostLife : MonoBehaviour
{
    int previousFrameHp;

    [SerializeField]
    GameObject CenterDataOfFPGhost;
    CenterDataOfFPGhost _centerDataOfFPGhost;
    public float maxHP;
    private Image _image;

  

    private void Awake()
    {
        if (CenterDataOfFPGhost != null)
        {
            _centerDataOfFPGhost = CenterDataOfFPGhost.GetComponent<CenterDataOfFPGhost>();

            if (_centerDataOfFPGhost == null)
            {
                Debug.LogError("CenterDataOfFGGhostコンポーネントが見つかりません。");
            }
        }
    }

    void Start()
    {
        _image = this.GetComponent<Image>();
        maxHP = _centerDataOfFPGhost.fpGhHp;
    }

    private void FixedUpdate()
    {
        if (previousFrameHp != _centerDataOfFPGhost.fpGhHp)
        {
            _image.fillAmount = (float)_centerDataOfFPGhost.fpGhHp / maxHP;
        }
    }
}
