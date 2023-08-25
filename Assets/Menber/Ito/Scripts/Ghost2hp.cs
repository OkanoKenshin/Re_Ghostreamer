using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost2hp : MonoBehaviour
{
    public float GH2hp;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GH2hp <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
