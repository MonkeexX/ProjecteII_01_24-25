using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveTime = 0.2f; // Tiempo que tarda en moverse entre celdas
    public LayerMask obstacleLayer; // Capa para los obstáculos

    private bool isMoving = false;
    Rigidbody2D rigidbody;
    private void Start()
    {
        this.enabled = false; 
        rigidbody = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (!isMoving)
        {
            Vector3 direction = Vector3.zero;

            if (Input.GetKeyDown(KeyCode.W))
                direction = Vector3.up;
            else if (Input.GetKeyDown(KeyCode.S))
                direction = Vector3.down;
            else if (Input.GetKeyDown(KeyCode.A))
                direction = Vector3.left;
            else if (Input.GetKeyDown(KeyCode.D))
                direction = Vector3.right;

            if (direction != Vector3.zero)
            {
                Vector3 targetPosition = transform.position + direction;
                if (CanMoveTo(targetPosition))
                {
                    StartCoroutine(MoveToPosition(targetPosition));
                }
            }
        }
    }

    private bool CanMoveTo(Vector3 targetPosition)
    {
        // Verifica si hay un obstáculo en la celda destino
        Collider2D hitCollider = Physics2D.OverlapCircle(targetPosition, 0.1f, obstacleLayer);
        return hitCollider == null; // Si no hay colisión, se puede mover
    }

    private IEnumerator MoveToPosition(Vector3 targetPosition)
    {
        isMoving = true;

        float elapsedTime = 0;
        Vector3 startingPosition = transform.position;

        while (elapsedTime < moveTime)
        {
            transform.position = Vector3.Lerp(startingPosition, targetPosition, elapsedTime / moveTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPosition;
        isMoving = false;
    }
}

