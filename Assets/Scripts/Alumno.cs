using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Alumno : MonoBehaviour
{
    public HullController3D controller3D;
    public Material shader;
    public AudioManager AM;

    private void Start()
    {
        AM.Play("Song");
    }

    private void OnCollisionEnter(Collision other)
    {
        controller3D.numberOfPoints+=10;
        controller3D.GenerateHull();
        if (other.gameObject.tag != "Wall")
        {
            other.gameObject.GetComponent<TurnDown>().Collision();
            // Color c = other.gameObject.GetComponent<Renderer>().material.color;            
            // other.gameObject.GetComponent<Renderer>().material = shader;
            // other.gameObject.GetComponent<Renderer>().material.color = c;
            // other.gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", c);
            // StartCoroutine(other.gameObject.GetComponent<TurnDown>().ActualizarColorEmmisive());
            playRandomSound();
        }
    }

    private void playRandomSound()
    {
        int x = Random.Range(0, 7);
        string sound = "Clip" + x.ToString();
        AM.Play(sound);
    }
}
