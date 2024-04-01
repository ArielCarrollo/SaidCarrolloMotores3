using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class Curar1 : MonoBehaviour
{
    private Rigidbody2D rigi;

    private void Awake()
    {
        rigi = GetComponent<Rigidbody2D>();
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("jugador"))
            {
                jugador jugador = collision.gameObject.GetComponent<jugador>();
                if (jugador != null)
                {
                float cantidadACurar = 2;
                jugador.curar(cantidadACurar);
                Destroy(this.gameObject);
                }
            }
        }
}
