// En el script donde manejas la transición de escenas (por ejemplo, tu LevelManager):
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    
    void Start()
    {
        // Asegúrate de mostrar y desbloquear el cursor al iniciar la escena
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void EndLevel()
    {
        // Cambia a la escena final cuando el nivel termina
        SceneManager.LoadScene("EndScene");
    }
}
