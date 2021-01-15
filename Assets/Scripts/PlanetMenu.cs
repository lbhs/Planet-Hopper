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
    private float starshipspeed;
    public List<GameObject> Planets;
    public List<Text> PlanetsTextDistance;
    public List<Text> PlanetsTextSpeed;
    public Text ClosestPlanetText;
    public Text ClosestPlanetDistanceText;
    public Text ClosestPlanetSpeedText;
    public List<float> UIDistances;
    public List<float> UISpeeds;
    public Image Arrow;

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
            starshipspeed = Starship.GetComponent<Rigidbody>().velocity.magnitude;
            foreach (GameObject planet in Planets)
            {
                var distance = Vector3.Distance(starshippos, planet.transform.position);
                UIDistances.Add(distance);
                var speed = Mathf.Abs(planet.GetComponent<Rigidbody>().velocity.magnitude - starshipspeed);
                UISpeeds.Add(speed);
                var listpos = Planets.IndexOf(planet);
                var distancetext = PlanetsTextDistance[listpos];
                distancetext.text = distance.ToString();
                var speedtext = PlanetsTextSpeed[listpos];
                speedtext.text = speed.ToString();
            }

            float[] UIDistancesArray = UIDistances.ToArray();
            var closestplanetdistance = Mathf.Min(UIDistancesArray);
            var uidisindex = UIDistances.IndexOf(closestplanetdistance);
            var closestplanetspeed = UISpeeds[uidisindex];
            ClosestPlanetText.text = "Closest Planet: \n" + Planets[uidisindex].name;
            ClosestPlanetDistanceText.text = "Distance: \n" + closestplanetdistance.ToString();
            ClosestPlanetSpeedText.text = "Relative Velocity: \n" + closestplanetspeed.ToString();
            UIDistances.Clear();
            UISpeeds.Clear();
            GameObject closestplanet = Planets[uidisindex];

            Vector3 direction = starshippos - closestplanet.transform.position;
            var angle = Mathf.Atan(direction.y/direction.x) * (180/Mathf.PI);
            Arrow.transform.rotation = Quaternion.Euler(0, 0, (angle - 270));
        }
    }
}
