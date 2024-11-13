using System.Collections;
using UnityEngine;

public class BoxMove : MonoBehaviour
{
    private float moveTime = 0.15f;
    private Vector2 targetPosition;
    private bool isMoving;

    public bool push = false; // Cambiado para ser público y poder asignarse desde otro script

    void Start()
    {
        // Aseguramos que 'push' esté correctamente inicializado en otro lado.
    }

    void Update()
    {
        // Solo comenzamos a mover la caja si 'push' es true y no estamos ya moviéndola
        if (push && !isMoving)
        {
            CalculateTargetPosition();  // Calculamos la nueva posición objetivo
            StartCoroutine(Move());     // Iniciamos la corutina para mover la caja
        }
    }

    // Corutina que realiza el movimiento de la caja
    IEnumerator Move()
    {
        isMoving = true;  // Marcamos que la caja está en movimiento
        float timePassed = 0f;
        Vector2 startPosition = transform.position;  // Guardamos la posición inicial

        // Mientras el tiempo de movimiento no haya pasado completamente, seguimos moviendo la caja
        while (timePassed < moveTime)
        {
            // Realizamos la interpolación para mover la caja suavemente
            transform.position = Vector2.Lerp(startPosition, targetPosition, timePassed / moveTime);
            timePassed += Time.deltaTime;  // Incrementamos el tiempo pasado
            yield return null;  // Esperamos al siguiente frame
        }

        // Aseguramos que la caja quede exactamente en la posición de destino al final
        transform.position = targetPosition;

        // Terminamos el movimiento
        isMoving = false;
    }

    // Calculamos la posición de destino de la caja (en este caso, moviéndola hacia la derecha)
    private void CalculateTargetPosition()
    {
        targetPosition = (Vector2)transform.position + Vector2.right;  // Movemos hacia la derecha
    }
}