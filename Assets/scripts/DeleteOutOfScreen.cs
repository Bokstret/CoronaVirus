using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrapper : MonoBehaviour
{
  
    float colliderRadius;

    
    void Start()
    {
        
        colliderRadius = gameObject.GetComponent<CircleCollider2D>().radius;
    }

   
    void OnBecameInvisible()
    {
        Vector2 location = transform.position;

        if (location.x + colliderRadius < ScreenUtils.ScreenLeft ||
            location.x - colliderRadius > ScreenUtils.ScreenRight)
        {
            Destroy(gameObject); 
        }
        if (location.y - colliderRadius > ScreenUtils.ScreenTop ||
            location.y + colliderRadius < ScreenUtils.ScreenBottom)
        {
            Destroy(gameObject);
        }

       
    }
}
