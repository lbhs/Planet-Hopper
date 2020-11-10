using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : MonoBehaviour
{
    private Material M;
    private Color color;

    void Start()
    {
        M = this.GetComponent<MeshRenderer>().material;
        FadeOut();
    }

    void FadeOut()
    {
        M.color = new Color(1, 1, 0, .9f);
        new WaitForSeconds(1);
        M.color = new Color(1, 1, 0, .8f);
        new WaitForSeconds(1);
        M.color = new Color(1, 1, 0, .7f);
        new WaitForSeconds(1);
        M.color = new Color(1, 1, 0, .6f);
        new WaitForSeconds(1);
        M.color = new Color(1, 1, 0, .5f);
        new WaitForSeconds(1);
        M.color = new Color(1, 1, 0, .4f);
        new WaitForSeconds(1);
        M.color = new Color(1, 1, 0, .3f);
        new WaitForSeconds(1);
        M.color = new Color(1, 1, 0, .2f);
        new WaitForSeconds(1);
        M.color = new Color(1, 1, 0, .1f);
        new WaitForSeconds(1); 
        M.color = new Color(1, 1, 0, 0);
        new WaitForSeconds(1);
    }

    void FadeIn()
    {
        M.color = new Color(1, 1, 0, .1f);
        new WaitForSeconds(1);
        M.color = new Color(1, 1, 0, .2f);
        new WaitForSeconds(1);
        M.color = new Color(1, 1, 0, .3f);
        new WaitForSeconds(1);
        M.color = new Color(1, 1, 0, .4f);
        new WaitForSeconds(1);
        M.color = new Color(1, 1, 0, .5f);
        new WaitForSeconds(1);
        M.color = new Color(1, 1, 0, .6f);
        new WaitForSeconds(1);
        M.color = new Color(1, 1, 0, .7f);
        new WaitForSeconds(1);
        M.color = new Color(1, 1, 0, .8f);
        new WaitForSeconds(1);
        M.color = new Color(1, 1, 0, .9f);
        new WaitForSeconds(1);
        M.color = new Color(1, 1, 0, 1);
        new WaitForSeconds(1);
    }

    void FixedUpdate()
    {
        if (M.color == new Color(1, 1, 0, 0))
            FadeIn();
        if (M.color == new Color(1, 1, 0, 1))
            FadeOut();
    }
}

