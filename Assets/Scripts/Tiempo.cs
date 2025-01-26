using UnityEngine;
using TMPro; 

public class Tiempo : MonoBehaviour
{
    [Header("Tiempo total en segundos ")]
    public float tiempoRestante = 300f;

    [Header("Velocidad del contador ")]
    public float velocidadContador = 1f;

    public TextMeshProUGUI textoContador;

    private bool contadorActivo = false;

    void Start()
    {
        contadorActivo = true;
        ActualizarTextoContador(tiempoRestante);
    }

    void Update()
    {
        if (contadorActivo)
        {
            if (tiempoRestante > 0)
            {
                tiempoRestante -= Time.deltaTime * velocidadContador;
                ActualizarTextoContador(tiempoRestante);
            }
            else
            {
                tiempoRestante = 0;
                contadorActivo = false;
                Destroy(gameObject);
            }
        }
    }

    void ActualizarTextoContador(float tiempoActual)
    {
        int minutos = Mathf.FloorToInt(tiempoActual / 60);
        int segundos = Mathf.FloorToInt(tiempoActual % 60);
        textoContador.text = string.Format("{0:00}:{1:00}", minutos, segundos);
    }
}
