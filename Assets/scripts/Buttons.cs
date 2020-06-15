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
    GameObject start;
    GameObject pause;
    GameObject resume;

    void Start()
    {
        start = GameObject.Find("Start");
        pause = GameObject.Find("Pause");
        resume = GameObject.Find("Resume");
        spawner = GameObject.Find("Main Camera").GetComponent<Spawner>();
        info = GameObject.FindGameObjectWithTag("HUD").GetComponent<Canvas>();

        pause.SetActive(false);
        resume.SetActive(false);
    }

    public void StartGame()
    {
        pause.SetActive(true);
        spawner.enabled = true;
        start.SetActive(false);
        info.enabled = true;
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
        info.enabled = false;
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
        start.SetActive(false);
        info.enabled = true;
        resume.SetActive(false);
    }

}
