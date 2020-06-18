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
    [SerializeField]
    Text scoreLose;

    public static int score;
    int coinStatus = 0; //when status = 5 then make it 0 and give 1 coin to the player 
    const string BestPrefix = "Best: ";
    const string loseScore = "Score: ";

    void Start()
    {
        //PlayerPrefs.SetInt("Coins", 0);
        //PlayerPrefs.SetInt("BestScore", 0);
        scoreText.text = score.ToString();
        bestText.text = BestPrefix + PlayerPrefs.GetInt("BestScore").ToString();
        coinsText.text = PlayerPrefs.GetInt("Coins").ToString();
    }

    public void AddPoints(int points) 
    {
        score += points;
        scoreText.text = score.ToString();
        scoreLose.text = loseScore + score.ToString();
        if (score > PlayerPrefs.GetInt("BestScore"))
        {
            PlayerPrefs.SetInt("BestScore", score);
            bestText.text = BestPrefix + PlayerPrefs.GetInt("BestScore").ToString();
        }
        coinStatus += 1;
        if (coinStatus == 5)
        {
            coinStatus = 0;
            PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + 1);
            coinsText.text =  PlayerPrefs.GetInt("Coins").ToString();
        }
    }

    public void SetAllToZero()
    {
        score = 0;
        coinStatus = 0;
        scoreText.text = score.ToString();
        scoreLose.text = loseScore + score.ToString();
    }
}
