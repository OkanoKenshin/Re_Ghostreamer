using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lightGauge : MonoBehaviour
{
    [SerializeField]
    private float heatGauge;
    private float maxHeatGauge = 500.0f;
    private Image _image;

    private void Start()
    {
        _image = this.GetComponent<Image>();
    }

    private void Update()
    {
        _image.fillAmount = heatGauge / maxHeatGauge;
    }
}
