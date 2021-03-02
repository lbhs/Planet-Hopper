using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanderGameHandler : MonoBehaviour
{
    public static LanderGameHandler main;

    // the Lander used for the LanderGame
    public GameObject lander;

    // the Camera used for the lander game
    public Camera gameCam;

    private int landerGameID;  // the ID of the planet (taken from OrbitHandler.cs)
    public Vector3[] LanderGameArenas;  // an Array of the positions of the Lander Game Arenas. Ordered from middle of galaxy to perimeter

    // Start is called before the first frame update
    void Start()
    {
        main = this;
    }

    /* This function starts the Lander game. It teleports the Game Camera and the
     * Lunar Lander to the Lunar Lander Arena that corresponds to the currently
     * orbited planet, and then switches the camera from the main camera to the
     * Game Camera.
     * 
     * This function is called by a button in the Orbit UI.
     */
    public void InitiateLanderGame()
    {
        landerGameID = OrbitHandler.main.CurrentPlanetID;

        // these lines move the camera & lander to the arena corresponding to the orbited planet
        gameCam.transform.position = LanderGameArenas[landerGameID];
        lander.transform.position = LanderGameArenas[landerGameID];

        // not sure if this would actually work, but the idea is that it switches the camera to the game camera.
        gameCam.enabled = true;
        Camera.main.enabled = false;
    }

    /* This function ends the Lander game. You're probably gonna want to have 
     * this called by a button, but you could also have this be called by some
     * trigger. You can call this function in a script like this:
     * 
     * LanderGameHandler.main.EndLanderGame()
     * 
     * This script should essentially undo what `InitiateLanderGame` does.
     */
    public void EndLanderGame()
    {
        // pretty sure the lines below will switch the Camera back to the ship.
        Camera.main.enabled = true;
        gameCam.enabled = false;
    }
}
