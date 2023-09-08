using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sampleexit : MonoBehaviour
{
    public GameObject _staratcanvas;
    bool _NObutton;

    public void Pushs()
    {
        _NObutton = true;
    }
    public void noPushs()
    {
        _NObutton = false;
    }

    void Update()
    {
        if (_NObutton)
        {
            _staratcanvas.SetActive(false);
            Debug.Log("Push");

        }
    }
}
