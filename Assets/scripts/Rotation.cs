using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{

    public float rotationSpeed;
    public float angle;

    public float scaleSpeed;
    public float scale;

    private float currentScale;
    int flag = 0;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        if (transform.rotation.eulerAngles.z >= angle & transform.rotation.eulerAngles.z <= 360 - angle)
        {
            rotationSpeed *= -1;
        }
            

        currentScale = transform.localScale.x;
        if (flag == 0)
        {
            transform.localScale = new Vector2(currentScale + scaleSpeed * Time.deltaTime, currentScale + scaleSpeed * Time.deltaTime);
        }
            
        else if (flag == 1)
        {
            transform.localScale = new Vector2(currentScale - scaleSpeed * Time.deltaTime, currentScale - scaleSpeed * Time.deltaTime);
        }
        
        if (currentScale >= scale)
        {
            flag = 1;
        }

        if (currentScale < 1)
        {
            flag = 0;
        }
                 
    }
}
