using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TUIController : MonoBehaviour
{
    public Text tText;
    public Image tImage;

    public Image tImage2;
    private int buttonPresses;



    // Start is called before the first frame update
    void Start()
    {
        buttonPresses = 0;
    }

    public void ButtonAction()
    {
        if (buttonPresses == 0)
        {
            tText.text = "While in this menu, you can click on a planet to bring up a panel of information on the planet you've selected.\n\n" +
                "This is the end of the tutorial. Have fun playing Planet Hopper!";
            
            buttonPresses++;
            tImage.enabled = false;
            tImage2.enabled = true;
        }
        else
        {
            TutorialNavi.main.GoToTitle();
        }
    }
}
