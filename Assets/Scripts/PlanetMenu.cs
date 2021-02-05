using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class PlanetMenu : MonoBehaviour
{
    private bool UpdateMenu;
    public GameObject Starship;
    private Vector3 starshippos;
    private Vector3 starshipspeed;
    public List<GameObject> Planets;
    public Text ClosestPlanetText;
    public Text ClosestPlanetDistanceText;
    public Text ClosestPlanetSpeedText;
    public List<float> UIDistances;
    public List<Vector3> UISpeeds;
    public Image Arrow;
    public Image Arrow2;
    public Vector3 closestplanetspeed;
    public float closestplanetdistance;
    public int uidisindex;
    public float closestplanetspeedmag;

    // Start is called before the first frame update
    void Awake()
    {
        UpdateMenu = true;
        StartCoroutine("UpdatePlanetMenu");
    }

    void Update()
    {
        starshippos = Starship.transform.position;
        starshipspeed = Starship.GetComponent<Rigidbody>().velocity;
        foreach (GameObject planet in Planets)
        {
            var distance = Vector3.Distance(starshippos, planet.transform.position);
            UIDistances.Add(distance);
            var speed1 = starshipspeed - planet.GetComponent<Rigidbody>().velocity;
            UISpeeds.Add(speed1);
        }
        float[] UIDistancesArray = UIDistances.ToArray();
        closestplanetdistance = Mathf.Min(UIDistancesArray);
        uidisindex = UIDistances.IndexOf(closestplanetdistance);
        closestplanetspeed = UISpeeds[uidisindex];
        closestplanetspeedmag = closestplanetspeed.magnitude;
    }

    IEnumerator UpdatePlanetMenu()
    {
        while (UpdateMenu == true && Starship != null)
        {
            yield return new WaitForSeconds(1);

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
                }
                if (direction.y < 0)
                {
                    var angle = Mathf.Atan(Mathf.Abs(direction.y) / Mathf.Abs(direction.x)) * Mathf.Rad2Deg + 180;
                    Arrow.transform.rotation = Quaternion.Euler(0, 0, (angle - 90));
                }
            }
            else
            {
                if (direction.y > 0)
                {
                    var angle = Mathf.Atan(Mathf.Abs(direction.y) / Mathf.Abs(direction.x)) * Mathf.Rad2Deg;
                    Arrow.transform.rotation = Quaternion.Euler(0, 0, (angle - 90));
                }
                if (direction.y < 0)
                {
                    var angle = 0 - Mathf.Atan(Mathf.Abs(direction.y) / Mathf.Abs(direction.x)) * Mathf.Rad2Deg;
                    Arrow.transform.rotation = Quaternion.Euler(0, 0, (angle - 90));
                }
            }

            //Rotate Velocity Arrow
            if (closestplanetspeed.x < 0)
            {
                if (closestplanetspeed.y > 0)
                {
                    var anglee = 180 - Mathf.Atan(Mathf.Abs(closestplanetspeed.y) / Mathf.Abs(closestplanetspeed.x)) * Mathf.Rad2Deg;
                    Arrow2.transform.rotation = Quaternion.Euler(0, 0, (anglee - 90));
                }
                if (closestplanetspeed.y < 0)
                {
                    var anglee = Mathf.Atan(Mathf.Abs(closestplanetspeed.y) / Mathf.Abs(closestplanetspeed.x)) * Mathf.Rad2Deg + 180;
                    Arrow2.transform.rotation = Quaternion.Euler(0, 0, (anglee - 90));
                }
            }
            else
            {
                if (closestplanetspeed.y > 0)
                {
                    var anglee = Mathf.Atan(Mathf.Abs(closestplanetspeed.y) / Mathf.Abs(closestplanetspeed.x)) * Mathf.Rad2Deg;
                    Arrow2.transform.rotation = Quaternion.Euler(0, 0, (anglee - 90));
                }
                if (closestplanetspeed.y < 0)
                {
                    var anglee = 0 - Mathf.Atan(Mathf.Abs(closestplanetspeed.y) / Mathf.Abs(closestplanetspeed.x)) * Mathf.Rad2Deg;
                    Arrow2.transform.rotation = Quaternion.Euler(0, 0, (anglee - 90));
                }
            }
        }
    }
}
