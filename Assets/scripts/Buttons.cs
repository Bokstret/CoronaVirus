using System;
using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.EventSystems;
using UnityEngine.Experimental;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    HUD hud;
    GameObject[] gameObjects;
    Spawner spawner;
    GameObject pause;
    GameObject resume;
    GameObject soundOff;
    GameObject soundOn;
    UnityEngine.UI.Image man;
    UnityEngine.UI.Image coin;
    GameObject startButton;
    GameObject backButton;
    Text title;
    Text tap;
    Text best;
    Text score;
    Text coins;
    Text scoreLose;
    Text Continue;
    AudioSource audio;

    static int chudishe = 0;

    void Start()
    {
        hud = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>();
        pause = GameObject.Find("Pause");
        resume = GameObject.Find("Resume");
        soundOff = GameObject.Find("SoundOff");
        soundOn = GameObject.Find("SoundOn");
        startButton = GameObject.Find("Start");
        backButton = GameObject.Find("Back");
        spawner = GameObject.Find("Main Camera").GetComponent<Spawner>();
        man = GameObject.Find("PreviewMan").GetComponent<UnityEngine.UI.Image>();
        coin = GameObject.Find("Coin").GetComponent<UnityEngine.UI.Image>();
        title = GameObject.Find("Title").GetComponent<Text>();
        tap = GameObject.Find("StartText").GetComponent<Text>();
        best = GameObject.Find("Best").GetComponent<Text>();
        score = GameObject.Find("scoreText").GetComponent<Text>();
        coins = GameObject.Find("coinsText").GetComponent<Text>();
        scoreLose = GameObject.Find("scoreLose").GetComponent<Text>();
        Continue = GameObject.Find("Continue").GetComponent<Text>();
        audio = GameObject.Find("Main Camera").GetComponent<AudioSource>();

        pause.SetActive(false);
        resume.SetActive(false);
        backButton.SetActive(false);
        if (PlayerPrefs.GetInt("SoundOn") == 0)
        {
            audio.enabled = false;
            soundOn.SetActive(true);
            soundOff.SetActive(false);
        }
        else
        {
            audio.enabled = true;
            soundOn.SetActive(false);
            soundOff.SetActive(true);
        }
        
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
        soundOn.SetActive(false);
        soundOff.SetActive(false);
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

    public void LoseGame()
    {
        gameObjects = FindObjectsOfType(typeof(GameObject)) as GameObject[];
        foreach (GameObject obj in gameObjects)
        {
            if (obj.layer == 8)
            {
                Destroy(obj);
            }
        }
        Spawner.timer.Duration = 2;
        pause.SetActive(false);
        resume.SetActive(false);
        backButton.SetActive(true);
        score.enabled = false;
        spawner.enabled = false;
        scoreLose.enabled = true;
        Continue.enabled = true;

        if (chudishe % 4 == 0)
        {
            Advertisement.Show();
        }
        chudishe += 1;
    }

    public void BackToMenu()
    {
        hud.SetAllToZero();
        backButton.SetActive(false);
        startButton.SetActive(true);
        title.enabled = true;
        tap.enabled = true;
        man.enabled = true;
        best.enabled = true;
        coins.enabled = true;
        coin.enabled = true;
        scoreLose.enabled = false;
        Continue.enabled = false;
        if (audio.enabled == true)
        {
            soundOff.SetActive(true);
        }
        else
        {
            soundOn.SetActive(true);
        }
    }

    public void SoundOff()
    {
        soundOn.SetActive(true);
        soundOff.SetActive(false);
        audio.enabled = false;
        PlayerPrefs.SetInt("SoundOn", 0);
    }

    public void SoundOn()
    {
        soundOn.SetActive(false);
        soundOff.SetActive(true);
        audio.enabled = true;
        PlayerPrefs.SetInt("SoundOn", 1);
    }

}
