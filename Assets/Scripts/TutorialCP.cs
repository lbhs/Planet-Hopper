using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialCP : MonoBehaviour
{
    public int CPID;
    public MeshRenderer mr;
    public Material VTMRed;
    public Material VTMGreen;
    private bool green = false;



    private void OnTriggerEnter(Collider other)
    {
        if (CPID < 3)
        {
            Scene1();
        }
    }

    void Scene1()
    {
        switch (CPID)
        {
            case 0:
                Greenify();
                break;
            case 1:
                Greenify();
                break;
            case 2:
                Greenify();
                break;
        }

        if (TutorialNavi.main.numGreen >= 3)
        {
            TutorialNavi.main.GoToTGameplay2();
        }
    }

    // FIND A WAY TO STOP PEOPLE FROM GOING THROUGH THE SAME TRIGGER!!
    void Greenify()
    {
        if (!green) {
            mr.material = VTMGreen;
            TutorialNavi.main.numGreen++;
            Debug.Log(TutorialNavi.main.numGreen); // TODO: delete me ! :)
            green = true;
        }
    }
}
