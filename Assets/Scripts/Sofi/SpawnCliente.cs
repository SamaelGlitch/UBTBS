 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SpawnCliente : MonoBehaviour
{
    private float minX, maxX, minY, maxY;
    [SerializeField] private Transform[] puntos; // Puntos que delimitan el área de spawn
    [SerializeField] private GameObject[] clientes; // Lista de clientes posibles
    private List<GameObject> clientesDisponibles; // Lista dinámica para controlar clientes restantes

    private void Start()
    {
        // Inicializa los límites del área de spawn
        maxX = puntos.Max(punto => punto.position.x);
        minX = puntos.Min(punto => punto.position.x);
        maxY = puntos.Max(punto => punto.position.y);
        minY = puntos.Min(punto => punto.position.y);

        // Llena la lista de clientes disponibles
        clientesDisponibles = new List<GameObject>(clientes);
    }

    private void Update()
    {
        // Verifica si no hay clientes en la escena antes de crear uno nuevo
        if (GameObject.FindGameObjectsWithTag("Cliente").Length == 0 && clientesDisponibles.Count > 0)
        {
            CrearCliente();
        }
    }

    private void CrearCliente()
    {
        // Seleccionar un cliente aleatorio de los disponibles
        int indiceCliente = Random.Range(0, clientesDisponibles.Count);
        GameObject clienteSeleccionado = clientesDisponibles[indiceCliente];

        // Generar posición aleatoria dentro de los límites
        Vector2 posicionAleatoria = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));

        // Instanciar el cliente
        Instantiate(clienteSeleccionado, posicionAleatoria, Quaternion.identity);

        // Eliminar el cliente de la lista de disponibles
        clientesDisponibles.RemoveAt(indiceCliente);
        Debug.Log($"Cliente generado: {clienteSeleccionado.name}");
    }
}