using UnityEngine;

public class SaborInteractivo : MonoBehaviour
{
    [SerializeField] private SeleccionJugador seleccionJugador;
    [SerializeField] private int valorSabor; // Valor único para cada sabor o boba

    public void SeleccionarSabor()
    {
        seleccionJugador.SeleccionarSabor(valorSabor);
        Debug.Log($"Sabor seleccionado: {valorSabor}");
    }

    public void SeleccionarBoba()
    {
        seleccionJugador.SeleccionarBoba(valorSabor);
        Debug.Log($"Boba seleccionada: {valorSabor}");
    }
}
