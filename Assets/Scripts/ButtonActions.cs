using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonActions : MonoBehaviour
{

    public void LoadScene(int scene)
    {
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }
    
    public void QuitApp()
    {
        Application.Quit();
    }
    
}