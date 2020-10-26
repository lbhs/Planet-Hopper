using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanetActiveToggle : MonoBehaviour
{
    public bool isSelected = true;
    private Image image;
    [SerializeField] private Sprite activeCheck;
    [SerializeField] private Sprite cross;
    public GameObject planet;

    private void Start()
    {
        image = gameObject.GetComponent<Image>();
    }

    private void Update()
    {
        // 1. get the worldpos of target planet
        Vector3 pos = planet.transform.position;
        pos = new Vector3(pos.x, pos.y - 2.5f, pos.z);

        // 2. make that the screenpos of the image
        transform.position = Camera.main.WorldToScreenPoint(pos);
    }

    public void ToggleSelection()
    {
        isSelected = !isSelected;

        if (isSelected)
        {
            image.sprite = activeCheck;
        }
        else
        {
            image.sprite = cross;
        }
    }

}
