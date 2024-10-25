using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private float movement = 0f;
    [SerializeField] private float speed;
    [SerializeField] private float smoth;

    private Vector3 velocidad = Vector3.zero;
    private bool position = true;
    private void Start()
    {
        this.enabled = false;
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        movement = Input.GetAxisRaw("Horizontal") * speed;
    }

    private void FixedUpdate()
    {
        Mover(movement * Time.fixedDeltaTime);
    }

    private void Mover(float mover)
    {
        Vector3 velocidadObjetivo = new Vector2(mover, rb2d.velocity.y);
        rb2d.velocity = Vector3.SmoothDamp(rb2d.velocity, velocidadObjetivo, ref velocidad, smoth);

        if (mover > 0 && !position)
        {
            Girar();
        }
        else if (mover < 0 && position)
        {
            Girar();
        }
    }

    private void Girar()
    {
        position = !position;
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;
    }
}
