using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    Spawner spawner;
    Canvas hud;
    Canvas menu;
    Canvas pause;
    void Start()
    {   pause = GameObject.FindGameObjectWithTag("Pause").GetComponent<Canvas>();
        spawner = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Spawner>();
        hud = GameObject.FindGameObjectWithTag("HUD").GetComponent<Canvas>();
        menu = GameObject.FindGameObjectWithTag("Menu").GetComponent<Canvas>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGame()
    {
        Time.timeScale = 1;
        pause.enabled = true;
        spawner.enabled = true;
        menu.enabled = false;
        hud.enabled = true;
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pause.enabled = false;
        spawner.enabled = false;
        menu.enabled = true;
        hud.enabled = false;
    }
}
