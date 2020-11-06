using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : MonoBehaviour
{
    private Material M;
    private Color color;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        M = this.GetComponent<MeshRenderer>().material;
        color = M.color;
//        color.a = ;
        M.color = color;
//        while color.a != 1
//        {
 //           color.a = color.a + .1f
 //       }

        
    }
}
