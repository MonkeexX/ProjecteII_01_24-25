using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CollisionCloneRobot : MonoBehaviour
{
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
    internal bool CloneRobotCollision(Vector2 playerPosition)
    {
        targetPosition = playerPosition; // Asignamos la posición del jugador al targetPosition

        if (Physics2D.OverlapCircle(targetPosition, 0.15f, wallLayer) ||
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


