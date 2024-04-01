using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;

public class Vida : MonoBehaviour
{
    private Slider slider;
    
    private void Awake()
    {
        slider = GetComponent<Slider>();
    }
    public void quitarvida(float quita)
    {
        slider.value = quita;
    }
    public void Full(float quita)
    {
        quitarvida(quita);
    }
    public static event Action<float> editarvidajugador;
    public static event Action<float> quitarvidajugador;
    public static void InvoCurar(float cura)
    {
        editarvidajugador?.Invoke(cura);
    }
    public static void invoquitar(float quitar)
    {
        quitarvidajugador?.Invoke(quitar);
    } 

}
