using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaEscena : MonoBehaviour
{
    private float velocidadRotacionY = 0.02f; // Velocidad de rotación en el eje Y
    private float velocidadRotacionX = 0.02f; // Velocidad de rotación en el eje X
    private Vector3 posicionInicial; // Posición inicial de la cámara

    void Start()
    {
        posicionInicial = transform.position;
    }

    void Update()
    {

        // Rotación automática de la cámara
        float rotacionY = Mathf.Sin(Time.time * velocidadRotacionY) * 360f; // Rotación en Y
        float rotacionX = Mathf.Cos(Time.time * velocidadRotacionX) * 360f; // Rotación en X

        transform.rotation = Quaternion.Euler(rotacionX, rotacionY, 0f);
    }

}
