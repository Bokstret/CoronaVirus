using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Experimental.UIElements;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    GameObject[] gameObjects;
    Spawner spawner;
    Canvas info;
    GameObject pause;
    GameObject resume;
    UnityEngine.UI.Image man;
    GameObject startButton;
    Text title;
    Text tap;

    void Start()
    {
        pause = GameObject.Find("Pause");
        resume = GameObject.Find("Resume");
        startButton = GameObject.Find("Start");
        spawner = GameObject.Find("Main Camera").GetComponent<Spawner>();
        info = GameObject.FindGameObjectWithTag("HUD").GetComponent<Canvas>();
        title = GameObject.Find("Title").GetComponent<Text>();
        tap = GameObject.Find("StartText").GetComponent<Text>();
        man = GameObject.Find("PreviewMan").GetComponent<UnityEngine.UI.Image>();

        pause.SetActive(false);
        resume.SetActive(false);
    }

    public void StartGame()
    {
        startButton.SetActive(false);
        pause.SetActive(true);
        spawner.enabled = true;
        info.enabled = true;
        title.enabled = false;
        tap.enabled = false;
        man.enabled = false;
    }

    public void PauseGame()
    {
        gameObjects = FindObjectsOfType(typeof(GameObject)) as GameObject[];
        foreach (GameObject obj in gameObjects)
        {
            if (obj.layer == 8)
            {
                obj.GetComponent<Collider2D>().enabled = false;
            }
        }
        Time.timeScale = 0;

        pause.SetActive(false);
        spawner.enabled = false;
        resume.SetActive(true);
    }

    public void ResumeGame()
    {
        gameObjects = FindObjectsOfType(typeof(GameObject)) as GameObject[];
        foreach (GameObject obj in gameObjects)
        {
            if (obj.layer == 8)
            {
                obj.GetComponent<Collider2D>().enabled = true;
            }
        }
        Time.timeScale = 1;

        pause.SetActive(true);
        spawner.enabled = true;
        resume.SetActive(false);
    }

}
