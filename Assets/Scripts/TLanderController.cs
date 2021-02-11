using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TLanderController : MonoBehaviour
{

    public static TLanderController main;
    private bool active;

    public Rigidbody lander;

    // Start is called before the first frame update
    void Start()
    {
        main = this;
        active = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!active)
        {
            return;
        }

        lander.AddForce(0, -0.1f, 0);


        if (Input.GetKey(KeyCode.LeftArrow))
        {

            lander.transform.Rotate(0, 0, 0.3f);

        }

        if (Input.GetKey(KeyCode.RightArrow))
        {

            lander.transform.Rotate(0, 0, -0.3f);

        }

        if (Input.GetKey(KeyCode.UpArrow))
        {

            lander.AddForce(lander.transform.up * 0.2f);

        }
    }

    public void StartLanderMotion()
    {
        Debug.Log("Lander Activated");
        active = true;
    }


}
