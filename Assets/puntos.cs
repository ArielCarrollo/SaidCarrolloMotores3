using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class puntos : MonoBehaviour
{
    public TextMeshProUGUI punt;

    void Start()
    {
        if (PlayerPrefs.HasKey("TiempoTranscurrido"))
        {
            float pu = PlayerPrefs.GetFloat("Puntuacion final");
            punt.text = "Puntuacion final" + pu;
        }
        else
        {
            punt.text = "No hay tiempo guardado";
        }
    }
}
