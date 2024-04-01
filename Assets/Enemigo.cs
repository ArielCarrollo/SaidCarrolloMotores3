using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public float LimiteI ;
    public float LimiteD;
    public int direccion;
    public float speed = 1;
    private Rigidbody2D rigi;
     

    private void Awake()
    {
        rigi = GetComponent<Rigidbody2D>();
    }
   
    void FixedUpdate()
    {
        if (transform.position.x <= LimiteI)
        {
            direccion = 1;
        }
        else if (transform.position.x >= LimiteD)
        {
            direccion = -1;
        }
        rigi.velocity = new Vector2(direccion * speed, rigi.velocity.y);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("jugador"))
        {
            jugador jugador = collision.gameObject.GetComponent<jugador>();
            if (jugador != null)
            {
                float daño = 1.0f;
                jugador.RecibeDaño(daño);
            }
        }
    }
}
