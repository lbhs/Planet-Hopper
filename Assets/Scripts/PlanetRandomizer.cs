using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetRandomizer : MonoBehaviour
{
    private Rigidbody gm;


    // Start is called before the first frame update
    void Start()
    {
        gm = GetComponent<Rigidbody>();

        int x = Random.Range(-10, 10);
        int y = Random.Range(-10, 10);

        gm.transform.position = new Vector3(x, y, 0);
        gm.AddForce(-y*25, x*25, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
