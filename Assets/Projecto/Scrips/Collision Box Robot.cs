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
    private float xInput, yInput;


    // Start is called before the first frame update

    void Start()
    {
        mov= GetComponent<Movement>();
    }
    internal bool BoxRobotCollision(Vector2 playerPosition)
    {
        // Obtenemos la entrada del jugador
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");

        targetPosition = playerPosition; // Asignamos la posici�n del jugador al targetPosition
        if (Physics2D.OverlapCircle(targetPosition, 0.15f, boxLayer))
        {
            Debug.Log("Colisi�n detectada con Box");
            GameObject box = GameObject.Find("Box(Clone)");

            if (box != null)
            {
                if (xInput == 1f)
                {
                    box.transform.position += Vector3.right;
                }
                else if (xInput == -1f)
                {
                    box.transform.position += Vector3.left;
                }
                if (yInput == 1f)
                {
                    box.transform.position += Vector3.up;
                }
                else if (yInput == -1f)
                {
                    box.transform.position += Vector3.down;
                }
                // Asigna una nueva posici�n a Box (ejemplo: desplazarlo en el eje X en 1 unidad)
                
                Debug.Log("Box se ha movido a una nueva posici�n.");

            }
            return true;
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
            return true; // Si colisiona con alg�n objeto, no se puede mover
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
            return true; // Si colisiona con alg�n objeto, no se puede mover
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
            return true; // Si colisiona con alg�n objeto, no se puede mover
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
            return true; // Si colisiona con alg�n objeto, no se puede mover
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
            return true; // Si colisiona con alg�n objeto, no se puede mover
        }
        
        else
        {
            return false; // Si no colisiona con nada, se puede mover
        }
    }
}

