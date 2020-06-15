using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameInitializer : MonoBehaviour 
{
    GameObject BG;
    public static float koef;
    void Start()
    {
        BG = GameObject.Find("Background");

        float height = Camera.main.orthographicSize * 2f;
        float width = height * Screen.width / Screen.height;
        koef = width / BG.GetComponent<SpriteRenderer>().bounds.size.x;
        BG.transform.localScale = new Vector3(koef, koef, 1);
    }
    void Awake()
    {
    
        ScreenUtils.Initialize();
    }
}
