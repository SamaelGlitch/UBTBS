using UnityEngine;

public class CalcularProducto : MonoBehaviour
{
    [SerializeField] private SeleccionJugador seleccionJugador; // Referencia al script SeleccionJugador
    [SerializeField] private TurnoCliente turnoCliente; // Referencia al script TurnoCliente
    private int resultadoFinal; // Aquí se guarda el resultado del cálculo

    public void Calcular()
    {
        if (seleccionJugador == null || turnoCliente == null)
        {
            Debug.LogError("Referencias no asignadas: verifica seleccionJugador y turnoCliente en el inspector.");
            return;
        }

        // Obtener valores de SeleccionJugador
        int precio = seleccionJugador.GetPrecio();
        string rareza = seleccionJugador.GetRareza();
        int popularidad = seleccionJugador.GetPopularidad();

        // Obtener el tipo del cliente desde TurnoCliente
        string tipoCliente = turnoCliente.GetTipo();

        // Calcular el valor de la rareza
        int valorRareza = rareza == "común" ? 25 : rareza == "exótica" ? 150 : 0;

        // Calcular el valor de la popularidad
        int valorPopularidad = 0;
        switch (popularidad)
        {
            case 1: valorPopularidad = 50; break;
            case 2: valorPopularidad = 125; break;
            case 3: valorPopularidad = 250; break;
            case 4: valorPopularidad = 325; break;
            case 5: valorPopularidad = 500; break;
            default: Debug.LogWarning("Popularidad fuera de rango (1-5)."); break;
        }

        // Calcular el valor del tipo de cliente
        int valorCliente = tipoCliente == "humano" ? 200 : 0;

        // Sumar todos los valores
        resultadoFinal = precio + valorRareza + valorPopularidad + valorCliente;

        // Mostrar resultado en la consola
        Debug.Log($"Resultado Final: {resultadoFinal}");
    }

    public int GetResultadoFinal()
    {
        return resultadoFinal; // Permite obtener el resultado calculado
    }

    [ContextMenu("Probar Calcular")]
    public void ProbarCalcular()
    {
        Calcular(); // Método para probar el cálculo desde el editor
    }
}
