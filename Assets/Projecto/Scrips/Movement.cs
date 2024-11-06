using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float moveTime = 0.15f;
    private Vector2 targetPosition;
    private float xInput, yInput;
    private bool isMoving;
    public LayerMask boxLayer;
    public LayerMask wallLayer;
    public LayerMask inactivePlayerLayer;

    private void Start()
    {
        this.enabled = false;
    }
    void Update()
    {
        
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");

        if ((xInput != 0f || yInput != 0f) && !isMoving && Input.anyKeyDown)
        {
            CalculateTargetPosition();
            if (CanMoveToTargetPosition())
            {
                StartCoroutine(Move());
            }
        }
    }

    IEnumerator Move()
    {
        isMoving = true;
        float timePassed = 0f;
        Vector2 startPosition = transform.position;

        while (timePassed < moveTime)
        {
            transform.position = Vector2.Lerp(startPosition, targetPosition, timePassed / moveTime); //Lerp is used to move slowly from A to B
            timePassed += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition;
        isMoving = false;
    }

    private void CalculateTargetPosition()
    {
        if (xInput == 1f)
        {
            targetPosition = (Vector2)transform.position + Vector2.right;
        }
        else if (xInput == -1f)
        {
            targetPosition = (Vector2)transform.position + Vector2.left;
        }
        if (yInput == 1f)
        {
            targetPosition = (Vector2)transform.position + Vector2.up;
        }
        else if (yInput == -1f)
        {
            targetPosition = (Vector2)transform.position + Vector2.down;
        }


    }

    private bool CanMoveToTargetPosition()
    {
        //Verifying if the invisible circle has collided against a wall
        if (Physics2D.OverlapCircle(targetPosition, 0.15f, wallLayer))
        {
            return false; //Player can't move
        }

        //Verifying if the invisible circle has collided against a wall
        if (Physics2D.OverlapCircle(targetPosition, 0.15f, inactivePlayerLayer))
        {
            return false; //Player can't move
        }

        //Verifying if the invisible circle has collided against a box
        if (Physics2D.OverlapCircle(targetPosition, 0.15f, boxLayer))
        {
            
            return false; //Player can move
        }

        //If the invisible circle hasn't collided with nothing
        return true;
    }

    //This to show the circle in the inspector
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(targetPosition, 0.15f);
    }
}