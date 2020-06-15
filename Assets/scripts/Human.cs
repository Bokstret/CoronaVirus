using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Human : MonoBehaviour
{
    [SerializeField]
    Sprite HumanSkin;
    
    public float Speed = 5f;

    private void FixedUpdate()
    {
        if (gameObject.CompareTag("IllL") | gameObject.CompareTag("notIllL"))
        {
            Vector2 target = new Vector2(transform.position.x + 1, transform.position.y);
            float step = Speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, target, step);
        }
        else
        {
            Vector2 target = new Vector2(transform.position.x - 1, transform.position.y);
            float step = Speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, target, step);
        }
    }
}