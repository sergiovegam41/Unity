using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {

            Debug.Log(other.gameObject);
      if (other.gameObject.CompareTag("ene"))
        {
            Debug.Log("Colisión con enemigo!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }
    }
}
