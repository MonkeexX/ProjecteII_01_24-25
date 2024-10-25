using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mov : MonoBehaviour
{
    //Variables
    public float distance = 1.0f;
    public float cooldown = 0.5f;
    bool can_Move = true;
    public int counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
        //Move
       if (Input.GetKeyDown(KeyCode.W)&&can_Move)
       {
            transform.position = new Vector2 (transform.position.x, transform.position.y + distance);
            can_Move = false;
            ++counter;
        }
       if (Input.GetKeyDown(KeyCode.S) && can_Move)
       {
            transform.position = new Vector2(transform.position.x, transform.position.y - distance);
            can_Move = false;
            ++counter;
        }
       if (Input.GetKeyDown(KeyCode.D) && can_Move)
       {
            transform.position = new Vector2(transform.position.x + distance, transform.position.y);
            can_Move = false;
            ++counter;
        }
       if (Input.GetKeyDown(KeyCode.A) && can_Move)
       {
            transform.position = new Vector2(transform.position.x - distance, transform.position.y);
            can_Move = false;
            ++counter;
       }

       //Cooldown
       if (can_Move==false)
       {
            cooldown -= Time.deltaTime;

            if (cooldown < 0)
            {
                can_Move=true;
                cooldown = 0.5f;
            }
       }
    }


}

