using UnityEngine;

public class RevisarDineroJugador : MonoBehaviour
{
    [SerializeField] private CalcularProducto calcularProducto; // Referencia al script CalcularProducto
    [SerializeField] private SeleccionJugador seleccionJugador; // Referencia al script SeleccionJugador

    public void RevisarDinero()
    {
        if (calcularProducto == null || seleccionJugador == null)
        {
            Debug.LogError("Referencias no asignadas: verifica calcularProducto y seleccionJugador en el inspector.");
            return;
        }

        // Obtener el resultado calculado y el dinero seleccionado por el jugador
        int resultadoCalculo = calcularProducto.GetResultadoFinal();
        int dineroJugador = seleccionJugador.GetPrecio();

        // Comparar los valores
        if (resultadoCalculo == dineroJugador)
        {
            Debug.Log($"¡El jugador acertó! El dinero seleccionado ({dineroJugador}) coincide con el resultado calculado ({resultadoCalculo}).");
        }
        else
        {
            Debug.Log($"El jugador no acertó. Dinero seleccionado: {dineroJugador}, Resultado calculado: {resultadoCalculo}.");
        }
    }

    [ContextMenu("Probar Revisar Dinero")]
    public void ProbarRevisarDinero()
    {
        RevisarDinero(); // Método para probar la funcionalidad desde el editor
    }
}
