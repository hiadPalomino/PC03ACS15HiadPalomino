using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovementSpawner : MonoBehaviour
{
    public GameObject objectToClone; // El prefab del objeto a clonar
    public int numberOfClones = 5; // Número de clones
    public float spawnRadius = 5f; // Radio de spawn
    public float changeDirectionInterval = 5f; // Intervalo de cambio de dirección

    private List<GameObject> clones = new List<GameObject>();

    void Start()
    {
        StartCoroutine(SpawnClones());
    }

    IEnumerator SpawnClones()
    {
        // Espera 5 segundos antes de generar los clones
        yield return new WaitForSeconds(1f);

        for (int i = 0; i < numberOfClones; i++)
        {
            // Genera los clones en una posición aleatoria alrededor del punto de spawn
            Vector3 spawnPosition = transform.position + (Vector3)(Random.insideUnitCircle * spawnRadius);
            spawnPosition.y = Mathf.Clamp(spawnPosition.y, 0, 1); // Limita la altura máxima a 1
            GameObject clone = Instantiate(objectToClone, spawnPosition, Quaternion.identity);
            clones.Add(clone);

            // Añade el script de movimiento aleatorio a cada clon
            RandomMovement randomMovement = clone.AddComponent<RandomMovement>();
            randomMovement.changeDirectionInterval = changeDirectionInterval;

            // Inicia la rutina de cambio de dirección inmediatamente
            randomMovement.StartMoving();
        }
    }
}
