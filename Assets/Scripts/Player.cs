using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Text countText; // Texto para contar enemigos eliminados
    private int countKill;

    public float speed = 5f; // Velocidad de movimiento del jugador
    public int damage = 1; // Daño que inflige el jugador
    public LayerMask enemyLayer; // Capa de los objetos que el jugador puede matar

    void Start()
    {
        // Inicializa el contador local de bajas con el total acumulado
        countKill = GameManager.TotalKills;
        UpdateCountUI();
    }

    private void Update()
    {
        // Movimiento del jugador
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput);
        transform.Translate(movement * speed * Time.deltaTime);

        // Detección de objetos que el jugador puede matar
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 11.5f, enemyLayer);

        // Lista para llevar registro de enemigos destruidos en este frame
        List<GameObject> destroyedEnemies = new List<GameObject>();

        // Si hay objetos que el jugador puede matar en su rango, los destruye
        foreach (var hitCollider in hitColliders)
        {
            if (!destroyedEnemies.Contains(hitCollider.gameObject))
            {
                destroyedEnemies.Add(hitCollider.gameObject);
                countKill++;
                GameManager.TotalKills = countKill; // Actualiza el total acumulado en el GameManager
                Destroy(hitCollider.gameObject);
            }
        }

        // Actualizar el contador de bajas enemigas en el UI
        UpdateCountUI();
    }

    private void OnDrawGizmosSelected()
    {
        // Dibuja una esfera gizmo en la posición del jugador para mostrar su rango de ataque
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 11.5f);
    }

    void UpdateCountUI()
    {
        countText.text = "Enemigos: " + countKill.ToString(); // Actualizar el texto de bajas enemigas
    }
}
