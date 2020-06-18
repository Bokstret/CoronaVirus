using System.Collections;
using System.Collections.Generic;
using UnityEngine.Advertisements;
using UnityEngine;

public class GameInitializer : MonoBehaviour 
{
    GameObject BG;
    public static float koef;
    const string gameId = "3663293";
    const string placementId = "Permanent";
    bool testMode = true;
    void Start()
    {
        Advertisement.Initialize(gameId);
        StartCoroutine(ShowBannerWhenReady());
        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
        

        BG = GameObject.Find("Background");

        float height = Camera.main.orthographicSize * 2f;
        float width = height * Screen.width / Screen.height;
        koef = width / BG.GetComponent<SpriteRenderer>().bounds.size.x;
        BG.transform.localScale = new Vector3(koef, koef, 1);
    }
    IEnumerator ShowBannerWhenReady()
    {
        while (!Advertisement.IsReady(placementId))
        {
            yield return new WaitForSeconds(0.5f);
        }
        Advertisement.Banner.Show(placementId);
    }
    void Awake()
    {
    
        ScreenUtils.Initialize();
    }
}
