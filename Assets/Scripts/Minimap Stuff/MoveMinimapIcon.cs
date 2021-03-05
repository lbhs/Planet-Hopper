using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMinimapIcon : MonoBehaviour
{
    public GameObject Planet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(Planet.transform.position.x, Planet.transform.position.y, Planet.transform.position.z - 50);
    }
}
