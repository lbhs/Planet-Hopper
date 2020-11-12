using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{


    [SerializeField] public float G;

    [SerializeField] public float InitialDistance;

    private void Start()
    {
        int RandomInt = Random.Range(1, 5);

        float xDistance = Random.Range(0, InitialDistance + 1);
        float yDistance = Mathf.Sqrt(Mathf.Pow(InitialDistance, 2) - Mathf.Pow(xDistance, 2));
        Debug.Log(Mathf.Pow(xDistance, 2) + Mathf.Pow(yDistance, 2));
        float initialAngle = Mathf.Atan(yDistance / xDistance) * (180 / Mathf.PI);
        Debug.Log(initialAngle);
        float finalAngle = 0;


        if (RandomInt == 1)
        {
            xDistance = xDistance;
            yDistance = yDistance;
            finalAngle = initialAngle + 90;
        }

        if (RandomInt == 2)
        {
            xDistance = xDistance * -1;
            yDistance = yDistance;
            finalAngle = 90 + (90 - initialAngle) + 90;
        }

        if (RandomInt == 3)
        {
            xDistance = xDistance * -1;
            yDistance = yDistance * -1;
            finalAngle = 180 + (90 - initialAngle) + 90;
        }

        if (RandomInt == 4)
        {
            xDistance = xDistance;
            yDistance = yDistance * -1;
            finalAngle = 270 + (90 - initialAngle) + 90 ;
        }

        this.GetComponent<Rigidbody>().position = new Vector3(xDistance, yDistance, 0);

        Debug.Log(finalAngle);
        this.transform.rotation = Quaternion.AngleAxis(finalAngle, transform.forward);
        this.GetComponent<Rigidbody>().velocity = transform.right * Mathf.Sqrt((G * GameObject.Find("Sun").GetComponent<Rigidbody>().mass) / InitialDistance);
        Debug.Log(this.GetComponent<Rigidbody>().rotation);
        Debug.Log(this.GetComponent<Rigidbody>().velocity);

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Attract(this.GetComponent<Rigidbody>());
    }

    void Attract(Rigidbody objToAttract)
    {

        Vector3 direction = GameObject.Find("Sun").GetComponent<Rigidbody>().position - this.GetComponent<Rigidbody>().position;
        float distance = direction.magnitude;

        float forceMagnitude = (G * GameObject.Find("Sun").GetComponent<Rigidbody>().mass * this.GetComponent<Rigidbody>().mass) / Mathf.Pow(distance, 2);
        Vector3 force = direction.normalized * forceMagnitude;

        this.GetComponent<Rigidbody>().AddForce(force);

    }

}

