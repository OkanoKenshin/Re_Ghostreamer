using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HAGhostLife : MonoBehaviour
{
    int previousFrameHp;

    [SerializeField]
    GameObject CenterDataOfHAGhost;
    CenterDataOfHAGhost _centerDataOfHAGhost;
    public float maxHP;
    private Image _image;

  

    private void Awake()
    {
        if (CenterDataOfHAGhost != null)
        {
            _centerDataOfHAGhost = CenterDataOfHAGhost.GetComponent<CenterDataOfHAGhost>();

            if (_centerDataOfHAGhost == null)
            {
                Debug.LogError("CenterDataOfFGGhostコンポーネントが見つかりません。");
            }
        }
    }

    void Start()
    {
        _image = this.GetComponent<Image>();
        maxHP = _centerDataOfHAGhost.haGhHp;
    }

    private void FixedUpdate()
    {
        if (previousFrameHp != _centerDataOfHAGhost.haGhHp)
        {
            _image.fillAmount = (float)_centerDataOfHAGhost.haGhHp / maxHP;
        }
    }
}
