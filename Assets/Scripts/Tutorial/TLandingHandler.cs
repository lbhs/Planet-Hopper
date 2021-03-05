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
        else if (buttonPresses == 1)
        {
            buttonPresses++;
            StartLunarLander();
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
        Time.timeScale = 0;

        tutorialText.text = "The Lunar Lander uses the same controls as the Starship– the arrow keys. \n\nWhen you are ready to test out the lander, click continue below.";

        // button gets pressed ... (`StartLunarLander`)

        return;
    }

    private void StartLunarLander()
    {
        // unfreezes the scene
        Time.timeScale = 1;

        tutorialText.text = "Feel free to use this space to get used to the Lunar Lander's movement. Note: in an actual game of Planet Hopper, you must land under a certain speed or you will crash! \n\nWhen you are ready to move on to the next tutorial, click continue below.";

        // user plays out the LL game
        TLanderController.main.StartLanderMotion();

        // on landing ... ?? Pit stop ?
        return;
    }

    void SwitchScene()
    {
        TutorialNavi.main.GoToTGameplay3();
    }

}
