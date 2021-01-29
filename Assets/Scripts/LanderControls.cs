using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanderControls : MonoBehaviour
{

    public Rigidbody Lander;
    public bool isCollided;

    private void Start()
    {
        Lander.isKinematic = true;
        isCollided = false;
    }

    // Update is called once per frame
    void Update()
    {


        if (isCollided == false)
        {
            Lander.angularVelocity = new Vector3(0, 0, 0);
        }
        
        if (isCollided == true)
        {
            Lander.angularVelocity = Lander.angularVelocity;
        }

        if (Lander.isKinematic == false)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                Lander.AddForce(transform.up * 1);
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                Lander.transform.Rotate(0, 0, 0.3f, Space.Self);
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                Lander.transform.Rotate(0, 0, -0.3f, Space.Self);
            }
        }


        Lander.AddForce(0, -0.1f, 0);
        
    }

    private void OnCollisionEnter(Collision collision)
    {

        isCollided = true;

    }

    private void OnCollisionExit(Collision collision)
    {

        isCollided = false;

    }
}
