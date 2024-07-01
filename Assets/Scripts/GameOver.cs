using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update

    AudioSource fuenteAudio;
    AudioSource music;

    void Start()
    {
        fuenteAudio = GetComponent<AudioSource>();
        // Encuentra la cámara principal y obtén el componente AudioSource
        music = Camera.main.GetComponent<AudioSource>();

        // Verifica si se encontró la cámara principal y el AudioSource
        if (music == null)
        {
            Debug.LogError("No se encontró el AudioSource en la cámara principal");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator WaitOneSecond()
    {
        // Detén la música antes de reproducir el nuevo audio
        if (music != null)
        {
            music.Stop();
        }

        fuenteAudio.Play();
        yield return new WaitForSeconds(1);     
        Debug.Log("Colisión con enemigo!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject);
        if (other.gameObject.CompareTag("ene"))
        {
            StartCoroutine(WaitOneSecond());
        }
    }
}
