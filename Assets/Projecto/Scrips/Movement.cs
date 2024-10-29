using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Vector2 TargetPosition;
    private float xInput, yInput;
    void Update()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");

        if (xInput != 0f || yInput != 0f)
        {
            CalculateTargetPosition();
        }
    }

    private void CalculateTargetPosition()
    {
        if (xInput == 1f)
        {
            TargetPosition = (Vector2)transform.position + Vector2.right;
        }
        else if (xInput == -1f)
        {
            TargetPosition = (Vector2)transform.position + Vector2.left;
        }
        if (yInput == 1f)
        {
            TargetPosition = (Vector2)transform.position + Vector2.up;
        }
        else if (yInput == -1f)
        {
            TargetPosition = (Vector2)transform.position + Vector2.down;
        }

        private void On
    }
}
