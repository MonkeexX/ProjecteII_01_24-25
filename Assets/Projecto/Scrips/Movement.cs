using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float moveTime = 0.15f;
    public float xInput, yInput, inputSpace;
    private bool isMoving;
    private Vector2 targetPosition;
    private CollisionBoxRobot collisionBoxRobot;
    private CollisionLitelBot collisionSmallRobot;
    private CollisionExplosiveRobot collisionExplosiveRobot;
    private CollisionLaserRobot collisionLaserRobot;
    private CollisionCloneRobot collisionCloneRobot;
    public GameObject robot;

    public LayerMask doorLayer;


    public bool explosive = false;
    public bool clone = false;
    public bool small = false;
    public bool laser = false;
    public bool box = false;
    public int steps = 0;

    void Start()
    {
        collisionBoxRobot = GetComponent<CollisionBoxRobot>(); // Obtiene el script CollisionBoxRobot adjunto al mismo GameObject
        collisionSmallRobot = GetComponent<CollisionLitelBot>(); // Obtiene el script CollisionBoxRobot adjunto al mismo GameObject
        collisionExplosiveRobot = GetComponent<CollisionExplosiveRobot>();
        collisionLaserRobot = GetComponent<CollisionLaserRobot>();
        collisionCloneRobot = GetComponent<CollisionCloneRobot>();
        this.enabled = false; // Deshabilitamos este script si es necesario al inicio


        if (box == true)
        {
            steps = 10;
        }
        if (small == true) 
        {
            steps = 15;
        }
    }

    void Update()
    {
        // Obtenemos la entrada del jugador
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");

        if (steps == 0)
        {
            Destroy(robot);
        }

        // Verificamos si el jugador está intentando moverse
        if ((xInput != 0f || yInput != 0f) && !isMoving && Input.anyKeyDown)
        {

            CalculateTargetPosition();

            // Verificamos si la posición de destino está libre de colisiones
            if (!collisionBoxRobot.BoxRobotCollision(targetPosition)) // Solo permitimos el movimiento si no hay colisiones
            {
                StartCoroutine(Move());
                steps--;
            }
            
            
        }

        //Global collision with the door

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

        transform.position = new Vector2(Mathf.Round(targetPosition.x), Mathf.Round(targetPosition.y));
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

    // Esto se usa para mostrar el círculo en el inspector
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(targetPosition, 0.15f);
    }
}