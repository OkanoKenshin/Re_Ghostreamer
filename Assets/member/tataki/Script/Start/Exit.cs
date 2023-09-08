using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Exit : MonoBehaviour
{
    public Button _start;
    public Button _exitbutton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
     public void OnClick()
    {
        _start.interactable = true;
        _exitbutton.interactable = true;
        _start.Select();
    }
}
