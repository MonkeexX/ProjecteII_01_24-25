using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mov : MonoBehaviour
{
    //Variables
    public float distance = 1.0f;
    public float cooldown = 0.2f;
    bool can_Move = true;
    public int counter = 0;
    public int maxCounter = 5;
    

    // Start is called before the first frame update
    void Start()
    {
        this.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
     // un if que compruebe si le quedan movimientos o si no para que no se mueva
     if (counter != maxCounter)
        {
            if (Input.GetKeyDown(KeyCode.W) && can_Move)
            {
                transform.position = new Vector2(transform.position.x, transform.position.y + distance);
                can_Move = false;
                counter++;
            }
            if (Input.GetKeyDown(KeyCode.S) && can_Move)
            {
                transform.position = new Vector2(transform.position.x, transform.position.y - distance);
                can_Move = false;
                counter++;
            }
            if (Input.GetKeyDown(KeyCode.D) && can_Move)
            {
                transform.position = new Vector2(transform.position.x + distance, transform.position.y);
                can_Move = false;
                counter++;
            }
            if (Input.GetKeyDown(KeyCode.A) && can_Move)
            {
                transform.position = new Vector2(transform.position.x - distance, transform.position.y);
                can_Move = false;
                counter++;
            }
        }
     else
        {
            Destroy(gameObject);
            Hackeo.hasActiveObject = false;
            
        }
        
      

       //Cooldown
       if (can_Move==false)
       {
            cooldown -= Time.deltaTime;

            if (cooldown < 0)
            {
                can_Move=true;
                cooldown = 0.2f;
            }
       }
    }


}

