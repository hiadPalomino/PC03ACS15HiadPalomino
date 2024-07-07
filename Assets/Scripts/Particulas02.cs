using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Particulas02 : MonoBehaviour
{
    public float changeInterval = 2f; // Intervalo de cambio de color en segundos

    private ParticleSystem ps; // Renombrar la variable para evitar el conflicto de nombres
    private ParticleSystem.MainModule mainModule;
    private float timer; // Temporizador para controlar el cambio de color

    void Start()
    {
        // Obtener el componente ParticleSystem adjunto a este objeto
        ps = GetComponent<ParticleSystem>();

        // Obtener el módulo principal del sistema de partículas
        mainModule = ps.main;

        // Inicializar el temporizador
        timer = changeInterval;
    }

    // Update is called once per frame
    void Update()
    {
        // Actualizar el temporizador
        timer -= Time.deltaTime;

        // Cambiar el color de las partículas cuando el temporizador llega a cero
        if (timer <= 0f)
        {
            ChangeParticleColor(GetRandomColor());

            // Reiniciar el temporizador
            timer = changeInterval;
        }
    }

    Color GetRandomColor()
    {
        // Generar un color aleatorio
        Color randomColor = new Color(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value); // Especificar UnityEngine.Random
        return randomColor;
    }

    void ChangeParticleColor(Color color)
    {
        // Configurar el color de las partículas
        mainModule.startColor = new ParticleSystem.MinMaxGradient(color);
    }
}
