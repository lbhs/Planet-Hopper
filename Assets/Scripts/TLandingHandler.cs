using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TLandingHandler : MonoBehaviour
{
    public static TLandingHandler main;
    public GameObject ship;
    public GameObject earth;
    public GameObject lunarLanderGame;

    public Text tutorialText;
    private int buttonPresses;

    // Start is called before the first frame update
    void Start()
    {
        main = this;

        // freeze the scene
        Time.timeScale = 0;

        // button gets pressed ... (`LaunchShip`)
    }

    public void ButtonAction()
    {
        if (buttonPresses == 0)
        {
            buttonPresses++;
            LaunchShip();
        }
        else
        {
            SwitchScene();
        }
    }

    private void LaunchShip()
    {
        // unfreeze the scene
        Time.timeScale = 1;

        StartCoroutine(TShipController.main.Launch());
        

        // on trigger enter ... (reference TutorialCP.cs:15)
        return;
    }

    public void SetupLanding()
    {   
        // destroys ship / earth
        Destroy(ship);
        Destroy(earth);

        // teleport the LL area over
        lunarLanderGame.transform.position += 25 * Vector3.left;


        // freeze the scene
        //Time.timeScale = 0;

        tutorialText.text = "Feel free to use the space below to get used to the lunar lander's movement. When you are ready to move on to the next tutorial, click continue below.";

        // button gets pressed ... (`StartLunarLander`)


        TLanderController.main.StartLanderMotion();

        return;
    }

    //private void StartLunarLander()
    //{
    //    // unfreezes the scene
    //    //Time.timeScale = 1;

    //    // user plays out the LL game
    //    TLanderController.main.StartLanderMotion();

    //    // on landing ... ?? Pit stop ?
    //    return;
    //}

    void SwitchScene()
    {
        TutorialNavi.main.GoToTGameplay3();
    }

}
