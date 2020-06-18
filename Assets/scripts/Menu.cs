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
        script = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Buttons>();
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

    public void BackToMenuPressed()
    {
        script.BackToMenu();
    }

    public void SoundOffPressed()
    {
        script.SoundOff();
    }

    public void SoundOnPressed()
    {
        script.SoundOn();
    }
}
