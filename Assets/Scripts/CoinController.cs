using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    private float speed = 10f;
    public float velocidadRotacionX = 0f;
    private float velocidadRotacionY = 130f;
    public float velocidadRotacionZ = 0f;

    void Update()
    {
        float rotacionX = velocidadRotacionX * Time.deltaTime;
        float rotacionY = velocidadRotacionY * Time.deltaTime;
        float rotacionZ = velocidadRotacionZ * Time.deltaTime;

        transform.Rotate(0f, 0f, rotacionY);


        Vector3 movement = new Vector3(1, 0.0f, 0);
        speed = Random.Range(50.0f, 100.0f);

        transform.Translate(movement * speed * Time.deltaTime, Space.World);
    }
}
