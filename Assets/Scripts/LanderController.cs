using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanderController : MonoBehaviour
{
    public bool isInScene;
    public Rigidbody lander;
    // Start is called before the first frame update
    void Start()
    {
        isInScene = false;
    }

    public void toggleIsInScene()
    {
        if (isInScene == false)
        {
            isInScene = true;
            lander.isKinematic = false;
        }
        else
        {
            isInScene = false;
            lander.isKinematic = true;
        }
    }
    void FixedUpdate()
    {
        if (isInScene == false)
        {
            return;
        }
        else
        {
                lander.AddForce(0, -0.5f, 0);
                if (Input.GetKey(KeyCode.LeftArrow))
                {

                    lander.transform.Rotate(0, 0, 1f);

                }

                if (Input.GetKey(KeyCode.RightArrow))
                {

                    lander.transform.Rotate(0, 0, -1f);

                }

                if (Input.GetKey(KeyCode.UpArrow))
                {

                    lander.AddForce(lander.transform.up * 1f);
            }
        }
    }
}