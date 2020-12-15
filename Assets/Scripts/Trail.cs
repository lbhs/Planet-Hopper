using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trail : MonoBehaviour
{
    public Shader lineShader;
    public Color linecolor;
    public GameObject Starship;
    private bool maketrail;
    public List<GameObject> Lines;

    void Start()
    {
        maketrail = true;
        StartCoroutine("MakeLine");
    }

    IEnumerator MakeLine()
    {
        while (maketrail == true)
        {
            yield return new WaitForSeconds(1);
            var startpos = Starship.transform.position;
            yield return new WaitForSeconds(1);
            var endpos = Starship.transform.position;
            Vector3[] positionArray = new[] { startpos, endpos };
            GameObject line = new GameObject();
            Lines.Add(line);
            line.layer = 8;
            line.AddComponent<LineRenderer>();
            LineRenderer lr = line.GetComponent<LineRenderer>();
            lr.material = new Material(lineShader);
            lr.SetColors(linecolor, linecolor);
            lr.SetWidth(7, 7);
            lr.SetPositions(positionArray);
            UnityEngine.Debug.Log("made line");
            StartCoroutine("DestroyLine");
        }
    }

    IEnumerator DestroyLine()
    {
        yield return new WaitForSeconds(60);
        GameObject firstline = Lines[0];
        Destroy(firstline);
        Lines.RemoveAt(0);
    }
}
