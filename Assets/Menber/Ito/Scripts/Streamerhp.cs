using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Streamerhp : MonoBehaviour
{
    public float SThp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(SThp <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
