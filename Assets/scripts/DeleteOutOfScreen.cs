using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteOutOfScreen : MonoBehaviour
{
  
    float colliderRadius;
    Buttons script;

    void Start()
    {
        colliderRadius = gameObject.GetComponent<CircleCollider2D>().radius;
        script = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Buttons>();
    }
   
    void OnBecameInvisible()
    {
        Vector2 location = transform.position;

        if (location.x + colliderRadius < ScreenUtils.ScreenLeft ||
            location.x - colliderRadius > ScreenUtils.ScreenRight)
        {
            if (gameObject.CompareTag("IllL") | gameObject.CompareTag("IllR"))
            {
                script.LoseGame();
            }
            Destroy(gameObject); 
        }
        
    }
}
