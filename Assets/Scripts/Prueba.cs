using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Prueba : MonoBehaviour
{
    public GameManager gameManager;

    public TextMeshProUGUI preciotext;
    public SeleccionJugador seleccionJugador;
    public TurnoCliente turnoCliente;
    [SerializeField] private int precio = 0;

    [SerializeField] private int currentprecio = 0;

    void Start()
    {   
        UpdatePrice();
    }

    void Update()
    {
        currentprecio = precio;
    }

    private void UpdatePrice()
    {
        preciotext.text = precio.ToString();
    }

    public void EnterCash()
    {
        //Funcion de comparacion de producto y precio con un if/else
        //Si funciona se ejecuta lo siguiente
        gameManager.TimingOut(currentprecio); 
        Reset0();
    }

    public void Reset0()
    {
        precio = 0;
        UpdatePrice();
    }

    public void Add100()
    {
        precio += 100;
        UpdatePrice();
    }

    public void Remove100()
    {
        precio -= 100;
        UpdatePrice();
    }

    public void Add75()
    {
        precio += 75;
        UpdatePrice();
    }

    public void Remove75()
    {
        precio -= 75;
        UpdatePrice();
    }

    public void Add50()
    {
        precio += 50;
        UpdatePrice();
    }

    public void Remove50()
    {
        precio -= 50;
        UpdatePrice();
    }

    public void Add25()
    {
        precio += 25;
        UpdatePrice();
    }

    public void Remove25()
    {
        precio -= 25;
        UpdatePrice();
    }

}
