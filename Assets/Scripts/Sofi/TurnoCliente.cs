using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public class Opcion
{
    public string texto; // Texto descriptivo de la opción
    public int valor;    // Valor asociado para comparación

}

public class TurnoCliente : MonoBehaviour
{

    [SerializeField] private AudioSource audioSource; // El componente AudioSource para reproducir sonidos
    [SerializeField] private AudioClip sonidoAcierto; // Clip de sonido para aciertos
    [SerializeField] private AudioClip sonidoFallo;   // Clip de sonido para fallos

    [SerializeField] private string tipo; // Humano o Pez
    [SerializeField] private float speed; // Velocidad de movimiento
    [SerializeField] private float waitTime; // Tiempo de espera en cada waypoint
    [SerializeField] private Transform[] waypoints; // Array de waypoints
    [SerializeField] private TextoCliente textoCliente; // Referencia al script que muestra el texto
    [SerializeField] private SeleccionJugador seleccionJugador; // Referencia al script de selección del jugador

    [SerializeField]
    private List<Opcion> sabores = new List<Opcion>
    {
        new Opcion { texto = "Spices and milk will make me complete,", valor = 1 },
        new Opcion { texto = "A cozy hug served in a cup,", valor = 1 },
        new Opcion { texto = "Gentle and sweet, my taste is refined,", valor = 2 },
        new Opcion { texto = "Pure and classic, my flavor stays true,", valor = 2 },
        new Opcion { texto = "Sweet like honey, tart like lemon,", valor = 3 },
        new Opcion { texto = "When you’re feeling sick, I’m here to heal,", valor = 3 },
        new Opcion { texto = "A vibrant green powder, best antioxidant,", valor = 4 },
        new Opcion { texto = "From distant lands, that brings the energy,", valor = 4 },
        new Opcion { texto = "Red like rubies, fruity and sweet,", valor = 5 },
        new Opcion { texto = "From red berries taste so true,", valor = 5 },
        new Opcion { texto = "Sweet and smooth, with a purple hue,", valor = 6 },
        new Opcion { texto = "An exotic root turned into a drink,", valor = 6 },
        new Opcion { texto = "I’m sweet and fluffy, like a carnival dream,", valor = 7 },
        new Opcion { texto = "Like sugary clouds served in a cup,", valor = 7 },
    };

    [SerializeField]
    private List<Opcion> bobas = new List<Opcion>
    {
        new Opcion { texto = "and something sweet and sticky, that adds delight", valor = 1 },
        new Opcion { texto = "covered in sugar, its hard to resist", valor = 1 },
        new Opcion { texto = "something that sparkle like the night sky so bright", valor = 2 },
        new Opcion { texto = "with magical pearls to bring me delight", valor = 2 },
        new Opcion { texto = "with a floral scent that’s hard to miss", valor = 3 },
        new Opcion { texto = "with a soothing aroma that always ties", valor = 3 },
        new Opcion { texto = "with a salty touch for a unique delight", valor = 4 },
        new Opcion { texto = "add something green and fresh, like waves", valor = 4 },
        new Opcion { texto = "and something thats size alone brings you cheer", valor = 5 },
        new Opcion { texto = "add something big and bold, let’s make that clear", valor = 5 },
        new Opcion { texto = "with a berry delicious, I’ll mesmerize", valor = 6 },
        new Opcion { texto = "with a mix of fruits, sweet and red", valor = 6 },
        new Opcion { texto = "add something rich and dark like a dessert divine", valor = 7 },
        new Opcion { texto = "With cocoa that flavor warms my heart and soul", valor = 7 },
    };

    private int currentWaypoint;
    private bool isWaiting;
    private bool hasReachedEnd;

    private Opcion saborElegido;
    private Opcion bobaElegida;

    void Update()
    {
        if (hasReachedEnd) return;

        if (transform.position != waypoints[currentWaypoint].position)
        {
            transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypoint].position, speed * Time.deltaTime);
        }
        else if (!isWaiting)
        {
            StartCoroutine(Wait());
        }
    }

    IEnumerator Wait()
    {
        isWaiting = true;
        yield return new WaitForSeconds(waitTime);

        currentWaypoint++;
        if (currentWaypoint == waypoints.Length)
        {
            hasReachedEnd = true;

            // Seleccionar opciones aleatorias de sabor y boba
            saborElegido = sabores[Random.Range(0, sabores.Count)];
            bobaElegida = bobas[Random.Range(0, bobas.Count)];

            // Mostrar el mensaje
            string finalMessage = $"¡{saborElegido.texto} {bobaElegida.texto}!";
            textoCliente.DisplayText(finalMessage);

            // Comprobar si el jugador acertó
            ComprobarEleccionJugador();
        }

        isWaiting = false;
    }

    private void ComprobarEleccionJugador()
    {
        int saborJugador = seleccionJugador.GetSaborSeleccionado();
        int bobaJugador = seleccionJugador.GetBobaSeleccionada();

        Debug.Log($"Cliente pidió: {saborElegido.texto} (valor: {saborElegido.valor}) y {bobaElegida.texto} (valor: {bobaElegida.valor})");
        Debug.Log($"Jugador eligió: Sabor {saborJugador} y Boba {bobaJugador}");

        if (saborElegido.valor == saborJugador && bobaElegida.valor == bobaJugador)
        {
            Debug.Log("¡El jugador eligió correctamente!");
            audioSource.clip = sonidoAcierto; // Asignar el sonido de acierto
            audioSource.Play(); // Reproducir el sonido
        }
        else
        {
            Debug.Log("El jugador no coincidió con el pedido del cliente.");
            audioSource.clip = sonidoFallo; // Asignar el sonido de fallo
            audioSource.Play(); // Reproducir el sonido
        }

        // Verificar si dos GameObjects específicos están habilitados
        GameObject objeto1 = GameObject.Find("Booba1v");
        GameObject objeto2 = GameObject.Find("TeBebida1");

        if (objeto1 != null && objeto2 != null && objeto1.activeSelf && objeto2.activeSelf)
        {
            Debug.Log("Ambos GameObjects están habilitados. Eliminando el objeto raíz...");
            Destroy(gameObject); // Eliminar el GameObject raíz de este script
        }
    }


    public string GetTipo()
    {
        return tipo; // Devuelve "humano" o "pez"
    }
}
