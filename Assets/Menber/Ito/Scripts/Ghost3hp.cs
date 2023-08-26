using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost3hp : MonoBehaviour
{
    public float GH3hp;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GH3hp <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
