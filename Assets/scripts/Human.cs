using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Human : MonoBehaviour
{
    [SerializeField]
    Sprite HumanSkin;
    


    public float Speed = 5f;
    
    void Start()
    {
        
    }

    public void Initialize(Direction direction, Vector3 position)
    {
 
        transform.position = position;

        float angle;
        float randomAngle = Random.value * 30f * Mathf.Deg2Rad;

        if (direction == Direction.Left)
        {
            angle = 165 * Mathf.Deg2Rad + randomAngle;
        }
        else
        {
            angle = -15 * Mathf.Deg2Rad + randomAngle;
        }


        Vector2 moveDirection = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        GetComponent<Rigidbody2D>().AddForce(moveDirection * 2, ForceMode2D.Impulse);

        

    }

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