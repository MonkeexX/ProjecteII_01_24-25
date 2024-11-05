using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hackeo : MonoBehaviour
{
    // Start is called before the first frame update

    private Movement movement;
    public static bool hasActiveObject = false;
    
    void Start()
    {
        movement= GetComponent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            if (hit.collider != null)
            {
                // Verificar si el objeto clicado es este GameObject y si no hay un objeto activo aún
                if (hit.collider.gameObject == gameObject && !hasActiveObject)
                {
                    // Activar el script de movimiento del personaje
                    if (movement != null)
                    {
                        movement.enabled = true;
                        hasActiveObject = true; // Ahora hay un objeto activo
                        Debug.Log("¡Movimiento activado para " + gameObject.name + "!");

                       
                    }
                }
            }
        }
    }
}
