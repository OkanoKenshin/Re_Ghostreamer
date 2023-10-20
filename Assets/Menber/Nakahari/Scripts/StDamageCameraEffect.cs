using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StDamageCameraEffect : MonoBehaviour
{
    [SerializeField]
    CenterDataOfStreamer cdos;

    float stBaseHp;

    [SerializeField]
    Image image;

    Color color;

    [SerializeField]
    float time;
    // Start is called before the first frame update
    void Start()
    {
        if(image == null)
        {
            image = GetComponent<Image>();
        }
        if(cdos == null)
        {
            cdos = GetComponent<CenterDataOfStreamer>();
        }
        stBaseHp = cdos.stHp;
        image.enabled = false;
        color.r = 1f;
        color.g = 1f;
        color.b = 1f;
        color.a = 0.2f;
        image.color = color;
    }

    // Update is called once per frame
    void Update()
    {
        if (cdos.stHp < stBaseHp)
        {
            image.enabled = true;
            if (color.a >= 0f)
            {
                color.a -= 0.005f;
                image.color = color;
                return;
            }
            stBaseHp = cdos.stHp;
            if(color.a <= 0)
            {
                image.enabled = false;
                color.a = 0.2f;
            }
        }
    }
}
