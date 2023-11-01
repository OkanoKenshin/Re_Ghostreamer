using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPGhDamageCameraEffect : MonoBehaviour
{
    GlitchFx gf;

    [SerializeField]
    CenterDataOfFPGhost cdop;

    float fpBaseHp;

    [SerializeField]
    float Value;

    [SerializeField]
    float time;

    //[SerializeField]
    //LightHitDetection lhd;

    // Start is called before the first frame update
    void Start()
    {
        if (gf == null)
        {
            gf = GetComponent<GlitchFx>();
        }

        //if (lhd == null)
        //{
        //    lhd = GetComponent<LightHitDetection>();
        //}

        if (cdop == null)
        {
            cdop = GetComponent<CenterDataOfFPGhost>();
        }
        fpBaseHp = cdop.fpGhHp;
        gf.intensity = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (cdop.fpGhHp < fpBaseHp)
        {
            gf.intensity = Value;
            StartCoroutine(Effect());
            fpBaseHp = cdop.fpGhHp;
        }
    }
    IEnumerator Effect()
    {
        yield return new WaitForSeconds(time);
        gf.intensity = 0;
    }

}
