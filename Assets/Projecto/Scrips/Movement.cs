using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float moveTime = 0.15f;
    private Vector2 targetPosition;
    private float xInput, yInput;
    private bool isMoving;
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
            transform.position = Vector2.Lerp(startPosition, targetPosition, timePassed / moveTime);
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
        return !Physics2D.OverlapCircle(targetPosition, 0.15f);
    }

    //Quitar esto si al final este codigo se queda, esto es para el debugging
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(targetPosition, 0.15f);
    }
}