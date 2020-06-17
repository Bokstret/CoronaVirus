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

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        hud = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>();
        human = gameObject.GetComponent<Human>();

    }

    void OnMouseDown()
    {
        human.enabled = false;
        anim.SetBool("isClicked", true);
        gameObject.GetComponent<Collider2D>().enabled = false;
        transform.position = transform.position;
        if (gameObject.CompareTag("IllL") | gameObject.CompareTag("IllR"))
        {
            hud.AddPoints(reward);
        }
        else
        {
            Application.Quit();
        }
        Invoke("Kill", 0.4f);

    }

    void Kill()
    {
        Destroy(gameObject);
    }
}
