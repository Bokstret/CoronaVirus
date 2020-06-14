using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    Buttons script;
    GameObject BG;
    public static float koef;
    // Start is called before the first frame update
    void Start()
    {
        script = GameObject.FindGameObjectWithTag("MenuCamera").GetComponent<Buttons>();
        BG = GameObject.Find("Background");

        float height = Camera.main.orthographicSize * 2f;
        float width = height * Screen.width / Screen.height;
        koef = width / BG.GetComponent<SpriteRenderer>().bounds.size.x;
        BG.transform.localScale = new Vector3(koef, koef, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartPressed()
    {
        script.StartGame();
    }

    public void PausePressed()
    {
        script.PauseGame();
    }

    public void ResumePressed()
    {
        script.ResumeGame();
    }

    public void RestartPressed()
    {
        script.RestartGame();
    }
}
