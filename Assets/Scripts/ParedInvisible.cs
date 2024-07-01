using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ParedInvisible : MonoBehaviour
{

    void Start(){
            Debug.Log("START!!" );

    }
     private void OnTriggerEnter(Collider other)
    {
        // Aquí puedes agregar condiciones para eliminar solo ciertos objetos, si es necesari
        
        Destroy(other.gameObject);
        if (true) {
            Debug.Log("saliooo");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
    }
}


