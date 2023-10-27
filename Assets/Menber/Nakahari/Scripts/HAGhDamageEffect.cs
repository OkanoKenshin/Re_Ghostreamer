using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HAGhDamageEffect : MonoBehaviour
{
    [SerializeField]
    CenterDataOfHAGhost cdoh;

    float haBaseHp;

    [SerializeField]
    GameObject obj;

    [SerializeField]
    float time;

    // Start is called before the first frame update
    void Start()
    {
        if(cdoh == null)
        {
            cdoh= GetComponent<CenterDataOfHAGhost>();
        }
        haBaseHp = cdoh.haGhHp;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (cdoh.haGhHp < haBaseHp)
        {
            StartCoroutine(Effect());
            haBaseHp = cdoh.haGhHp;
        }
        else
        {
            obj.SetActive(false);
        }
    }

    IEnumerator Effect()
    {
        obj.SetActive(true);
        yield return new WaitForSeconds(time);
    }
}
