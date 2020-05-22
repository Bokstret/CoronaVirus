using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// The HUD
/// </summary>
public class HUD : MonoBehaviour
{
    Timer scoreTimer;
    // scoring support
    [SerializeField]
    Text scoreText;
    int score = 0;

    const string ScorePrefix = "Score: ";

    /// <summary>
    /// Use this for initialization
    /// </summary>
    void Start()
    {
        scoreText.text = ScorePrefix + score.ToString();
       
    }

    public void AddPoints(int points) 
    {
        score += points;
        scoreText.text = ScorePrefix + score.ToString();
    }
    void Update()
    {
        
    }
}
