using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    GameObject prefabIll;
    [SerializeField]
    GameObject prefabNotIll;



    Vector3 position = new Vector3(0, 0, 0);
    Timer timer;
    
    float koef;
    void Start()
    {
        koef = Menu.koef;

        timer = gameObject.AddComponent<Timer>();
        timer.Duration = 3;
        timer.Run();

    }

    // Update is called once per frame
    void Update()
    {
        if (timer.Finished)
        {
            print(koef);
            GameObject human = Instantiate<GameObject>(prefabNotIll);
            CircleCollider2D collider = human.GetComponent<CircleCollider2D>();
            float humanRadius = collider.radius;
            Destroy(human);


            int illOrNot = Random.Range(0, 3);
            int side = Random.Range(0, 2);
            int location = Random.Range(0, 3);
            int chooseSprite = Random.Range(0, 3);
           

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
                if (illOrNot == 0)
                {
                    
                    human = Instantiate<GameObject>(prefabIll);
                    human.transform.localScale = new Vector3(koef, koef, 1);
                    Vector3 theScale = human.transform.localScale;
                    theScale.x *= -1;
                    human.transform.localScale = theScale;
                    Human script = human.GetComponent<Human>();
                    script.Initialize(Direction.Right, new Vector2(position.x, position.y));
                    human.tag = "IllL";


                }
                else
                {
                    human = Instantiate<GameObject>(prefabNotIll);
                    human.transform.localScale = new Vector3(koef, koef, 1);
                    Vector3 theScale = human.transform.localScale;
                    theScale.x *= -1;
                    human.transform.localScale = theScale;
                    Human script = human.GetComponent<Human>();
                    script.Initialize(Direction.Right, new Vector2(position.x, position.y));
                    human.tag = "notIllL";

                }
            }
            else
            {
                //from right to left

                position.x = ScreenUtils.ScreenRight + humanRadius;
                if (illOrNot == 0)
                {
                    human = Instantiate<GameObject>(prefabIll);
                    human.transform.localScale = new Vector3(koef, koef, 1);
                    Human script = human.GetComponent<Human>();
                    script.Initialize(Direction.Left, new Vector2(position.x, position.y));
                    human.tag = "IllR";

                }
                else
                {
                    human = Instantiate<GameObject>(prefabNotIll);
                    human.transform.localScale = new Vector3(koef, koef, 1);
                    Human script = human.GetComponent<Human>();
                    script.Initialize(Direction.Left, new Vector2(position.x, position.y));
                    human.tag = "notIllR";
                }
            }
            

            timer.Run();
        }
    }
    
}
