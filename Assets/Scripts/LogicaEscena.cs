using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaEscena : MonoBehaviour
{
    private float velocidadRotacionY = 0.02f; // Velocidad de rotaci�n en el eje Y
    private float velocidadRotacionX = 0.02f; // Velocidad de rotaci�n en el eje X
    private Vector3 posicionInicial; // Posici�n inicial de la c�mara

    void Start()
    {
    }

    void Update()
    {

        // Rotaci�n autom�tica de la c�mara
        float rotacionY = Mathf.Sin(Time.time * velocidadRotacionY) * 360f; // Rotaci�n en Y
        float rotacionX = Mathf.Cos(Time.time * velocidadRotacionX) * 360f; // Rotaci�n en X

        transform.rotation = Quaternion.Euler(rotacionX, rotacionY, 0f);
    }

}
