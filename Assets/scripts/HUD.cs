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
    int score = 0;
    int coinStatus = 0; //when status = 3 then make it 0 and give 1 coin to the player 
    int coins = 0;
    const string ScorePrefix = "Score: ";
    const string CoinsPrefix = "Coins: ";


    void Start()
    {
        scoreText.text = ScorePrefix + score.ToString();
       
    }

    public void AddPoints(int points) 
    {
        score += points;
        scoreText.text = ScorePrefix + score.ToString();

        coinStatus += 1;
        if (coinStatus == 3)
        {
            coinStatus = 0;
            coins += 1;
            coinsText.text = CoinsPrefix + coins.ToString();
            
        }
    }
    void Update()
    {
        
    }
}
