using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPosChange : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject lightPos;
    [SerializeField]
    private float adjustY;
    [SerializeField]
    private float adjustX;
    [SerializeField]
    private float adjustZ;
    Vector3 newLightPos;

    // Update is called once per frame
    void Update()
    {
        newLightPos = new Vector3(lightPos.transform.position.x + adjustX, lightPos.transform.position.y + adjustY, lightPos.transform.position.z + adjustZ);
        this.transform.position = newLightPos;

    }
}
