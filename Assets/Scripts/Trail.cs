using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trail : MonoBehaviour
{
    public Shader lineShader;
    public Color linecolor;
    public GameObject Starship;
    private bool maketrail;

    void Start()
    {
        maketrail = true;
        StartCoroutine("MakeLine");
    }

    IEnumerator MakeLine()
    {
        while (maketrail == true)
        {
            var startpos = Starship.transform.position;
            yield return new WaitForSeconds(5);
            var endpos = Starship.transform.position;
            Vector3[] positionArray = new[] { startpos, endpos };
            GameObject line = new GameObject();
            line.AddComponent<LineRenderer>();
            LineRenderer lr = line.GetComponent<LineRenderer>();
            lr.material = new Material(lineShader);
            lr.SetColors(linecolor, linecolor);
            lr.SetWidth(10, 10);
            lr.SetPositions(positionArray);
            UnityEngine.Debug.Log("made line");
            yield return new WaitForSeconds(5);
        }
    }
}
