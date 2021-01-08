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
    public List<float> Distances;
    public List<float> UIDistances;
    public List<float> UISpeeds;

    // Start is called before the first frame update
    void Awake()
    {
        PlanetMenuObject.SetActive(false);
        UpdateMenu = true;
    }

    IEnumerator UpdatePlanetMenu()
    {
        while (UpdateMenu == true)
        {
            yield return new WaitForSeconds(.5f);
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
            var newlist = UIDistances.ToArray();
            var closestplanetdistance = Mathf.Min(newlist);
            var closestplanetspeed = UISpeeds[newlist.IndexOf(closestplanetdistance)];
            ClosestPlanetText.text = Planets[newlist.IndexOf(closestplanetdistance)].name;
            ClosestPlanetDistanceText.text = closestplanetdistance;
            ClosestPlanetSpeedText = closestplanetspeed.ToString();
        }
    }



    public void Restart()
    {
        StartCoroutine("UpdatePlanetMenu");
    }
}
