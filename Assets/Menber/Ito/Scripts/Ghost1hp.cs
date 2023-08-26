using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost1hp : MonoBehaviour
{
    public float GH1hp;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GH1hp <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
