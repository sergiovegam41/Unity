using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParedInvisible : MonoBehaviour
{

    void Start(){
            Debug.Log("START!!" );

    }
     private void OnTriggerEnter(Collider other)
    {
        // Aquí puedes agregar condiciones para eliminar solo ciertos objetos, si es necesari
        Destroy(other.gameObject);
    }
}


