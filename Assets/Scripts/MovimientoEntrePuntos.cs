using UnityEngine;

public class MovimientoEntrePuntos : MonoBehaviour
{
    public Transform puntoA; // Primer punto de referencia
    public Transform puntoB; // Segundo punto de referencia
    public float velocidad = 2f; // Velocidad de movimiento
    public float tiempoDeEspera = 2f; // Tiempo de espera entre cada cambio de dirección

    private Transform objetivo; // Punto de referencia hacia donde se dirige
    private bool moviendoseHaciaA = false; // Indica si se está moviendo hacia el punto A

    void Start()
    {
        objetivo = puntoA; // Inicialmente se dirige hacia el punto A
        InvokeRepeating("CambiarObjetivo", tiempoDeEspera, tiempoDeEspera); // Llama a CambiarObjetivo cada tiempoDeEspera segundos
    }

    void Update()
    {
        // Mueve el objeto hacia el objetivo actual
        transform.position = Vector3.MoveTowards(transform.position, objetivo.position, velocidad * Time.deltaTime);
    }

    void CambiarObjetivo()
    {
        // Cambia el objetivo hacia el otro punto de referencia
        if (objetivo == puntoA)
        {
            objetivo = puntoB;
        }
        else
        {
            objetivo = puntoA;
        }
    }
}
