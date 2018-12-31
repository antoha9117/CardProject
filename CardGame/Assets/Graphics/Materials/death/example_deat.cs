using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class example_deat : MonoBehaviour {

    public Material izmmat;
    public float i = 1;
    public float v = 0.001f;

    // Use this for initialization
    void Start()
    {
        v = 0.5f;

    }

    // Update is called once per frame
    void Update()
    {
        if (i > 0)
            i -= Time.deltaTime * v;
        else
            i = 1;
        izmmat.SetFloat("Vector1_EA99F36D", i);
    }
}
