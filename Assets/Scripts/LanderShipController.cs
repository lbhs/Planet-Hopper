using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanderShipController : MonoBehaviour
{

    public Rigidbody Lander;
    public bool landerLanded = false;
    public bool landingComplete = true;

    private void Start()
    {

        Lander.isKinematic = true;

    }

    // Update is called once per frame
    void Update()
    {

        if (Lander.isKinematic == false)
        {

            Lander.AddForce(0, -0.1f, 0);


            if (Input.GetKey(KeyCode.LeftArrow))
            {

                Lander.transform.Rotate(0, 0, 0.3f);

            }

            if (Input.GetKey(KeyCode.RightArrow))
            {

                Lander.transform.Rotate(0, 0, -0.3f);

            }

            if (Input.GetKey(KeyCode.UpArrow))
            {

                Lander.AddForce(transform.up * 1f);

            }

            if (landerLanded == false)
            {
                Lander.angularVelocity = new Vector3(0, 0, 0);
            }

        }
        
        

    }


}
