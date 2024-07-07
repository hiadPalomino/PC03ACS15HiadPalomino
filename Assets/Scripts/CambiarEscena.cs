using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEscena : MonoBehaviour
{
    public string nombreEscena; // Nombre de la escena a cargar

    private void OnTriggerEnter(Collider other)
    {
        // Verifica si la colisión es con la cápsula
        if (other.tag=="Player")
        {
            Debug.Log("Cambiando a la escena: " + nombreEscena);
            // Carga la siguiente escena
            SceneManager.LoadScene(nombreEscena);
        }
    }
}
