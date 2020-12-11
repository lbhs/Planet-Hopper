using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanetMenu : MonoBehaviour
{
    public GameObject Starship;
    private Vector3 starshippos;
    private float starshipspeed;
    public GameObject Mercury;
    public GameObject Venus;
    public GameObject Earth;
    public GameObject Mars;
    public GameObject Jupiter;
    public GameObject Saturn;
    public GameObject Uranus;
    public GameObject Neptune;
    public Text MercuryDistance;
    public Text VenusDistance;
    public Text EarthDistance;
    public Text MarsDistance;
    public Text JupiterDistance;
    public Text SaturnDistance;
    public Text UranusDistance;
    public Text NeptuneDistance;
    public Text MercurySpeed;
    public Text VenusSpeed;
    public Text EarthSpeed;
    public Text MarsSpeed;
    public Text JupiterSpeed;
    public Text SaturnSpeed;
    public Text UranusSpeed;
    public Text NeptuneSpeed;
    private List<GameObject> Planets;
    private List<Text> PlanetsTextDistance;
    private List<Text> PlanetsTextSpeed;
    // Start is called before the first frame update
    void Start()
    {
        Planets.Add(Mercury);
        Planets.Add(Venus);
        Planets.Add(Earth);
        Planets.Add(Mars);
        Planets.Add(Jupiter);
        Planets.Add(Saturn);
        Planets.Add(Uranus);
        Planets.Add(Neptune);
        PlanetsTextDistance.Add(MercuryDistance);
        PlanetsTextDistance.Add(VenusDistance);
        PlanetsTextDistance.Add(EarthDistance);
        PlanetsTextDistance.Add(MarsDistance);
        PlanetsTextDistance.Add(JupiterDistance);
        PlanetsTextDistance.Add(SaturnDistance);
        PlanetsTextDistance.Add(UranusDistance);
        PlanetsTextDistance.Add(NeptuneDistance);
        PlanetsTextSpeed.Add(MercurySpeed);
        PlanetsTextSpeed.Add(VenusSpeed);
        PlanetsTextSpeed.Add(EarthSpeed);
        PlanetsTextSpeed.Add(MarsSpeed);
        PlanetsTextSpeed.Add(JupiterSpeed);
        PlanetsTextSpeed.Add(SaturnSpeed);
        PlanetsTextSpeed.Add(UranusSpeed);
        PlanetsTextSpeed.Add(NeptuneSpeed);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
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
