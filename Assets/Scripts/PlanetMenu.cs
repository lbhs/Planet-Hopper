using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class PlanetMenu : MonoBehaviour
{
    public GameObject PlanetMenuObject;
    private bool UpdateMenu;
    public GameObject Starship;
    private Vector3 starshippos;
    private Vector3 starshipspeed;
    public List<GameObject> Planets;
    public List<Text> PlanetsTextDistance;
    public List<Text> PlanetsTextSpeed;
    public Text ClosestPlanetText;
    public Text ClosestPlanetDistanceText;
    public Text ClosestPlanetSpeedText;
    public List<float> UIDistances;
    public List<Vector3> UISpeeds;
    public Image Arrow;
    public Image Arrow2;

    // Start is called before the first frame update
    void Awake()
    {
        PlanetMenuObject.SetActive(false);
        UpdateMenu = true;
        StartCoroutine("UpdatePlanetMenu");
    }

    IEnumerator UpdatePlanetMenu()
    {
        while (UpdateMenu == true)
        {
            yield return new WaitForSeconds(1);
            starshippos = Starship.transform.position;
            starshipspeed = Starship.GetComponent<Rigidbody>().velocity;
            foreach (GameObject planet in Planets)
            {
                var distance = Vector3.Distance(starshippos, planet.transform.position);
                UIDistances.Add(distance);
                var speed1 = starshipspeed - planet.GetComponent<Rigidbody>().velocity;
                var speed2 = speed1.magnitude;
                UISpeeds.Add(speed1);
                var listpos = Planets.IndexOf(planet);
                var distancetext = PlanetsTextDistance[listpos];
                distancetext.text = distance.ToString();
                var speedtext = PlanetsTextSpeed[listpos];
                speedtext.text = speed2.ToString();
            }

            float[] UIDistancesArray = UIDistances.ToArray();
            var closestplanetdistance = Mathf.Min(UIDistancesArray);
            var uidisindex = UIDistances.IndexOf(closestplanetdistance);
            var closestplanetspeed = UISpeeds[uidisindex];
            var closestplanetspeedmag = closestplanetspeed.magnitude;
            ClosestPlanetText.text = "Closest Planet: \n" + Planets[uidisindex].name;
            ClosestPlanetDistanceText.text = "Distance: \n" + closestplanetdistance.ToString();
            ClosestPlanetSpeedText.text = "Relative Velocity: \n" + closestplanetspeedmag.ToString();
            UIDistances.Clear();
            UISpeeds.Clear();
            GameObject closestplanet = Planets[uidisindex];


            // Rotate Direction Arrow
            Vector3 direction = closestplanet.transform.position - starshippos;
            if (direction.x < 0)
            {
                if (direction.y > 0)
                {
                    var angle = 180 - Mathf.Atan(Mathf.Abs(direction.y) / Mathf.Abs(direction.x)) * Mathf.Rad2Deg;
                    Arrow.transform.rotation = Quaternion.Euler(0, 0, (angle - 90));
                    UnityEngine.Debug.Log(angle);
                }
                if (direction.y < 0)
                {
                    var angle = Mathf.Atan(Mathf.Abs(direction.y) / Mathf.Abs(direction.x)) * Mathf.Rad2Deg + 180;
                    Arrow.transform.rotation = Quaternion.Euler(0, 0, (angle - 90));
                    UnityEngine.Debug.Log(angle);
                }
            }
            else
            {
                if (direction.y > 0)
                {
                    var angle = Mathf.Atan(Mathf.Abs(direction.y) / Mathf.Abs(direction.x)) * Mathf.Rad2Deg;
                    Arrow.transform.rotation = Quaternion.Euler(0, 0, (angle - 90));
                    UnityEngine.Debug.Log(angle);
                }
                if (direction.y < 0)
                {
                    var angle = 0 - Mathf.Atan(Mathf.Abs(direction.y) / Mathf.Abs(direction.x)) * Mathf.Rad2Deg;
                    Arrow.transform.rotation = Quaternion.Euler(0, 0, (angle - 90));
                    UnityEngine.Debug.Log(angle);
                }
            }

            //Rotate Velocity Arrow
            Arrow2.transform.rotation = Quaternion.LookRotation(closestplanetspeed);
        }
    }
}
