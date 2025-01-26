using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Regreso : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource; // Referencia al componente AudioSource
    [SerializeField] private AudioClip buttonClickSound; // Sonido del botón

    public void Inicio()
    {
        PlaySoundAndWait(); // Reproducir el sonido y esperar antes de cargar la escena
    }

    private void PlaySoundAndWait()
    {
        if (audioSource != null && buttonClickSound != null)
        {
            audioSource.PlayOneShot(buttonClickSound); // Reproducir el sonido
            StartCoroutine(LoadSceneAfterDelay(buttonClickSound.length)); // Esperar la duración del sonido antes de cambiar de escena
        }
        else
        {
            // Si no hay sonido configurado, cargar la escena inmediatamente
            SceneManager.LoadScene(0);
        }
    }

    private IEnumerator LoadSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // Esperar la duración especificada
        SceneManager.LoadScene(0); // Cargar la escena
    }
}
