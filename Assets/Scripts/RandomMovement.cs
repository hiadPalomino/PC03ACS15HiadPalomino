using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    public float speed = 30f; // Velocidad de movimiento
    public float changeDirectionInterval = 5f; // Intervalo de cambio de dirección
    public float gravity = -9.81f; // Gravedad

    private Vector3 targetDirection;
    private CharacterController characterController;
    private Vector3 velocity;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        if (characterController == null)
        {
            characterController = gameObject.AddComponent<CharacterController>();
        }
    }

    void Update()
    {
        // Aplica gravedad
        if (characterController.isGrounded)
        {
            velocity.y = 0;
        }
        else
        {
            velocity.y += gravity * Time.deltaTime;
        }

        // Mueve el clon en la dirección objetivo
        Vector3 move = targetDirection * speed * Time.deltaTime;
        characterController.Move(move + velocity * Time.deltaTime);

        // Rotar el clon hacia la dirección del movimiento
        if (targetDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 2);
        }
    }

    public void StartMoving()
    {
        StartCoroutine(ChangeDirectionRoutine());
    }

    IEnumerator ChangeDirectionRoutine()
    {
        while (true)
        {
            // Genera una nueva dirección aleatoria
            targetDirection = Random.insideUnitSphere;
            targetDirection.y = 0; // Mantiene el movimiento en el plano horizontal
            targetDirection.Normalize();

            // Espera el intervalo antes de cambiar de dirección
            yield return new WaitForSeconds(changeDirectionInterval);
        }
    }
}
