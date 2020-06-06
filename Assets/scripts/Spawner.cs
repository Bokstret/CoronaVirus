using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    GameObject prefabIll;
    [SerializeField]
    GameObject prefabNotIll;



    Vector2 position = new Vector2(0, 0);
    Timer timer;
    

    void Start()
    {
        timer = gameObject.AddComponent<Timer>();
        timer.Duration = 3;
        timer.Run();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer.Finished)
        {
            GameObject human = Instantiate<GameObject>(prefabNotIll);
            CircleCollider2D collider = human.GetComponent<CircleCollider2D>();
            float humanRadius = collider.radius;
            Destroy(human);

            float screenHeight = ScreenUtils.ScreenTop - ScreenUtils.ScreenBottom;
            float screenWidth = ScreenUtils.ScreenRight - ScreenUtils.ScreenLeft;
            int illOrNot = Random.Range(0, 3);
            int side = Random.Range(0, 2);
            int location = Random.Range(0, 3);
            
            if (location == 0)
            {

                position.y = ScreenUtils.ScreenTop - 8;
            }
            else if (location == 1)
            {

                position.y = (ScreenUtils.ScreenBottom + screenHeight / 2) - 3.5f;
            }
            else
            {
                position.y = ScreenUtils.ScreenBottom + 1.5f;
            }

            if (side == 0)
            {
                //from left to right
                position.x = ScreenUtils.ScreenLeft - humanRadius;
                if (illOrNot == 0)
                {
                    
                    human = Instantiate<GameObject>(prefabIll);
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
                    Human script = human.GetComponent<Human>();
                    script.Initialize(Direction.Left, new Vector2(position.x, position.y));
                    human.tag = "IllR";

                }
                else
                {
                    human = Instantiate<GameObject>(prefabNotIll);
                    Human script = human.GetComponent<Human>();
                    script.Initialize(Direction.Left, new Vector2(position.x, position.y));
                    human.tag = "notIllR";
                }
            }
            

            timer.Run();
        }
    }
    
}
