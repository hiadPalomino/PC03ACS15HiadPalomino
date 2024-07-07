using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndScreenManager : MonoBehaviour
{
    public Text killsText; // Referencia al Text que muestra las bajas enemigas
    public Button returnButton; // Referencia al botón de regreso
    public string nombreEscena; // Nombre de la escena a cargar
    void Start()
    {
        // Asegura que el cursor del mouse esté visible y desbloqueado
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        // Actualiza el texto con el total de bajas enemigas
        killsText.text = "Total de Bajas Enemigas: " + GameManager.TotalKills.ToString();

        // Añade el listener para el botón de regreso
        returnButton.onClick.AddListener(ReturnToStart);
    }

    void ReturnToStart()
    {
        // Reinicia el contador de bajas enemigas al regresar a la escena de inicio
        GameManager.ResetTotalKills();

        // Cambia a la escena de inicio (cambia "StartScene" al nombre de tu escena de inicio)
        SceneManager.LoadScene(nombreEscena);
    }
}
