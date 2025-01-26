using UnityEngine;
using TMPro; // Aseg�rate de tener TextMeshPro instalado

public class Libro : MonoBehaviour
{
    [SerializeField] private GameObject hojaDePapel; // Referencia a la hoja
    [SerializeField] private Transform posicionReferencia; // Objeto vac�o para la posici�n deseada
    [SerializeField] private AudioSource audioSource; // Referencia al componente AudioSource
    [SerializeField] private AudioClip clickSound; // Clip de sonido para el clic

    [SerializeField] private TextMeshProUGUI hojaTexto; // Referencia al texto �nico en la hoja

    private bool hojaVisible = false; // Estado: indica si la hoja est� visible o no

    private void Start()
    {
        // Aseg�rate de que la hoja y el texto est�n desactivados al inicio
        if (hojaDePapel != null)
        {
            hojaDePapel.SetActive(false);
        }
    }

    private void OnMouseDown()
    {
        if (audioSource != null && clickSound != null)
        {
            // Reproducir el sonido del clic
            audioSource.PlayOneShot(clickSound);
        }

        if (hojaDePapel != null && posicionReferencia != null)
        {
            // Alternar estado
            hojaVisible = !hojaVisible;

            if (hojaVisible)
            {
                // Mostrar la hoja
                hojaDePapel.SetActive(true);

                // Colocar la hoja en la posici�n de referencia
                Vector3 nuevaPosicion = posicionReferencia.position;
                nuevaPosicion.z = 0; // Cambiar seg�n el tipo de c�mara
                hojaDePapel.transform.position = nuevaPosicion;
            }
            else
            {
                // Ocultar la hoja y el texto
                hojaDePapel.SetActive(false);
            }
        }
    }

}

