using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnDown : MonoBehaviour
{
    // Start is called before the first frame update
    private bool collision = false;
    private Color c;
    Material shader1;
    public Material shader2;

    private void Start()
    {
        shader1 = gameObject.GetComponent<Renderer>().material;
    }

    public void Collision()
    {
        if (!collision)
        {
            c = gameObject.GetComponent<Renderer>().material.color;
            collision = true;
        }
        gameObject.GetComponent<Renderer>().material = shader2;
        gameObject.GetComponent<Renderer>().material.color = c;
        StartCoroutine(ActualizarColorEmmisive());
    }
    
    public IEnumerator ActualizarColorEmmisive()
    {
        float i = 2;
        while (i > 0)
        {
            i = i - .1f;
            gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", c * i);
            yield return new WaitForSeconds(.1f);
        }
        gameObject.GetComponent<Renderer>().material = shader1;
    }
}
