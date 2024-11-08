using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CollicionBoxRobot : MonoBehaviour
{
    private Vector2 targetPosition;
    public LayerMask boxLayer;
    public LayerMask wallLayer;
    public LayerMask inactiveRobotLayer;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        LaserRobotCollision();
    }

    private bool LaserRobotCollision()
    {
        //Verifying if the invisible circle has collided against a wall
        if (Physics2D.OverlapCircle(targetPosition, 0.15f, wallLayer))
        {
            return false; //Player can't move
        }

        //Verifying if the invisible circle has collided against a wall
        if (Physics2D.OverlapCircle(targetPosition, 0.15f, inactiveRobotLayer))
        {
            return false; //Player can't move
        }

        //Verifying if the invisible circle has collided against a box
        if (Physics2D.OverlapCircle(targetPosition, 0.15f, boxLayer))
        {

            return false;
            
        }

        //Verifying if the invisible circle has collided against a laser
        if (Physics2D.OverlapCircle(targetPosition, 0.15f, boxLayer))
        {
            return true;
        }

        //Verifying if the invisible circle has collided against a placa explosiva
        if (Physics2D.OverlapCircle(targetPosition, 0.15f, boxLayer))
        {
            return false;
        }

        //Verifying if the invisible circle has collided against a plasma
        if (Physics2D.OverlapCircle(targetPosition, 0.15f, boxLayer))
        {
            return false;
        }

        //Verifying if the invisible circle has collided against a panel
        if (Physics2D.OverlapCircle(targetPosition, 0.15f, boxLayer))
        {
            return false;
        }

        //Verifying if the invisible circle has collided against a puerta
        if (Physics2D.OverlapCircle(targetPosition, 0.15f, boxLayer))
        {
            return false;
        }

        //If the invisible circle hasn't collided with nothing
        return true;
    }
}
