using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using System;

public class Puntuacion : MonoBehaviour
{
    public TextMeshProUGUI puntuacion;
    public GameObject coin;
    
    public int pun;
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag==("jugador"))
        {
            Moned(1);
            Destroy(this.gameObject);
        }
    }
    void Update()
    {
        
       puntuacion.text = "Puntuacion: " +pun ;
    }
    private void OnEnable()
    {
        Manager.Puntaje += Moned;
    }
    public void Moned(int n)
    {
        pun += n;
    }
    void OnDisable()
    {
        Manager.Puntaje -= Moned;
        GuardarTiempo();
    }

    void GuardarTiempo()
    {
        PlayerPrefs.SetFloat("Puntuacion final", pun
            );
    }
}