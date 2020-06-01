using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour
{
    [SerializeField]
    Sprite Human1;
    [SerializeField]
    Sprite Human2;
    [SerializeField]
    Sprite HumanIll;

    void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        int spriteNumber = Random.Range(0, 2);

        if (spriteNumber == 1)
        {
            spriteRenderer.sprite = Human1;
        }
        else
        {
            spriteRenderer.sprite = Human2;
        }
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


        const float MinImpulseForce = 3f;
        const float MaxImpulseForce = 5f;
        Vector2 moveDirection = new Vector2(
            Mathf.Cos(angle), Mathf.Sin(angle));
        float magnitude = Random.Range(MinImpulseForce, MaxImpulseForce);
        GetComponent<Rigidbody2D>().AddForce(
            moveDirection * magnitude,
            ForceMode2D.Impulse);
    }

    void Update()
    {
        
    }
}
