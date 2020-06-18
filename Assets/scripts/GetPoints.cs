using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class GetPoints : MonoBehaviour
{
    Human human;
    HUD hud;
    Animator anim;
    const int reward = 1;
    Buttons script;
    Sound soundScript;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        hud = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>();
        human = gameObject.GetComponent<Human>();
        script = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Buttons>();
        soundScript = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Sound>();

    }

    void OnMouseDown()
    {
        soundScript.Click();
        human.enabled = false;
        anim.SetBool("isClicked", true);
        gameObject.GetComponent<Collider2D>().enabled = false;
        transform.position = transform.position;
        if (gameObject.CompareTag("IllL") | gameObject.CompareTag("IllR"))
        {
            hud.AddPoints(reward);
            if (Spawner.timer.Duration > 0.5f)
            {
                Spawner.timer.Duration -= 0.03f;
            }
            
        }
        else
        {
            script.LoseGame();
        }
        Invoke("Kill", 0.4f);

    }

    void Kill()
    {
        Destroy(gameObject);
    }
}
