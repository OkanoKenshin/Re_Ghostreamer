using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FGGhostLife : MonoBehaviour
{
    int previousFrameHp;

    [SerializeField]
    GameObject CenterDataOfFGGhostObject;
    CenterDataOfFGGhost _centerDataOfFGGhost;
    public float maxHP;
    private Image _image;

  

    private void Awake()
    {
        if (CenterDataOfFGGhostObject != null)
        {
            _centerDataOfFGGhost = CenterDataOfFGGhostObject.GetComponent<CenterDataOfFGGhost>();

            if (_centerDataOfFGGhost == null)
            {
                Debug.LogError("CenterDataOfFGGhostコンポーネントが見つかりません。");
            }
        }
    }

    void Start()
    {
        _image = this.GetComponent<Image>();
        maxHP = _centerDataOfFGGhost.fgGhHp;
    }

    private void FixedUpdate()
    {
        if (previousFrameHp != _centerDataOfFGGhost.fgGhHp)
        {
            _image.fillAmount = (float)_centerDataOfFGGhost.fgGhHp / maxHP;
        }
    }
}
