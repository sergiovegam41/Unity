using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private float speed = 10.0f; // Velocidad de movimiento del personaje
    private float jumpForce = 10.0f; // Fuerza del salto
    private bool isGrounded; // Verifica si el personaje está en el suelo
    private bool isCrouching; // Verifica si el personaje está agachado
    private bool canDoubleJump; // Verifica si el personaje puede hacer un doble salto
    private float crouchDuration = 0.25f; // Duración del agachado

    private Animator anim;  
    private Rigidbody rb; // Componente Rigidbody del personaje
    private GameObject hips;

    public CinemachineVirtualCamera virtualCamera; // Referencia a la CinemachineVirtualCamera
    private float targetFOV; // FOV objetivo para la transición
    private float fovSmoothTime = 0.2f; // Tiempo de suavizado para la transición de FOV
    private float fovVelocity = 0.0f; // Velocidad de suavizado para la transición de FOV

    private CapsuleCollider capsuleCollider; // Referencia al CapsuleCollider

    public Text timerText; // Texto de UI para mostrar el temporizador
    private float timeElapsed;



    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        hips = GameObject.Find("player");
        capsuleCollider = GetComponent<CapsuleCollider>();
        targetFOV = virtualCamera.m_Lens.FieldOfView;
        timeElapsed = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        // Obtener la entrada del teclado
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Calcular el movimiento
        Vector3 movement = new Vector3(moveVertical * -1, 0.0f, moveHorizontal);

        // Aplicar el movimiento al personaje solo si no está agachado
        if (!isCrouching)
        {
            transform.Translate(movement * speed * Time.deltaTime, Space.World);
        }

        // Manejar la animación
        anim.SetFloat("X", moveHorizontal);
        anim.SetFloat("Y", moveVertical);

        // Manejar el salto y el doble salto
        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded)
            {
                Jump();
                canDoubleJump = true;
            }
            else if (canDoubleJump)
            {
                Jump();
                canDoubleJump = false;
            }
        }

        // Manejar el agachado
        if (isGrounded && Input.GetKeyDown(KeyCode.LeftControl))
        {
            Crouch();
        }

        // Suavizar la transición de FOV
        virtualCamera.m_Lens.FieldOfView = Mathf.SmoothDamp(virtualCamera.m_Lens.FieldOfView, targetFOV, ref fovVelocity, fovSmoothTime);

        timeElapsed += Time.deltaTime;
        DisplayTime(timeElapsed);
    }

    private void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isGrounded = false;
        anim.SetBool("isGrounded", isGrounded);
        targetFOV = 70; // Cambiar FOV objetivo a 60 cuando salta
    }

    private void Crouch()
    {
        isCrouching = true;
        anim.SetBool("isCrouching", true);
        // Cambiar el tamaño y la posición del collider instantáneamente
        capsuleCollider.height = 1.0f;
        capsuleCollider.center = new Vector3(capsuleCollider.center.x, capsuleCollider.center.y - 0.5f, capsuleCollider.center.z);
        StartCoroutine(StandUpAfterDelay(crouchDuration));
    }

    private IEnumerator StandUpAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        isCrouching = false;
        anim.SetBool("isCrouching", false);
        // Restaurar el tamaño y la posición del collider instantáneamente
        capsuleCollider.height = 2.0f;
        capsuleCollider.center = new Vector3(capsuleCollider.center.x, capsuleCollider.center.y + 0.5f, capsuleCollider.center.z);
    }

    // Detectar colisiones para saber cuándo el personaje está en el suelo
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            anim.SetBool("isGrounded", isGrounded);
            targetFOV = 40; // Cambiar FOV objetivo a 40 cuando está en el suelo
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1; // Opcional, si quieres ajustar el tiempo mostrado

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        float milliseconds = (timeToDisplay % 1) * 1000;

        timerText.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
    }
}
