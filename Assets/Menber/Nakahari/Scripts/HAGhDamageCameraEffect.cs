using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HAGhDamageCameraEffect : MonoBehaviour
{
    GlitchFx gf;

    [SerializeField]
    CenterDataOfHAGhost cdoh;

    float haBaseHp;

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

        if (cdoh == null)
        {
            cdoh = GetComponent<CenterDataOfHAGhost>();
        }

        haBaseHp = cdoh.haGhHp;
        gf.intensity = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (cdoh.haGhHp < haBaseHp)
        {
            gf.intensity = Value;
            StartCoroutine(Effect());
            haBaseHp = cdoh.haGhHp;
        }
    }

    IEnumerator Effect()
    {
        yield return new WaitForSeconds(time);
        gf.intensity = 0;
    }
}
