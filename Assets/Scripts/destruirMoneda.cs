using UnityEngine;

public class destruirMoneda : MonoBehaviour
{

    public AudioClip sonidoMoneda; // Clip de sonido de la moneda
    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>(); // Agregar AudioSource por código
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Verifica si el cubo la toca
        {

            movePlayer jugador = other.GetComponent<movePlayer>(); // Busca el script en el jugador
            if (jugador != null)
            {
                jugador.RecolectarMoneda(); // Llama al método para sumar la moneda
            }

              if (sonidoMoneda != null)
            {
                AudioSource.PlayClipAtPoint(sonidoMoneda, transform.position); // Reproducir sonido
            }


            Destroy(gameObject); // Destruye la moneda
        }
    }
}

