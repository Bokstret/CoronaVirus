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
    GetPoints clickScript;
    HUD hud;
    Canvas info;
    GameObject start;
    GameObject pause;
    GameObject resume;
    GameObject restart;

    void Start()
    {
        start = GameObject.Find("Start");
        pause = GameObject.Find("Pause");
        resume = GameObject.Find("Resume");
        restart = GameObject.Find("Restart");
        spawner = GameObject.Find("Main Camera").GetComponent<Spawner>();
        info = GameObject.FindGameObjectWithTag("HUD").GetComponent<Canvas>();
        hud = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>();

        pause.SetActive(false);
        resume.SetActive(false);
        restart.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

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
        restart.SetActive(true);
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
        restart.SetActive(false);
    }

    public void RestartGame()
    {
        gameObjects = FindObjectsOfType(typeof(GameObject)) as GameObject[];
        foreach (GameObject obj in gameObjects)
        {
            if (obj.layer == 8)
            {
                Destroy(obj);
            }
        }
        hud.SetPointsToZero();
        Time.timeScale = 1;
        pause.SetActive(true);
        spawner.enabled = true;
        start.SetActive(false);
        info.enabled = true;
        resume.SetActive(false);
        restart.SetActive(false);
    }
}
