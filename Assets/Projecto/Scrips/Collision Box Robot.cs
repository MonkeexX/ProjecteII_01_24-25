using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CollisionBoxRobot : MonoBehaviour
{
    private Movement mov;
    private Vector2 targetPosition;
    public LayerMask boxLayer;
    public LayerMask wallLayer;
    public LayerMask inactiveRobotLayer;
    public LayerMask laserLayer;
    public LayerMask plasmaLayer;
    public LayerMask explosivePanelLayer;
    public LayerMask panelLayer;
    public LayerMask doorLayer;
    public bool canMove;

    // Variable para controlar si se detecta una caja
    public bool push = false;
    public BoxMove boxMoveScript; // Referencia al script de la caja


    // Start is called before the first frame update

    void Start()
    {
        mov= GetComponent<Movement>();
    }
    internal bool BoxRobotCollision(Vector2 playerPosition)
    {
        targetPosition = playerPosition; // Asignamos la posición del jugador al targetPosition
         // Verificamos si el robot está cerca de la caja y la empuja
        if (mov.box && Physics2D.OverlapCircle(transform.position, 0.15f, boxLayer))
        {
            Debug.Log("colision");
            push = true;  // Activamos el push cuando el robot toca la caja
            if (boxMoveScript != null)
            {
                boxMoveScript.push = push; // Pasamos la señal de push al script de la caja
            }
            return true; // Si colisiona con algún objeto, no se puede mover
            // Aquí, puedes retornar true si quieres hacer algo más en este caso
        }

        if (mov.box && Physics2D.OverlapCircle(targetPosition, 0.15f, wallLayer) ||
            Physics2D.OverlapCircle(targetPosition, 0.15f, inactiveRobotLayer) ||
            Physics2D.OverlapCircle(targetPosition, 0.15f, laserLayer) ||
            Physics2D.OverlapCircle(targetPosition, 0.15f, plasmaLayer) ||
            Physics2D.OverlapCircle(targetPosition, 0.15f, explosivePanelLayer) ||
            Physics2D.OverlapCircle(targetPosition, 0.15f, panelLayer) ||
            Physics2D.OverlapCircle(targetPosition, 0.15f, doorLayer))
        {
            Debug.Log("Hit something");
            return true; // Si colisiona con algún objeto, no se puede mover
        }
       


        else if (mov.explosive && Physics2D.OverlapCircle(targetPosition, 0.15f, wallLayer) ||
           Physics2D.OverlapCircle(targetPosition, 0.15f, inactiveRobotLayer) ||
           Physics2D.OverlapCircle(targetPosition, 0.15f, boxLayer) ||
           Physics2D.OverlapCircle(targetPosition, 0.15f, laserLayer) ||
           Physics2D.OverlapCircle(targetPosition, 0.15f, plasmaLayer) ||
           Physics2D.OverlapCircle(targetPosition, 0.15f, explosivePanelLayer) ||
           Physics2D.OverlapCircle(targetPosition, 0.15f, panelLayer) ||
           Physics2D.OverlapCircle(targetPosition, 0.15f, doorLayer))
        {
            Debug.Log("Hit something");
            return true; // Si colisiona con algún objeto, no se puede mover
        }
        else if (mov.clone && Physics2D.OverlapCircle(targetPosition, 0.15f, wallLayer) ||
           Physics2D.OverlapCircle(targetPosition, 0.15f, inactiveRobotLayer) ||
           Physics2D.OverlapCircle(targetPosition, 0.15f, boxLayer) ||
           Physics2D.OverlapCircle(targetPosition, 0.15f, laserLayer) ||
           Physics2D.OverlapCircle(targetPosition, 0.15f, plasmaLayer) ||
           Physics2D.OverlapCircle(targetPosition, 0.15f, explosivePanelLayer) ||
           Physics2D.OverlapCircle(targetPosition, 0.15f, panelLayer) ||
           Physics2D.OverlapCircle(targetPosition, 0.15f, doorLayer))
        {
            Debug.Log("Hit something");
            return true; // Si colisiona con algún objeto, no se puede mover
        }
        else if (mov.small && Physics2D.OverlapCircle(targetPosition, 0.15f, wallLayer) ||
           Physics2D.OverlapCircle(targetPosition, 0.15f, inactiveRobotLayer) ||
           Physics2D.OverlapCircle(targetPosition, 0.15f, boxLayer) ||
           Physics2D.OverlapCircle(targetPosition, 0.15f, laserLayer) ||
           Physics2D.OverlapCircle(targetPosition, 0.15f, plasmaLayer) ||
           Physics2D.OverlapCircle(targetPosition, 0.15f, explosivePanelLayer) ||
           Physics2D.OverlapCircle(targetPosition, 0.15f, panelLayer) ||
           Physics2D.OverlapCircle(targetPosition, 0.15f, doorLayer))
        {
            Debug.Log("Hit something");
            return true; // Si colisiona con algún objeto, no se puede mover
        }
        else if (mov.laser && Physics2D.OverlapCircle(targetPosition, 0.15f, wallLayer) ||
           Physics2D.OverlapCircle(targetPosition, 0.15f, inactiveRobotLayer) ||
           Physics2D.OverlapCircle(targetPosition, 0.15f, boxLayer) ||
           Physics2D.OverlapCircle(targetPosition, 0.15f, laserLayer) ||
           Physics2D.OverlapCircle(targetPosition, 0.15f, plasmaLayer) ||
           Physics2D.OverlapCircle(targetPosition, 0.15f, explosivePanelLayer) ||
           Physics2D.OverlapCircle(targetPosition, 0.15f, panelLayer) ||
           Physics2D.OverlapCircle(targetPosition, 0.15f, doorLayer))
        {
            Debug.Log("Hit something");
            return true; // Si colisiona con algún objeto, no se puede mover
        }
        
        else
        {
            return false; // Si no colisiona con nada, se puede mover
        }
    }
}

