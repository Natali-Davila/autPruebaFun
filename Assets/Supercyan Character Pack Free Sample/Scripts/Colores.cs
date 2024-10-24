using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para acceder al sistema de escenas de Unity

public class Colores : MonoBehaviour
{
    private bool jugadorColisionando = false;
    public GameObject TextDetect; // Referencia al GameObject que deseas activar/desactivar
    private GameObject player; // Referencia al GameObject del jugador

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Player"))
        {
            jugadorColisionando = true;
            if (TextDetect != null)
                TextDetect.SetActive(true);
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (other.collider.CompareTag("Player"))
        {
            jugadorColisionando = false;
            if (TextDetect != null)
                TextDetect.SetActive(false);
        }
    }

    private void Start()
    {
        if (TextDetect != null)
            TextDetect.SetActive(false); // Desactivar el texto al inicio
            
        player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
        {
            Debug.LogError("Player GameObject not found. Ensure there is a GameObject tagged as 'Player'.");
        }
    }

    private void Update()
    {
        // Verificar si se ha presionado la tecla "G" y el jugador está colisionando
        if (jugadorColisionando && Input.GetKeyDown(KeyCode.G))
        {
            ActivarObjeto();
        }
    }

    public void ActivarObjeto()
    {
        SceneManager.LoadScene("colorQuestion");
    }

    // No necesitamos el método OnGUI para cargar la escena, así que lo eliminamos
}

