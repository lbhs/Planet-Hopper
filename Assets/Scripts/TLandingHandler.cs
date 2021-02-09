using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TLandingHandler : MonoBehaviour
{
    public static TLandingHandler main;
    public GameObject ship;

    // Start is called before the first frame update
    void Start()
    {
        main = this;

        // freeze the scene
        Time.timeScale = 0;

        // button gets pressed ... (`Launch1`)
    }

    public void Launch1()
    {
        // unfreeze the scene
        Time.timeScale = 1;

        StartCoroutine(TShipController.main.Launch());
        

        // on trigger enter ... (reference TutorialCP.cs:15)
        return;
    }

    public void StartLanding()
    {
        Debug.Log("I WORK!!!");
        // teleport to the LL area

        // freeze the scene

        // button gets pressed ... (`Launch2`)
        return;
    }

    void Launch2()
    {
        // unfreezes the scene

        // user plays out the LL game

        // on landing ... ?? Pit stop ?
        return;
    }

    public void EndLandingTutorial()
    {
        // freeze the scene

        // tutorial text changes

        // button gets pressed ... (`SwitchScene`)
    }

    void SwitchScene()
    {
        TutorialNavi.main.GoToTitle();
    }

}
