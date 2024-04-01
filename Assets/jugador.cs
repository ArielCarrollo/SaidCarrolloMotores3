using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using System;

public class jugador : MonoBehaviour
{
    public float SpeedX;
    private Rigidbody2D _comRigiBody;
    private float horizontal;
    public float raycast;
    public bool Isground;
    public LayerMask Detectar;
    public bool Saltar;
    public float distancia;
    private int saltosRestantes;
    public int maxSaltos = 2;
    private SpriteRenderer mySpriteRenderercolor;
    private float vida = 10;
    private float VidaMaxima = 10;
    public Vida BarraV;
    public GameObject Moneda;

    private void Start()
    {
        vida = VidaMaxima;
        BarraV.Full(vida);
    }
    private void OnEnable()
    {
        Vida.editarvidajugador += curar;
        Vida.quitarvidajugador += RecibeDaño;
        Botones.cambio += pantallas;
    }
   
    private void OnDisable()
    {
        Vida.editarvidajugador -= curar;
        Vida.quitarvidajugador -= RecibeDaño;
        Botones.cambio -= pantallas;
        
    }
    public void RecibeDaño(float daño)
    {
        vida -= daño;
        BarraV.quitarvida(vida);
        if (vida <= 0)
        {
            Destroy(gameObject);
            pantallas("3");
        }
    }
    public void curar(float cantidad)
    {
        vida += cantidad;
        vida = Mathf.Min(vida, VidaMaxima); 
       
        BarraV.quitarvida(vida);
    }

    void Awake()
    {
        mySpriteRenderercolor = GetComponent<SpriteRenderer>();
        _comRigiBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        Isground = Physics2D.Raycast(transform.position, Vector2.down, raycast, Detectar);
        if (Isground)
        {
            saltosRestantes = maxSaltos;
        }

        if (Input.GetButtonDown("Jump") && (saltosRestantes > 0))
        {
            Saltar = true;
            saltosRestantes--;
        }
    }

    void FixedUpdate()
    {
        _comRigiBody.velocity = new Vector2(horizontal * SpeedX, _comRigiBody.velocity.y);
        if (Saltar)
        {
            _comRigiBody.velocity = new Vector2(_comRigiBody.velocity.x, 0);
            _comRigiBody.AddForce(new Vector2(0, distancia), ForceMode2D.Impulse);
            Saltar = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        SpriteRenderer otherSpriteRenderer = collision.collider.GetComponent<SpriteRenderer>();
        if (otherSpriteRenderer != null)
        {

            if (mySpriteRenderercolor.color == otherSpriteRenderer.color)
            {

                GetComponent<Collider2D>().isTrigger = true;
            }
            else if (mySpriteRenderercolor.color != otherSpriteRenderer.color && otherSpriteRenderer.tag == "color")
            {
                RecibeDaño(1.0f);
            }
        }
        if (collision.gameObject.tag == "A")
        {
            pantallas("2");
        }
        if (collision.gameObject.tag == "E")
        {
            pantallas("4");
        }
        
    }
    public void pantallas (string a)
    {
        SceneManager.LoadScene(a);
    }
  
    private void OnTriggerExit2D(Collider2D collision)
    {
        GetComponent<Collider2D>().isTrigger = false;
    }
}
