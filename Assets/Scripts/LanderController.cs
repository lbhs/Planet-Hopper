using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanderController : MonoBehaviour
{
    public bool isInScene;
    public Rigidbody lander;
    public bool Collided;
    public LanderGameHandler LanderGameHandler;
    public bool Completed;
    public GameObject Explosion;
    public Text Crashed;
    public Text CompletedText;
    public bool moveable;
    public bool isrunning;

    // Start is called before the first frame update
    void Start()
    {
        moveable = true;
        Crashed.enabled = false;
        CompletedText.enabled = false;
        isInScene = false;
        Completed = false;
        Collided = false;
        isrunning = false;
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
        if (moveable == true)
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
            if (Collided)
            {
                if (isrunning == false)
                {
                    StartCoroutine("EndGame");
                    isrunning = true;
                }
            }
        }
    }

    IEnumerator EndGame()
    {
        if (Completed)
        {
            UnityEngine.Debug.Log("yuh");
            // Say u won then return to orbit
            moveable = false;
            CompletedText.enabled = true;
            yield return new WaitForSeconds(3.0f);
            LanderGameHandler.EndLanderGame();
        }
        else
        {
            // Say u crashed then return to orbit
            moveable = false;
            Crashed.enabled = true;
            Explosion.transform.position = lander.transform.position;
            ParticleSystem Exploder = Explosion.GetComponent<ParticleSystem>();
            lander.gameObject.SetActive(false);
            Exploder.Play();
            yield return new WaitForSeconds(3.0f);
            LanderGameHandler.EndLanderGame();
        }
        Completed = false;
        Collided = false;
        moveable = true;
        Crashed.enabled = false;
        CompletedText.enabled = false;
        isrunning = false;
    }
}