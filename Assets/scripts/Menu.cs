using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    Buttons script;
    // Start is called before the first frame update
    void Start()
    {
        script = GameObject.FindGameObjectWithTag("MenuCamera").GetComponent<Buttons>();
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
}
