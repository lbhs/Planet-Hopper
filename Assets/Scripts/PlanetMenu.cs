using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public List<float> Distances;
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
                var speed = Mathf.Abs(planet.GetComponent<Rigidbody>().velocity.magnitude - starshipspeed);
                var listpos = Planets.IndexOf(planet);
                var distancetext = PlanetsTextDistance[listpos];
                distancetext.text = distance.ToString();
                var speedtext = PlanetsTextSpeed[listpos];
                speedtext.text = speed.ToString();
            }
        }
    }

 //   void Update()
 //   {
 //       foreach (Text textelement in PlanetsTextDistance)
 //       {
 //           var distances = float.Parse(textelement.text);
 //           Distances.Add(distances);
 //       }
 //       var closestdistance = Mathf.Max(Distances.ToArray());
 //       var closestdistanceindex = Distances.IndexOf(closestdistance);
  //      var closestplanetname = Planets[closestdistanceindex].name;
  //      ClosestPlanetText.text = "Nearest Planet" + closestplanetname;
 //   }  

    public void Restart()
    {
        StartCoroutine("UpdatePlanetMenu");
    }
}
