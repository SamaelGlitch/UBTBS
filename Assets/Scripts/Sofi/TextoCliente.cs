using System.Collections;
using UnityEngine;
using TMPro;

public class TextoCliente : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dialogueText; // Referencia al cuadro de texto
    [SerializeField] private AudioSource typingSound; // Sonido de escritura
    [SerializeField] private float typingSpeed = 0.05f; // Velocidad de escritura

    public void DisplayText(string message)
    {
        Debug.Log($"Recibido mensaje: {message}"); // Depurar el mensaje recibido

        if (dialogueText == null)
        {
            Debug.LogError("El cuadro de texto (dialogueText) no está asignado.");
            return;
        }

        dialogueText.gameObject.SetActive(true); // Asegúrate de que el cuadro esté activo
        StartCoroutine(AnimateText(message)); // Inicia la animación del texto
    }

    private IEnumerator AnimateText(string message)
    {
        Debug.Log("Animación del texto iniciada.");

        dialogueText.text = ""; // Limpia el texto actual

        if (typingSound != null)
        {
            typingSound.loop = true; // Hacemos que el sonido se repita mientras se escribe
            typingSound.Play(); // Comienza a reproducirse
        }

        foreach (char letter in message)
        {
            dialogueText.text += letter; // Añadir letra por letra
            yield return new WaitForSeconds(typingSpeed); // Controla la velocidad de escritura
        }

        if (typingSound != null)
        {
            typingSound.loop = false; // Desactiva el loop
            typingSound.Stop(); // Detenemos el sonido
        }

        Debug.Log("Animación del texto finalizada.");
    }

    public void HideText()
    {
        if (dialogueText != null)
        {
            dialogueText.gameObject.SetActive(false); // Oculta el cuadro de texto
        }
    }
}
