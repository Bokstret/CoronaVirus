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
    GameObject pause;
    GameObject resume;
    UnityEngine.UI.Image man;
    UnityEngine.UI.Image coin;
    GameObject startButton;
    Text title;
    Text tap;
    Text best;
    Text score;
    Text coins;

    void Start()
    {
        pause = GameObject.Find("Pause");
        resume = GameObject.Find("Resume");
        startButton = GameObject.Find("Start");
        spawner = GameObject.Find("Main Camera").GetComponent<Spawner>();
        title = GameObject.Find("Title").GetComponent<Text>();
        tap = GameObject.Find("StartText").GetComponent<Text>();
        man = GameObject.Find("PreviewMan").GetComponent<UnityEngine.UI.Image>();
        best = GameObject.Find("Best").GetComponent<Text>();
        score = GameObject.Find("scoreText").GetComponent<Text>();
        coins = GameObject.Find("coinsText").GetComponent<Text>();
        coin = GameObject.Find("Coin").GetComponent<UnityEngine.UI.Image>();



        pause.SetActive(false);
        resume.SetActive(false);
    }

    public void StartGame()
    {
        startButton.SetActive(false);
        pause.SetActive(true);
        spawner.enabled = true;
        title.enabled = false;
        tap.enabled = false;
        man.enabled = false;
        best.enabled = false;
        score.enabled = true;
        coins.enabled = true;
        coin.enabled = true;
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
