using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Staremaerbutton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StreamerClick()
    {
        SceneManager.LoadScene("testcamera");
        Display.displays[2].Activate();
    }
}
