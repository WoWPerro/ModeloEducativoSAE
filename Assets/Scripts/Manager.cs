using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class Manager : MonoBehaviour
{
    public List<GameObject> prefabs;
    public List<Color> colors;

    public int sizex;
    public int sizey;
    public int sizez;
    public float space;
    public float deformMax;
    public float deformMin;

    public GameObject parent;
    public GameObject cam1;
    public GameObject cam2;
    
    public Material shader;
    // Start is called before the first frame update
    void Start()
    {
        GenerateBoard();
    }

    void GenerateBoard()
    {
        for (int i = 0; i < sizex; i++)
        {
            for (int j = 0; j < sizey; j++)
            {
                for (int k = 0; k < sizez; k++)
                {
                    GameObject obj = Instantiate(prefabs[Random.Range(0, 4)], 
                        new Vector3(i*space + (Random.Range(-3f, 3f)), 
                            j*space + (Random.Range(-3f, 3f)) , 
                            k*space + (Random.Range(-3f, 3f))), 
                        Random.rotation);

                    obj.transform.localScale =
                        new Vector3(Random.Range(deformMin, deformMax), Random.Range(deformMin, deformMax), Random.Range(deformMin, deformMax));
                    //obj.GetComponent<Renderer>().material = shader;
                    obj.GetComponent<Renderer>().material.color = colors[Random.Range(0,colors.Count)];
                    obj.transform.parent = parent.transform;    
                }
            }
        }
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (cam1.activeInHierarchy)
            {
                cam1.SetActive(false);
                cam2.SetActive(true);
            }
            else
            {
                cam1.SetActive(true);
                cam2.SetActive(false);
            }
        }
        if (Input.GetButtonDown("Cancel"))
        {
            if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
            }
            else
            {
                Time.timeScale = 0;
            }
            
        }
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            Time.timeScale = .5f;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift))
        {
            Time.timeScale = 1;
        }
    }
}
