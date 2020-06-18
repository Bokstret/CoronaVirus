using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    GameObject prefabIll1;
    [SerializeField]
    GameObject prefabIll2;
    [SerializeField]
    GameObject prefabIll3;
    [SerializeField]
    GameObject prefabIll4;

    [SerializeField]
    GameObject prefabNotIll1;
    [SerializeField]
    GameObject prefabNotIll2;
    [SerializeField]
    GameObject prefabNotIll3;
    [SerializeField]
    GameObject prefabNotIll4;

    Vector3 position = new Vector3(0, 0, 0);
    GameObject human;
    public static Timer timer;
    float koef;
    float humanRadius;
    double healthy = 0;
    GameObject[] prefabsIll = new GameObject[4];
    GameObject[] prefabsNotIll = new GameObject[4];

    void Start()
    {
        prefabsIll[0] = prefabIll1;
        prefabsIll[1] = prefabIll2;
        prefabsIll[2] = prefabIll3;
        prefabsIll[3] = prefabIll4;

        prefabsNotIll[0] = prefabNotIll1;
        prefabsNotIll[1] = prefabNotIll2;
        prefabsNotIll[2] = prefabNotIll3;
        prefabsNotIll[3] = prefabNotIll4;


        koef = GameInitializer.koef;

        human = Instantiate<GameObject>(prefabNotIll1);
        humanRadius = human.GetComponent<CircleCollider2D>().radius;
        Destroy(human);

        timer = gameObject.AddComponent<Timer>();
        timer.Duration = 2;
        timer.Run();

    }

    void Update()
    {
        if (timer.Finished)
        {
            float rand = UnityEngine.Random.Range(0f, 1f);
            int score = HUD.score;
            int side = UnityEngine.Random.Range(0, 2);
            int location = UnityEngine.Random.Range(0, 3);
           
            if (score > 0)
            {
                if (score < 53)
                {
                    healthy = 0.66 * Math.Exp(-0.025 * score);
                }
            }

            if (location == 0)
            {
                position.y = -1.231f * koef;
                position.z = 0;
            }
            else if (location == 1)
            {
                position.y = -0.881f * koef;
                position.z = 1;
            }
            else
            {
                position.y = -0.538f* koef;
                position.z = 2;
            }

            if (side == 0)
            {
                //from left to right
                position.x = ScreenUtils.ScreenLeft - humanRadius;
                if (rand > healthy)
                {
                    human = Instantiate<GameObject>(prefabsIll[UnityEngine.Random.Range(0, prefabsIll.Length)]);
                    human.transform.localScale = new Vector3(-koef, koef, 1);
                    human.transform.position = position;
                    human.tag = "IllL";
                }

                else
                {
                    human = Instantiate<GameObject>(prefabsNotIll[UnityEngine.Random.Range(0, prefabsNotIll.Length)]);
                    human.transform.localScale = new Vector3(-koef, koef, 1);
                    human.transform.position = position;
                    human.tag = "notIllL";
                }
            }
            else
            {
                //from right to left
                position.x = ScreenUtils.ScreenRight + humanRadius;
                if (rand > healthy)
                {
                    human = Instantiate<GameObject>(prefabsIll[UnityEngine.Random.Range(0, prefabsIll.Length)]);
                    human.transform.localScale = new Vector3(koef, koef, 1);
                    human.transform.position = position;
                    human.tag = "IllR";
                } 
                else
                {
                    human = Instantiate<GameObject>(prefabsNotIll[UnityEngine.Random.Range(0, prefabsNotIll.Length)]);
                    human.transform.localScale = new Vector3(koef, koef, 1);
                    human.transform.position = position;
                    human.tag = "notIllR";
                }
            }
            timer.Run();
        }
    }
    
}
