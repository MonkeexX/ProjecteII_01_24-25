using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveDuration = 0.2f;
    private Vector3 targetPosition;
    private bool isMoving;
    private GridManager gridManager;

    void Start()
    {
        gridManager = FindObjectOfType<GridManager>(); // Busca el GridManager en la escena
        targetPosition = transform.position; // Inicializa la posición objetivo
    }

    void Update()
    {
        if (!isMoving)
        {
            if (Input.GetKeyDown(KeyCode.W)) Move(Vector3.up);
            else if (Input.GetKeyDown(KeyCode.S)) Move(Vector3.down);
            else if (Input.GetKeyDown(KeyCode.A)) Move(Vector3.left);
            else if (Input.GetKeyDown(KeyCode.D)) Move(Vector3.right);
        }
    }

    private void Move(Vector3 direction)
    {
        Vector3 newPosition = transform.position + direction;

        // Verifica si la nueva posición está dentro de la cuadrícula
        int gridX = Mathf.RoundToInt(newPosition.x);
        int gridY = Mathf.RoundToInt(newPosition.y);

        if (gridX >= 0 && gridX < gridManager.width && gridY >= 0 && gridY < gridManager.height)
        {
            targetPosition = newPosition;
            StartCoroutine(MoveToPosition(targetPosition));
        }
    }

    private System.Collections.IEnumerator MoveToPosition(Vector3 position)
    {
        isMoving = true;

        float elapsedTime = 0;
        Vector3 startingPosition = transform.position;

        while (elapsedTime < moveDuration)
        {
            transform.position = Vector3.Lerp(startingPosition, position, elapsedTime / moveDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = position;
        isMoving = false;
    }
}
