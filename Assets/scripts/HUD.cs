using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;


public class HUD : MonoBehaviour
{
    
    [SerializeField]
    Text scoreText;
    [SerializeField]
    Text coinsText;
    [SerializeField]
    Text bestText;
    int score = 0;
    int coinStatus = 0; //when status = 3 then make it 0 and give 1 coin to the player 
    const string ScorePrefix = "Score: ";
    const string CoinsPrefix = "Coins: ";
    const string BestPrefix = "Record: ";


    void Start()
    {
        //PlayerPrefs.SetInt("Coins", 0);
        //PlayerPrefs.SetInt("BestScore",0);
        scoreText.text = ScorePrefix + score.ToString();
        bestText.text = BestPrefix + PlayerPrefs.GetInt("BestScore").ToString();
        coinsText.text = CoinsPrefix + PlayerPrefs.GetInt("Coins").ToString();
    }

    public void AddPoints(int points) 
    {
        score += points;
        scoreText.text = ScorePrefix + score.ToString();
        
        if (score > PlayerPrefs.GetInt("BestScore"))
        {
            PlayerPrefs.SetInt("BestScore", score);
            bestText.text = BestPrefix + PlayerPrefs.GetInt("BestScore").ToString();
        }
        coinStatus += 1;
        if (coinStatus == 3)
        {
            coinStatus = 0;
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + 1);
            coinsText.text = CoinsPrefix + PlayerPrefs.GetInt("Coins").ToString();
        }
    }

    public void Restart()
    {
        score = 0;
        coinStatus = 0;
        scoreText.text = ScorePrefix + " 0";
    }

    void Update()
    {
        
    }
}
