using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Random = UnityEngine.Random;

public class Alumno : MonoBehaviour
{
    public HullController3D controller3D;
    public Material shader;
    public AudioManager AM;
    public TMP_Text text;
    private int interaciones;

    private void Start()
    {
        AM.Play("Song");
        interaciones = 0;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag != "Wall")
        {
            controller3D.numberOfPoints+=10;
            controller3D.GenerateHull();
            other.gameObject.GetComponent<TurnDown>().Collision();
            // Color c = other.gameObject.GetComponent<Renderer>().material.color;            
            // other.gameObject.GetComponent<Renderer>().material = shader;
            // other.gameObject.GetComponent<Renderer>().material.color = c;
            // other.gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", c);
            // StartCoroutine(other.gameObject.GetComponent<TurnDown>().ActualizarColorEmmisive());
            playRandomSound();
            interaciones++;
            UpdateText();
        }
    }

    private void playRandomSound()
    {
        int x = Random.Range(0, 7);
        string sound = "Clip" + x.ToString();
        AM.Play(sound);
    }
    
    private void UpdateText()
    {
        string txt = "Interacciones del Estudiante: " + interaciones.ToString() + "\nVértices del Polígono: " +
                     controller3D.numberOfPoints.ToString();
        text.text = txt;
    }
}
