using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    Buttons script;
    
    void Start()
    {
        script = GameObject.FindGameObjectWithTag("MenuCamera").GetComponent<Buttons>();
    }

    public void StartPressed()
    {
        script.StartGame();
    }

    public void PausePressed()
    {
        script.PauseGame();
    }

    public void ResumePressed()
    {
        script.ResumeGame();
    }
}
