using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetRandomizer : MonoBehaviour
{
    private Rigidbody gm;
    [SerializeField] private int max;
    [SerializeField] private int min;

    // Start is called before the first frame update
    void Start()
    {
        gm = GetComponent<Rigidbody>();

        int x = Random.Range(min, max);
        int y = Random.Range(min, max);

        if (Random.Range(1,3) == 1)
        {
            x = x * -1;
        }

        if (Random.Range(1, 3) == 1)
        {
            y = y * -1;
        }

        gm.transform.position = new Vector3(x, y, 0);
        gm.AddForce(-y*1000, x*1000, 0);
    }

}
