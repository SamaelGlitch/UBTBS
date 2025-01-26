using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource; // Referencia al componente AudioSource
    [SerializeField] private AudioClip buttonClickSound; // Clip de sonido para los botones

    void Start()
    {
    }

    void Update()
    {
    }

    public void Inicio()
    {
        PlaySoundAndWait(1); // Reproducir el sonido y cargar la escena 1
    }

    public void Credits()
    {
        PlaySoundAndWait(2); // Reproducir el sonido y cargar la escena 2
    }

    public void Exit()
    {
        PlaySound(); // Reproducir el sonido
        Debug.Log("Saliendo...");
        Application.Quit(); // Salir del juego
    }

    private void PlaySound()
    {
        if (audioSource != null && buttonClickSound != null)
        {
            audioSource.PlayOneShot(buttonClickSound); // Reproducir el sonido
        }
    }

    private void PlaySoundAndWait(int sceneIndex)
    {
        if (audioSource != null && buttonClickSound != null)
        {
            audioSource.PlayOneShot(buttonClickSound); // Reproducir el sonido
            StartCoroutine(LoadSceneAfterDelay(sceneIndex, buttonClickSound.length)); // Esperar la duración del sonido
        }
        else
        {
            // Si no hay sonido configurado, cargar la escena inmediatamente
            SceneManager.LoadScene(sceneIndex);
        }
    }

    private IEnumerator LoadSceneAfterDelay(int sceneIndex, float delay)
    {
        yield return new WaitForSeconds(delay); // Esperar la duración especificada
        SceneManager.LoadScene(sceneIndex); // Cargar la escena
    }
}
