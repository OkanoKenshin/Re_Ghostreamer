using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPGhDamageEffect : MonoBehaviour
{
    [SerializeField]
    CenterDataOfFPGhost cdop;

    float fpBaseHp;

    [SerializeField]
    GameObject obj;

    [SerializeField]
    ParticleSystem particle;
    [SerializeField]
    ParticleSystem particle2;
    [SerializeField]
    ParticleSystem particle3;

    private ParticleSystem.MainModule main;
    private ParticleSystem.MainModule main2;
    private ParticleSystem.MainModule main3;

    float alpha;

    // Start is called before the first frame update
    void Start()
    {
        if(cdop == null)
        {
            cdop= GetComponent<CenterDataOfFPGhost>();
        }
        fpBaseHp = cdop.fpGhHp;
        obj.SetActive(false);
        main = particle.main;
        main2 = particle2.main;
        main3 = particle3.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (cdop.fpGhHp > 200 && cdop.fpGhHp < fpBaseHp)
        {
            obj.SetActive(true);
            main.startColor = new ParticleSystem.MinMaxGradient(new Color(0.2f, 0.2f, 0.2f, alpha));
            main2.startColor = new ParticleSystem.MinMaxGradient(new Color(0.25f, 0.25f, 0.25f, alpha));
            main3.startColor = new ParticleSystem.MinMaxGradient(new Color(0.05f, 0.05f, 0.05f, alpha));
        }
        else if(cdop.fpGhHp <= 200)
        {
            main.startColor = new ParticleSystem.MinMaxGradient(new Color(0.2f, 0.2f, 0.2f, 1));
            main2.startColor = new ParticleSystem.MinMaxGradient(new Color(0.25f, 0.25f, 0.25f, 0.23f));
            main3.startColor = new ParticleSystem.MinMaxGradient(new Color(0.05f, 0.05f, 0.05f, 0.3f));
        }
    }
}
