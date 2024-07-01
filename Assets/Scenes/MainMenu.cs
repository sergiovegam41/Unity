using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{


    AudioSource fuenteAudio;

   public void Start(){
    fuenteAudio = GetComponent<AudioSource>();
   }
    public void EscenaJuego(string ecsena)
    {

        StartCoroutine(WaitOneSecond(ecsena));

    }



    IEnumerator WaitOneSecond(string ecsena)
    {
        fuenteAudio.Play();
        yield return new WaitForSeconds(1);     
        SceneManager.LoadScene(ecsena);
    }
}
