using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StDamageEffect : MonoBehaviour
{
    [SerializeField]
    CenterDataOfStreamer cdos;

    float stBaseHp;

    [SerializeField]
    GameObject obj;

    [SerializeField]
    float time;

    // Start is called before the first frame update
    void Start()
    {
        if(cdos == null)
        {
            cdos = GetComponent<CenterDataOfStreamer>();
        }
        stBaseHp = cdos.stHp;
    }

    // Update is called once per frame
    void Update()
    {
        if(cdos.stHp < stBaseHp)
        {
            obj.SetActive(true);
            obj.transform.position = this.transform.position;
            obj.transform.rotation = this.transform.rotation;
            StartCoroutine(Time());
            stBaseHp =cdos.stHp;
        }
    }

    IEnumerator Time()
    {
        yield return new WaitForSeconds(time);
        obj.SetActive(false);
    }
}
