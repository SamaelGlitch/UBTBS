using UnityEngine;

public class SeleccionJugador : MonoBehaviour
{
    [Header("Característica de la selección del jugador")]
    [SerializeField] private int precio; // Precio de la elección del jugador
    [SerializeField] private string rareza; // Rareza: "común" o "exótica"
    [SerializeField] [Range(1, 5)] private int popularidad; // Popularidad del 1 al 5

    private int saborSeleccionado; // Valor del sabor seleccionado por el jugador
    private int bobaSeleccionada; // Valor de la boba seleccionada por el jugador

    // Métodos para establecer las selecciones del jugador
    public void SeleccionarSabor(int valor)
    {
        saborSeleccionado = valor;
        Debug.Log($"Sabor seleccionado por el jugador: {saborSeleccionado}");
    }

    public void SeleccionarBoba(int valor)
    {
        bobaSeleccionada = valor;
        Debug.Log($"Boba seleccionada por el jugador: {bobaSeleccionada}");
    }

    // Métodos para obtener las selecciones del jugador
    public int GetSaborSeleccionado()
    {
        return saborSeleccionado;
    }

    public int GetBobaSeleccionada()
    {
        return bobaSeleccionada;
    }

    // Métodos para acceder a las características
    public int GetPrecio()
    {
        return precio;
    }

    public string GetRareza()
    {
        return rareza;
    }

    public int GetPopularidad()
    {
        return popularidad;
    }
}
