using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGeneradorCion : MonoBehaviour
{
    public List<string> carPrefabPaths = new List<string> { "Coin" }; // Lista de rutas de prefabs de objetos car
    private Dictionary<string, GameObject> carPrefabs = new Dictionary<string, GameObject>();

    private float minSpawnInterval = 1f; // Intervalo mínimo de tiempo entre instancias
    private float maxSpawnInterval = 2f; // Intervalo máximo de tiempo entre instancias
    public float spawnDistance = 0f; // Distancia delante del generador donde aparecerán los objetos

    public float movementSpeed = 30.0f; // Velocidad del movimiento
    private float amplitude = 2f; // Amplitud del movimiento

    private Vector3 startPosition;
    private float timeCounter = 0.0f;

    private void Start()
    {
        startPosition = transform.position; // Guarda la posición inicial del objeto
        // Cargar todos los prefabs desde las rutas especificadas y almacenarlos en el diccionario
        foreach (string path in carPrefabPaths)
        {
            GameObject prefab = (GameObject)Resources.Load(path, typeof(GameObject));
            if (prefab != null)
            {
                carPrefabs.Add(path, prefab);
            }
            else
            {
                Debug.LogError("No se pudo cargar el prefab en la ruta: " + path);
            }
        }

        // Iniciar la generación de objetos con un intervalo aleatorio inicial
        SpawnCar();
    }

    private void Update() 
    {
        timeCounter += Time.deltaTime * movementSpeed;

        // Movimiento de arriba a abajo
        float yMovement = Mathf.Sin(timeCounter) * amplitude;

        // Movimiento de izquierda a derecha
        float xMovement = Mathf.Cos(timeCounter) * amplitude;

        // Actualiza la posición del objeto
        transform.position = startPosition + new Vector3(xMovement, yMovement, xMovement);
    }

    private void SpawnCar()
    {
        if (carPrefabs.Count > 0)
        {
            // Elegir aleatoriamente un prefab de la lista
            int randomIndex = Random.Range(0, carPrefabPaths.Count);
            string randomPath = carPrefabPaths[randomIndex];
            GameObject carPrefab = carPrefabs[randomPath];

            // Calcular la posición de spawn delante del generador
            Vector3 spawnPosition = transform.position + (transform.forward * 10f) * spawnDistance;
            // Instanciar el prefab del objeto car en la posición calculada
            Instantiate(carPrefab, spawnPosition, transform.rotation);

            // Generar un nuevo intervalo de tiempo aleatorio
            float spawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);

            // Llamar a SpawnCar nuevamente después del intervalo generado
            Invoke("SpawnCar", spawnInterval);
        }
    }
}
