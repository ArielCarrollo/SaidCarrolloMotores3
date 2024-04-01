using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using System;
public class Botones : MonoBehaviour
{
    public GameObject Jugador;
    public string Carga1;
    private bool isPaused = false;
    public static event Action<string> cambio;
    
    public static void invoWin(string a)
    {
        cambio?.Invoke(a);
    }

    private void OnEnable()
    {
        Botones.cambio += pantallas;
    }
    private void OnDisable()
    {
        Botones.cambio -= pantallas;
    }
    public void Cambio()
    {
        SpriteRenderer playerSpriteRenderer = Jugador.GetComponent<SpriteRenderer>();
        SpriteRenderer buttonSpriteRenderer = GetComponent<SpriteRenderer>();
        if (playerSpriteRenderer != null && buttonSpriteRenderer != null)
        {
            playerSpriteRenderer.color = buttonSpriteRenderer.color;
        }
    }
    public void pantallas(string Nombreecena)
    {
        SceneManager.LoadScene(Nombreecena);
    }
    public void Pausar()
    {
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0f : 1f;
    }
}
