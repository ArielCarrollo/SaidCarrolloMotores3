using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tiempogu : MonoBehaviour
{
    public TextMeshProUGUI tiempoGuardadoTexto;

    void Start()
    {
        if (PlayerPrefs.HasKey("TiempoTranscurrido"))
        {
            float tiempoGuardado = PlayerPrefs.GetFloat("TiempoTranscurrido");
            tiempoGuardadoTexto.text = "Tiempo transcurrido: " + tiempoGuardado.ToString("F2") + " segundos";
        }
        else
        {
            tiempoGuardadoTexto.text = "No hay tiempo guardado";
        }
    }
}
