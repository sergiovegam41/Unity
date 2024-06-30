using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private float speed; // Velocidad de movimiento del personaje

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        

        // Calcular el movimiento
        Vector3 movement = new Vector3(1, 0.0f, 0);
        speed = Random.Range(50.0f, 100.0f);
        
        // Aplicar el movimiento al personaje
        transform.Translate(movement * speed * Time.deltaTime, Space.World);
    }
}
