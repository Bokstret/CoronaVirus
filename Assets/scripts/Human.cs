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
            Vector3 target = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
            float step = Speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target, step);
        }
        else
        {
            Vector3 target = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
            float step = Speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target, step);
        }
    }
}